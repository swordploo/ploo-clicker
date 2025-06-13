using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plooClicker
{
    public enum ClickType { Left, Right }
    public enum EngineOperatingMode { LeftTriggerSimulatesLeft, RightTriggerSimulatesRight, DualIndependentTriggers }

    internal class AutoClickerEngine
    {
        public System.Drawing.Rectangle AppBounds { get; set; }
        private readonly Random _random = new Random();
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private bool isEngineEnabled = false;
        public bool IsEnabled => isEngineEnabled;
        private volatile bool _isSimulatingLeft = false;
        private volatile bool _isSimulatingRight = false;
        public int MinCps { get; set; } = 8;
        public int MaxCps { get; set; } = 12;
        public EngineOperatingMode CurrentOperatingMode { get; set; } = EngineOperatingMode.LeftTriggerSimulatesLeft;

        private readonly Queue<double> _cpsHistory = new Queue<double>();
        private const int CpsHistorySize = 10; // Average over the last 1 second (10 * 100ms)
        private bool _isFirstReport; // Flag to handle the "priming" of the average

        private int _clicksInCurrentReportingInterval = 0;
        private readonly System.Timers.Timer _cpsReportingTimer;
        public event Action<int> ActualCpsReported;
        private DateTime _lastCpsReportTimestamp;

        public AutoClickerEngine()
        {
            _cpsReportingTimer = new System.Timers.Timer
            {
                Interval = 100,
                AutoReset = true
            };
            _cpsReportingTimer.Elapsed += OnCpsReportTimerElapsed;
        }

        private void OnCpsReportTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!isEngineEnabled && _cpsHistory.Count == 0)
            {
                if (_cpsReportingTimer.Enabled) _cpsReportingTimer.Stop();
                return;
            }

            DateTime now = DateTime.UtcNow;
            TimeSpan elapsedTimespan = now - _lastCpsReportTimestamp;
            _lastCpsReportTimestamp = now;

            int clicksCountedThisInterval = Interlocked.Exchange(ref _clicksInCurrentReportingInterval, 0);

            double calculatedCps = 0;
            if (elapsedTimespan.TotalSeconds > 0.01)
            {
                calculatedCps = clicksCountedThisInterval / elapsedTimespan.TotalSeconds;
            }

            if (_isFirstReport)
            {
                // On the very first report, fill the entire history with the first reading.
                for (int i = 0; i < CpsHistorySize; i++)
                {
                    _cpsHistory.Enqueue(calculatedCps);
                }
                _isFirstReport = false; // Only do this once per start.
            }
            else
            {
                // For all other reports, use the normal rolling average.
                _cpsHistory.Enqueue(calculatedCps);
                if (_cpsHistory.Count > CpsHistorySize)
                {
                    _cpsHistory.Dequeue();
                }
            }

            // If stopped, force zeros into the history to make it wind down visually
            if (!isEngineEnabled)
            {
                _cpsHistory.Enqueue(0);
                if (_cpsHistory.Count > CpsHistorySize) _cpsHistory.Dequeue();
            }

            double smoothedCps = _cpsHistory.Average();
            ActualCpsReported?.Invoke((int)Math.Round(smoothedCps));

            // If the engine is off and the display has reached zero, stop the timer.
            if (!isEngineEnabled && smoothedCps < 1 && _cpsHistory.All(c => c == 0))
            {
                _cpsHistory.Clear();
                if (_cpsReportingTimer.Enabled) _cpsReportingTimer.Stop();
            }
        }

        public void Start()
        {
            if (isEngineEnabled) return;
            isEngineEnabled = true;

            _cpsHistory.Clear();
            _isFirstReport = true; // Set the flag to prime the average on the first report

            Interlocked.Exchange(ref _clicksInCurrentReportingInterval, 0);
            MouseHook.OnLeftMouseDown += OnPhysicalLeftMouseDown;
            MouseHook.OnLeftMouseUp += OnPhysicalLeftMouseUp;
            MouseHook.OnRightMouseDown += OnPhysicalRightMouseDown;
            MouseHook.OnRightMouseUp += OnPhysicalRightMouseUp;
            MouseHook.Start();
            _lastCpsReportTimestamp = DateTime.UtcNow;
            _cpsReportingTimer.Start();
        }

        public void Stop() { if (!isEngineEnabled) return; isEngineEnabled = false; }
        private void OnPhysicalLeftMouseDown() 
        { 
            if (isEngineEnabled && (CurrentOperatingMode == EngineOperatingMode.LeftTriggerSimulatesLeft || CurrentOperatingMode == EngineOperatingMode.DualIndependentTriggers)) 
            { 
                if (!_isSimulatingLeft) { _isSimulatingLeft = true; 
                    Task.Run(() => ClickLoop(ClickType.Left)); 
                } 
            } 
        }
        private void OnPhysicalLeftMouseUp() 
        { 
            if (CurrentOperatingMode == EngineOperatingMode.LeftTriggerSimulatesLeft || CurrentOperatingMode == EngineOperatingMode.DualIndependentTriggers) 
            { _isSimulatingLeft = false; 
            } 
        }
        private void OnPhysicalRightMouseDown() 
        { 
            if (isEngineEnabled && (CurrentOperatingMode == EngineOperatingMode.RightTriggerSimulatesRight || CurrentOperatingMode == EngineOperatingMode.DualIndependentTriggers)) 
            { 
                if (!_isSimulatingRight) { _isSimulatingRight = true; 
                    Task.Run(() => ClickLoop(ClickType.Right)); 
                } 
            } 
        }
        private void OnPhysicalRightMouseUp() 
        { 
            if (CurrentOperatingMode == EngineOperatingMode.RightTriggerSimulatesRight || CurrentOperatingMode == EngineOperatingMode.DualIndependentTriggers) 
            { 
                _isSimulatingRight = false; 
            } 
        }
        private async Task ClickLoop(ClickType clickActionToPerform)
        {
            bool KeepClicking() => clickActionToPerform == ClickType.Left ? _isSimulatingLeft : _isSimulatingRight;

            while (isEngineEnabled && KeepClicking())
            {
                _stopwatch.Restart();
                if (!AppBounds.IsEmpty && AppBounds.Contains(Cursor.Position)) { await Task.Delay(100); continue; }
                switch (clickActionToPerform) { case ClickType.Left: MouseActions.LeftClick(); break; case ClickType.Right: MouseActions.RightClick(); break; }

                Interlocked.Increment(ref _clicksInCurrentReportingInterval);
                int targetCps = _random.Next(MinCps, MaxCps + 1);
                if (targetCps <= 0) targetCps = 1;
                double targetCycleTimeMs = 1000.0 / targetCps;

                // --- JITTER LOGIC ---
                // Add an extra, small random delay to make the timing even more unpredictable.
                // This adds or subtracts up to 12ms from the calculated delay.
                const int jitterMilliseconds = 12;
                int jitter = _random.Next(-jitterMilliseconds, jitterMilliseconds + 1);
                targetCycleTimeMs += jitter;
                // ------------------------

                double executionTimeMs = _stopwatch.Elapsed.TotalMilliseconds;
                double remainingTimeMs = targetCycleTimeMs - executionTimeMs;

                if (remainingTimeMs > 0)
                {
                    const int coarseWaitThresholdMs = 16;
                    if (remainingTimeMs > coarseWaitThresholdMs)
                    {
                        await Task.Delay(TimeSpan.FromMilliseconds(remainingTimeMs - coarseWaitThresholdMs));
                    }
                    while (_stopwatch.Elapsed.TotalMilliseconds < targetCycleTimeMs)
                    {
                        Thread.SpinWait(10);
                    }
                }
            }
        }
    }
}