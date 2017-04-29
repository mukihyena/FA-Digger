////////////
// Logger // - PervDragon/MukiHyena
////////////
/*
    // Handles logging
*/


// Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FADownloader
{
    static class Logger
    {

        //Globals
        public static bool debugLogging = false;
        public static bool errorLogging = false;
        public static bool downloadLogging = false;
        public static bool statusLogging = false;
        public delegate void threadCallBackLog(string text);



        /// <summary>
        /// Print log to file (not yet implemented)
        /// </summary>
        public static void printLog()
        {
            //FileInfo logFile = new FileInfo();

        }



        /// <summary>
        /// Logs debug to console
        /// </summary>
        /// <param name="logString"></param>
        public static void logDebug(string logString)
        {
            if (debugLogging)
            {
                output("::Debug:: " + logString);
            }
        }



        /// <summary>
        /// Logs errors to console
        /// </summary>
        /// <param name="logString"></param>
        public static void logError(string logString)
        {
            string outputErrorMessage =
            "!!!!!!!!!!!ERROR!!!!!!!!!!!";

            if (errorLogging)
            {
                output(outputErrorMessage);
                output("::Error:: " + logString);
                output(outputErrorMessage);
            }
        }



        /// <summary>
        /// Logs download status to console
        /// </summary>
        /// <param name="logString"></param>
        public static void logDownload(string logString)
        {
            if (downloadLogging)
            {
                output("::Downloading::" + logString);
            }
        }



        /// <summary>
        /// Logs general status to console
        /// </summary>
        /// <param name="logString"></param>
        public static void logStatus(string logString)
        {
            if (statusLogging)
            {
                output("::Status::" + logString);
            }
        }


        ////can condense these
        //public static void output(string outputString)
        //{
        //    string time = DateTime.Now.ToShortTimeString();

        //    lock (Program.mainForm.lbOutput)
        //    {
        //        //lbOutput.Items.Add(logString);
        //        Program.mainForm.lbOutput.Items.Add(time + ": " + outputString);
        //    }
        //}


        // combining with output
        /*public static void threadOutput(string text)
        {
            if (Program.mainForm.lbOutput.InvokeRequired)
            {
                threadCallBackLog invokeThis = new threadCallBackLog(threadOutput);
                Program.mainForm.Invoke(invokeThis, new object[] { text });
            }
            else
            {
                Program.mainForm.lbOutput.Items.Add(text);
            }
        }*/



        /// <summary>
        /// Outputs to console and theoretically handles outputting on separate threads
        /// </summary>
        /// <param name="outputString"></param>
        private static void output(string outputString)
        {
            string time = DateTime.Now.ToShortTimeString();
            string finalOutput = (time + ": " + outputString);

            lock (Program.mainForm.lbOutput)
            {
                // If called from new thread, do invoke and all that shit
                if (Program.mainForm.lbOutput.InvokeRequired)
                {
                    threadCallBackLog invokeThis = new threadCallBackLog(output);
                    Program.mainForm.Invoke(invokeThis, new object[] { finalOutput });
                }
                // otherwise, call normally
                else
                {
                    Program.mainForm.lbOutput.Items.Add(finalOutput);
                }
            }
            Program.mainForm.lbOutput.SelectedIndex = Program.mainForm.lbOutput.Items.Count - 1;
            Program.mainForm.lbOutput.SelectedIndex = -1;
        }
    }
}
