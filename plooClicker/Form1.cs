using System;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace plooClicker
{
    public partial class Form1 : MetroForm
    {
        private readonly AutoClickerEngine clickerEngine = new AutoClickerEngine();
        private AppSettings _currentSettings;
        private bool _isListeningForHotkey = false;

        private bool _isUpdatingClickTypeCheckboxes = false;
        private const int _formHeightExpanded = 360;
        private const int _formHeightCompact = 186;
        private bool _settingsPanelIsVisible = false;
        private const int WM_HOTKEY = 0x0312;
        private const int HOTKEY_ID_TOGGLE_AUTOCLICKER = 1;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            clickerEngine.ActualCpsReported += Engine_CpsValueUpdated;

            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _currentSettings = SettingsService.LoadSettings();
            LoadSettingsIntoUI();
            RegisterCurrentHotkey();

            panelSettings.Visible = false;
            this.Height = _formHeightCompact;
            _settingsPanelIsVisible = false;
            btnToggleSettings.Text = "▼ Settings ▼";
        }

        private void LoadSettingsIntoUI()
        {
            metroTrackBarMin.Value = _currentSettings.MinCps;
            metroTrackBarMax.Value = _currentSettings.MaxCps;
            metroLabelMinCpsValue.Text = _currentSettings.MinCps.ToString();
            metroLabelMaxCpsValue.Text = _currentSettings.MaxCps.ToString();
            clickerEngine.MinCps = _currentSettings.MinCps;
            clickerEngine.MaxCps = _currentSettings.MaxCps;
            btnSetHotkey.Text = $"Hotkey: {_currentSettings.Hotkey}";
            this.TopMost = _currentSettings.AlwaysOnTop;
            metroCheckAlwaysOnTop.Checked = _currentSettings.AlwaysOnTop;
            clickerEngine.CurrentOperatingMode = _currentSettings.ClickMode;
            metroCheckBoxRight.Checked = _currentSettings.IsRightClick;
            metroCheckBoxBoth.Checked = _currentSettings.IsBothClick;
        }

        private void RegisterCurrentHotkey()
        {
            GlobalHotkey.Unregister(this.Handle, HOTKEY_ID_TOGGLE_AUTOCLICKER);
            if (!GlobalHotkey.Register(this.Handle, HOTKEY_ID_TOGGLE_AUTOCLICKER, GlobalHotkey.Modifiers.None, _currentSettings.Hotkey))
            {
                MessageBox.Show($"Failed to register hotkey '{_currentSettings.Hotkey}'. It may be in use.", "Error");
            }
        }

        private void btnSetHotkey_Click(object sender, EventArgs e)
        {
            if (_isListeningForHotkey)
            {
                _isListeningForHotkey = false;
                btnSetHotkey.Text = $"Hotkey: {_currentSettings.Hotkey}";
            }
            else
            {
                _isListeningForHotkey = true;
                btnSetHotkey.Text = "Press any key...";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (_isListeningForHotkey)
            {

                Keys newKey = e.KeyCode;
                if (newKey == Keys.ControlKey || newKey == Keys.ShiftKey || newKey == Keys.Menu) return;

                _currentSettings.Hotkey = newKey;
                btnSetHotkey.Text = $"Hotkey: {newKey}";
                _isListeningForHotkey = false;

                RegisterCurrentHotkey();
                SettingsService.SaveSettings(_currentSettings);

                e.Handled = true;
                e.SuppressKeyPress = true;

                this.ActiveControl = null;
            }
        }

        private void metroTrackBarMin_Scroll(object sender, ScrollEventArgs e)
        {
            clickerEngine.MinCps = metroTrackBarMin.Value;
            _currentSettings.MinCps = metroTrackBarMin.Value;
            metroLabelMinCpsValue.Text = metroTrackBarMin.Value.ToString();
            if (metroTrackBarMin.Value > metroTrackBarMax.Value)
            {
                metroTrackBarMax.Value = metroTrackBarMin.Value;
                metroLabelMaxCpsValue.Text = metroTrackBarMax.Value.ToString();
                clickerEngine.MaxCps = metroTrackBarMax.Value;
                _currentSettings.MaxCps = metroTrackBarMax.Value;
            }
            SettingsService.SaveSettings(_currentSettings);
        }

        private void metroTrackBarMax_Scroll(object sender, ScrollEventArgs e)
        {
            clickerEngine.MaxCps = metroTrackBarMax.Value;
            _currentSettings.MaxCps = metroTrackBarMax.Value;
            metroLabelMaxCpsValue.Text = metroTrackBarMax.Value.ToString();
            if (metroTrackBarMax.Value < metroTrackBarMin.Value)
            {
                metroTrackBarMin.Value = metroTrackBarMax.Value;
                metroLabelMinCpsValue.Text = metroTrackBarMin.Value.ToString();
                clickerEngine.MinCps = metroTrackBarMin.Value;
                _currentSettings.MinCps = metroTrackBarMin.Value;
            }
            SettingsService.SaveSettings(_currentSettings);
        }

        private void metroCheckAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = metroCheckAlwaysOnTop.Checked;
            _currentSettings.AlwaysOnTop = metroCheckAlwaysOnTop.Checked;
            SettingsService.SaveSettings(_currentSettings);
        }

        private void UpdateEngineClickModeAndRestartEngineIfNeeded()
        {
            EngineOperatingMode newMode;
            if (metroCheckBoxBoth.Checked) { newMode = EngineOperatingMode.DualIndependentTriggers; }
            else if (metroCheckBoxRight.Checked) { newMode = EngineOperatingMode.RightTriggerSimulatesRight; }
            else { newMode = EngineOperatingMode.LeftTriggerSimulatesLeft; }

            if (clickerEngine.CurrentOperatingMode != newMode)
            {
                bool wasEngineActuallyEnabled = clickerEngine.IsEnabled;
                if (wasEngineActuallyEnabled) clickerEngine.Stop();

                clickerEngine.CurrentOperatingMode = newMode;
                _currentSettings.ClickMode = newMode;
                _currentSettings.IsRightClick = metroCheckBoxRight.Checked;
                _currentSettings.IsBothClick = metroCheckBoxBoth.Checked;
                SettingsService.SaveSettings(_currentSettings);

                if (wasEngineActuallyEnabled) clickerEngine.Start();
            }
        }

        private void metroCheckBoxRight_CheckedChanged(object sender, EventArgs e) 
        { 
            if (_isUpdatingClickTypeCheckboxes) 
                return; 
            _isUpdatingClickTypeCheckboxes = true; 
            if (metroCheckBoxRight.Checked) 
            { 
                metroCheckBoxBoth.Checked = false; 
            } 
            _isUpdatingClickTypeCheckboxes = false; 
            UpdateEngineClickModeAndRestartEngineIfNeeded(); 
        }

        private void metroCheckBoxBoth_CheckedChanged(object sender, EventArgs e) 
        { 
            if (_isUpdatingClickTypeCheckboxes) 
                return; 
            _isUpdatingClickTypeCheckboxes = true; 
            if (metroCheckBoxBoth.Checked) 
            { 
                metroCheckBoxRight.Checked = false; 
            } 
            _isUpdatingClickTypeCheckboxes = false; 
            UpdateEngineClickModeAndRestartEngineIfNeeded(); 
        }

        private void ToggleAutoClickerState() 
        { 
            if (clickerEngine.IsEnabled) 
            { 
                clickerEngine.Stop(); 
                picToggle.Image = Properties.Resources.statusoff; 
            } 
            else 
            { 
                clickerEngine.Start(); 
                picToggle.Image = Properties.Resources.statuson; 
            } 
        }
        
        private void Engine_CpsValueUpdated(int newCpsValue) 
        { 
            if (InvokeRequired) 
            { 
                Invoke(new Action(() => lblCpsCounter.Text = newCpsValue.ToString())); 
            } 
            else 
            { 
                lblCpsCounter.Text = newCpsValue.ToString(); 
            } 
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) 
        { 
            SettingsService.SaveSettings(_currentSettings); 
            clickerEngine.Stop(); 
            GlobalHotkey.Unregister(this.Handle, HOTKEY_ID_TOGGLE_AUTOCLICKER); 
        }
        
        protected override void WndProc(ref Message m) 
        { 
            base.WndProc(ref m); 
            if (m.Msg == WM_HOTKEY) 
            {
                if (m.WParam.ToInt32() == HOTKEY_ID_TOGGLE_AUTOCLICKER) 
                { 
                    ToggleAutoClickerState(); 
                } 
            } 
        }
        
        private void picToggle_Click(object sender, EventArgs e) 
        { 
            ToggleAutoClickerState(); 
        }
        
        private void timer1_Tick(object sender, EventArgs e) 
        { 
            clickerEngine.AppBounds = this.Bounds; 
        }
        
        private void btnToggleSettings_Click(object sender, EventArgs e) 
        { 
            if (_settingsPanelIsVisible) 
            { 
                panelSettings.Visible = false; 
                this.Height = _formHeightCompact; 
                btnToggleSettings.Text = "▼ Settings ▼"; 
                _settingsPanelIsVisible = false; 
            } 
            else 
            { 
                panelSettings.Visible = true; 
                this.Height = _formHeightExpanded; 
                btnToggleSettings.Text = "▲ Settings ▲"; 
                _settingsPanelIsVisible = true; 
            } 
        }
        
        private void label3_Click(object sender, EventArgs e) 
        {
        }
    }
}