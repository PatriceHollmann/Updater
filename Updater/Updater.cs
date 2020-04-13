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
using System.IO;
using System.Threading;

namespace Updater
{
    delegate void MyEventHandler();
    public partial class Updater : Form
    {
        public string[] args;
        public Updater()
        {
            InitializeComponent();
           
            timer1.Enabled = true;
        }
        public void StartUpdate()
        {
            /*
            using (WebClient client = new WebClient())
            {
                try
                {        
                    client.DownloadFile(@"C:\Users\User\source\repos\IEnumerable\IEnumerable\bin\Debug", "IEnumerable.exe");
                   // client.DownloadFile("http://localhost/Y:/new", "test.exe");
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    client.DownloadFileCompleted += Client_DownloadFileCompleted;
                    //client.UploadFile("http://localhost/Y:", "test.exe");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Could not download file: " + ex.Message);
                }
            }*/ 
        }
        //private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        //{
        //    StartNewVersionApp();
        //}

        private void StartNewVersionApp()
        {
            //var exePath = @"C:\Users\User\source\repos\NewVersion\NewVersion\bin\Debug\NewVersion.exe";
            //if (args.Length >0) 
            //{
            //    exePath = args[0];
            //}
            Process.Start(args[0]);
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            StartNewVersionApp();
            this.Close();
        }
    }
}
