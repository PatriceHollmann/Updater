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
            //string filename = @"C:\Users\User\source\repos\IEnumerable\IEnumerable\bin\Debug\IEnumerable.exe"; //test
            ////string filename = @"Y:/new/test.exe";
            try
            {
                //    Assembly assem = Assembly.ReflectionOnlyLoadFrom(filename);
                //    AssemblyName assemName = assem.GetName();
                //    newVersion = assemName.Version;
                //    if (!newVersion.Equals(current))
                //    {
                //        isUpdate = true;
                
                var exePath = SearchExe("Updater");
                    var currentPath = Path.GetFullPath("./")+"/NewVersion.exe";
                    Process.Start(exePath,currentPath);
                    this.Close();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not download file: " + ex.Message);
            }
        }
        public string SearchExe(string exeName)
        {
            var currentPath = Path.GetFullPath("./");
            var fileSearcher = new FileSearcher(currentPath);
            var findItem = fileSearcher.Search(exeName);
            return findItem;
        }
    }
    public class FileSearcher
    {
        string currentPath;
        List<FileInfo> findedItems = new List<FileInfo>();
        
        public FileSearcher(string currentPath)
        {
            this.currentPath = currentPath;
        }
        public string Search(string exeName)
        {
            SearchInDirectory(new DirectoryInfo(currentPath), exeName, null,true);
            if (findedItems.Count == 0)
            {
                return null;
            }
            return findedItems.OrderByDescending(a => a.CreationTime).First().FullName;
        }
        public void SearchInDirectory(DirectoryInfo directory, string exeName, string exceptionDirectory,bool flag)
        {
            var folder = directory.Name;
            var files = directory.GetFiles(exeName + ".exe");
           
            // --Parent Folder 
            //   --child 1 

            //Call 1 
            //Call 2

            if (files.Length != 0)
            {
                this.findedItems.Add(files[0]);
            }
                foreach (var item in directory.GetDirectories())
                {
                    if (item.Name != exceptionDirectory)
                    {
                         SearchInDirectory(item, exeName, null,false);
                    }
                }
                if (flag&&findedItems.Count==0)
                {
                    SearchInDirectory(directory.Parent, exeName, directory.Name,true);  
                }
        }
    }
}
