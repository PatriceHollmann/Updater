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

        public void ProgrammUpdate()
        {
            string filename = @"C:\Users\User\Documents\вент.tgml"; //test
            //string filename = "http://localhost/Y:/new/test.exe";
            //string filename = @"localhost/Y:/new/test.exe"; http://localhost/Y:/new/test.exe
            try
            {
                Assembly assem = Assembly.ReflectionOnlyLoadFrom(filename);
                AssemblyName assemName = assem.GetName();
                newVersion = assemName.Version;
                if (!newVersion.Equals(current))
                {
                    isUpdate = true;
                    Process.Start("Updater");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not download file: " + ex.Message);
            }
        }
    }
}
