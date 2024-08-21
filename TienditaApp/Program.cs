using Microsoft.VisualBasic.Logging;
using System;
using System.Windows.Forms;
using View;

namespace TienditaApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
