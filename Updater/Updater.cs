using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Updater
{
    public partial class Updater : Form
    {
        public Updater()
        {
            InitializeComponent();
        }
        public void StartUpdate()
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile("http://localhost/Y:/new", "test.exe");
                client.UploadFile("http://localhost/Y:", "test.exe");
            }
            //Application.Run(newVersion);
            Process.Start("NewVersion");
            this.Close();
        }
    }
}
