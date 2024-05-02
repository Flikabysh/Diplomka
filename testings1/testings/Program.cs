using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diplomatik
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (testings.Properties.Settings.Default.voshol == false)
            {
                Application.Run(new Form1());
            }
            else
            {
                Application.Run(new MainForm());
            }
        }
    }
}
