using System;
using System.Windows.Forms;

namespace plooClicker
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            using (new TimeResolutionHelper())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
