using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO; // for file reading
using System.Collections; // for file reading
using System.Net; // needed for net controls
using HtmlAgilityPack; //for for web client w/ cookies
using NAudio; // for the mp3 shit
using NAudio.Wave; // for the mp3 shit
using FADownloader.Properties; // for saving
using Newtonsoft.Json; // for json saving

namespace FADownloader
{
    public partial class MULTITHREAD_REFERENCE
    {
        private void STRINGEXAMPLE() {
            //Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            //));
        }

        // Set global for worker
        BackgroundWorker BW = new BackgroundWorker();        // Set Status Indicator Background worker

        // Set up threads on UI launch
        private void setUpThreadSubs()
        {
            BW.DoWork // Sub to threaded background worker Run
                += (obj, e) => BW_Run();

            BW.RunWorkerCompleted // Sub to threaded background worker Completed
                    += (obj, e) => BW_Completed();
        }

        // Check if worker is busy, argument used to set thread
        public void BW_launch( BackgroundWorker BW)
        {
            if (!BW.IsBusy)
                BW.RunWorkerAsync();
            else
                Logger.logDebug("Can't run " + BW + " twice!");
        }

        // Launcher for specific BW
        public void specificBW_launch()
        {
            BW_launch(BW);
        }

        // Code that runs when worker is begun (threaded)
        public void BW_Run()
        {
            if (Thread.CurrentThread.Name == null)
                Thread.CurrentThread.Name = "BW";

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug(" Background Worker running")
                ));

            if (HTMLHandler.connectedToFA)
            {

            }
            else
            {
                //setConnectionUI(HTMLHandler.connectedToFA, HTMLHandler.FAOnlineStatus);
            }
        }

        // Code that runs when worker has completed (no longer threaded)
        public void BW_Completed()
        {
            Logger.logDebug(" Background Worker completed");
        }
    }
}

