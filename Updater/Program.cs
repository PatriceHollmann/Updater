using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updater
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args) 
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Updater updater = (Updater)Application.OpenForms["Updater"];
            var updater = new Updater();    
            updater.args = args;
           // updater.PostInit();
           Application.Run(updater);
        }
    }
}
