using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public static string ServiceResult = "InProgress";
        string statusText = "";
        string[] statusValues = new string[] { "Running 1", "Running 2", "Running 3", "Running 4", "Running 5", "Running 6", "Running 7", "Running 8", "Running 9", "Running 10", "Running 11" };
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Task<bool> task = Method1();
            foreach (string status in statusValues)
            {
                Thread.Sleep(1000);
                statusText = status;
                backgroundWorker1.ReportProgress(1);
            }

        }
        public static async Task<bool> Method1()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(10000);
                ServiceResult = "Completed";
            });
            return true;
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label1.Text = statusText;
            if (ServiceResult == "Completed")
            {
                this.Close();           
            }
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
