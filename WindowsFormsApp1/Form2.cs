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
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //API Call 1 Report progress.  
            backgroundWorker1.ReportProgress(1);



            //API Call 2 Report progress.  
            Thread.Sleep(2000);
            backgroundWorker1.ReportProgress(2);


            //API Call 3 Report progress.  
            Thread.Sleep(2000);
            backgroundWorker1.ReportProgress(3);



            //API Call 4 Report progress.  
            Thread.Sleep(2000);
            backgroundWorker1.ReportProgress(4);

            //API Call 5 Report progress.  
            Thread.Sleep(2000);
            backgroundWorker1.ReportProgress(5);


            //API Call 6 Report progress.  
            Thread.Sleep(2000);
            backgroundWorker1.ReportProgress(6);

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {           
            label1.Text = "API Service CALL: " + e.ProgressPercentage.ToString();
            if (e.ProgressPercentage == 6)
            {
                this.Close();
            }
        }
    }
}
