using System.Windows.Forms;

namespace plooClicker
{
    public class AppSettings
    {
        public int MinCps { get; set; } = 8;
        public int MaxCps { get; set; } = 12;
        public Keys Hotkey { get; set; } = Keys.K;
        public bool AlwaysOnTop { get; set; } = false;
        public EngineOperatingMode ClickMode { get; set; } = EngineOperatingMode.LeftTriggerSimulatesLeft;
        public bool IsRightClick { get; set; } = false;
        public bool IsBothClick { get; set; } = false;
    }
}