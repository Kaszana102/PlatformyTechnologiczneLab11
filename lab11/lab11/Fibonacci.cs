using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace lab11
{
    internal class FibonacciCalc
    {
        public TextBox FibonacciOtp;
        public TextBox FibonacciInput;
        public ProgressBar Progress;
        public int calc(int nth)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += ((object sender, DoWorkEventArgs args) => {
                BackgroundWorker worker = sender as BackgroundWorker;
                int a, b, c;                
                int i;
                a = 1;
                b = 1;
                c = 2;
                if (nth <= 2)
                {
                    args.Result = 1;
                }
                else
                {
                    int percent;
                    //Perform long running process
                    for (i = 3; i <= nth; i++)
                    {
                        a = b;
                        b = c;
                        c = a + b;
                        Thread.Sleep(200);
                        percent= i * 100/ nth;
                        worker.ReportProgress(percent);
                    }
                    args.Result = c;
                }
                
            });

            bw.ProgressChanged += ((object sender, ProgressChangedEventArgs args) => {
                //Update label in UI with progress
                Progress.Value = args.ProgressPercentage;
            });

            bw.RunWorkerCompleted += ((object sender, RunWorkerCompletedEventArgs args) => {
                //Update the user interface
                FibonacciOtp.Text = args.Result.ToString(); 
            });

            bw.WorkerReportsProgress = true;
            bw.RunWorkerAsync(nth);


            return 0;
        }
    }
}
