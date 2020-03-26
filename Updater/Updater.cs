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
                try
                {
                    client.DownloadFile("http://localhost/Y:/new", "test.exe");
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    client.UploadFile("http://localhost/Y:", "test.exe");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Could not download file: " + ex.Message);
                }
            }
            Process.Start("NewVersion");
            this.Close();
        }
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    }
}
