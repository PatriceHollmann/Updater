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
using NewVersion;

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
            NewVersion newVersion = new NewVersion();
            using (WebClient client = new WebClient())
            {
                client.DownloadFile("http://localhost/Y:/new", "test.exe");
                client.UploadFile("http://localhost/Y:", "test.exe");
            }
            Application.Run(newVersion);
            this.Close();
        }
    }
}
