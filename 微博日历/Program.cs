using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using System.Net.Http;

namespace 微博日历
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");

            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
