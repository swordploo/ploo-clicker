using System;
using System.Runtime.InteropServices;

namespace plooClicker
{
    internal class TimeResolutionHelper : IDisposable
    {
        [DllImport("winmm.dll", EntryPoint = "timeBeginPeriod", SetLastError = true)]
        private static extern uint timeBeginPeriod(uint uMilliseconds);

        [DllImport("winmm.dll", EntryPoint = "timeEndPeriod", SetLastError = true)]
        private static extern uint timeEndPeriod(uint uMilliseconds);

        public TimeResolutionHelper(uint resolution = 1)
        {
            if (timeBeginPeriod(resolution) != 0)
            {
                Console.WriteLine("Failed to set high-resolution timer.");
            }
        }

        public void Dispose()
        {
            timeEndPeriod(1);
        }
    }
}