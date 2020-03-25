using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace NewVersion
{
    public partial class MainWindow : Form
    {
        Version newVersion;
        Version current;
        bool isUpdate = false;
        public MainWindow()
        {
            InitializeComponent();
            current = Assembly.GetExecutingAssembly().GetName().Version;
            this.label1.Text = current.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProgrammUpdate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progress_download.Value = e.ProgressPercentage;
        }
        public void ProgrammUpdate()
        {
            string filename = "http://localhost/Y:/new/test.exe";
            //string filename = @"localhost/Y:/new/test.exe"; http://localhost/Y:/new/test.exe
            Assembly assem = Assembly.ReflectionOnlyLoadFrom(filename);
            AssemblyName assemName = assem.GetName();
            newVersion = assemName.Version;
            //current = Assembly.GetExecutingAssembly().GetName().Version;
            if (!newVersion.Equals(current))
            {
                isUpdate = true;
                Process.Start("Updater");
                // Updater up = new Updater();
                // Application.Run(up);
                this.Close();
                //Application.Exit();
            }
        }
    }
}
