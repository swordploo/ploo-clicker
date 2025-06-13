using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace plooClicker
{
    internal static class GlobalHotkey
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public enum Modifiers : uint
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Win = 8
        }

        // registers global hotkey with windows
        public static bool Register(IntPtr hWnd, int id, Modifiers modifiers, Keys key)
        {
            return RegisterHotKey(hWnd, id, (uint)modifiers, (uint)key);
        }

        
        // Unregisters a previously registered global hotkey.
        public static bool Unregister(IntPtr hWnd, int id)
        {
            return UnregisterHotKey(hWnd, id);
        }
    }
}
