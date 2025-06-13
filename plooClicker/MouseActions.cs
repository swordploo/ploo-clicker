using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.CodeDom;

namespace plooClicker
{
    internal static class MouseActions
    {
        // import 'mouse_event' func from user32.dll lib
        [DllImport("user32.dll")]
        public static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

        [StructLayout(LayoutKind.Sequential)]
        internal struct INPUT
        {
            public uint type;
            public InputUnion u;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct InputUnion
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        // input type consts
        private const int INPUT_MOUSE = 0;


        // const values for mouse event flags
        private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        private const uint MOUSEEVENTF_LEFTUP = 0x04;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const uint MOUSEEVENTF_RIGHTUP = 0x10;

        /// <summary>
        /// simulates a single lmb click (down n up)
        /// </summary>
        
        public static void LeftClick()
        {
            INPUT[] inputs = new INPUT[]
            {
                // mouse down event
                new INPUT
                {
                    type = INPUT_MOUSE,
                    u = new InputUnion
                    {
                        mi = new MOUSEINPUT
                        {
                            dwFlags = MOUSEEVENTF_LEFTDOWN,
                            // secret handshake on click so the clicker doesnt stop itself from our simulated mouse button up
                            dwExtraInfo = MouseHook.ScopedSignature
                        }
                    }
                },
                // mouse up event
                new INPUT
                {
                    type = INPUT_MOUSE,
                    u = new InputUnion
                    {
                        mi = new MOUSEINPUT
                        {
                            dwFlags = MOUSEEVENTF_LEFTUP,
                            // secret handshake on click so the clicker doesnt stop itself from our simulated mouse button up
                            dwExtraInfo = MouseHook.ScopedSignature
                        }
                    }
                }
            };

            // send array of inputs to OS
            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
        }

        public static void RightClick()
        {
            INPUT[] inputs = new INPUT[]
            {
                new INPUT
                {
                    type = INPUT_MOUSE,
                    u = new InputUnion
                    {
                        mi = new MOUSEINPUT
                        {
                            dwFlags = MOUSEEVENTF_RIGHTDOWN,
                            dwExtraInfo = MouseHook.ScopedSignature
                        }
                    }
                },
                new INPUT
                {
                    type = INPUT_MOUSE,
                    u = new InputUnion
                    {
                        mi = new MOUSEINPUT
                        {
                            dwFlags = MOUSEEVENTF_RIGHTUP,
                            dwExtraInfo = MouseHook.ScopedSignature
                        }
                    }
                }
            };

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
        }

        public static void BothClick()
        {
            INPUT[] inputs = new INPUT[]
            {
                // press left down
                new INPUT
                {
                    type = INPUT_MOUSE,
                    u = new InputUnion
                    {
                        mi = new MOUSEINPUT
                        {
                            dwFlags = MOUSEEVENTF_LEFTDOWN,
                            dwExtraInfo = MouseHook.ScopedSignature
                        }
                    }
                },
                
                // press right down
                new INPUT
                {
                    type = INPUT_MOUSE,
                    u = new InputUnion
                    {
                        mi = new MOUSEINPUT
                        {
                            dwFlags = MOUSEEVENTF_RIGHTDOWN,
                            dwExtraInfo = MouseHook.ScopedSignature
                        }
                    }
                },

                // release left up
                new INPUT
                {
                    type = INPUT_MOUSE,
                    u = new InputUnion
                    {
                        mi = new MOUSEINPUT
                        {
                            dwFlags = MOUSEEVENTF_LEFTUP,
                            // secret handshake on click so the clicker doesnt stop itself from our simulated mouse button up
                            dwExtraInfo = MouseHook.ScopedSignature
                        }
                    }
                },

                // release right up
                new INPUT
                {
                    type = INPUT_MOUSE,
                    u = new InputUnion
                    {
                        mi = new MOUSEINPUT
                        {
                            dwFlags = MOUSEEVENTF_RIGHTUP,
                            dwExtraInfo = MouseHook.ScopedSignature
                        }
                    }
                }
            };

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
        }
    }
}
