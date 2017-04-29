/////////////////////////////
// Downloader UI Main Form // - PervDragon/MukiHyena
/////////////////////////////

/*
UI code goes here
*/

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
using System.Security.Permissions; // overriding controls
using mshtml; // show captcha

namespace FADownloader
{
    public partial class downloaderForm : Form
    {
        //////////////////////
        // GLOBAL VARIABLES //
        //////////////////////

        #region
        // Version info
        public static string version = "beta alpha delta 1";

        // Net UI shit
        public static string currentImage;
        public static string currentSoundClip;
        public static string liveInfoURL
            = "https://dl.dropboxusercontent.com/u/50590573/Projects/Code/FADigger/current_info";
        public static string liveMOTDURL
            = "https://dl.dropboxusercontent.com/u/50590573/Projects/Code/FADigger/current_motd";
        public static string liveMOTDLinkText =
            "https://dl.dropboxusercontent.com/u/50590573/Projects/Code/FADigger/current_motdlinktext";
        public static string liveMOTDLinkURL =
            "https://dl.dropboxusercontent.com/u/50590573/Projects/Code/FADigger/current_motdlinkurl";

        // Cookie container
        public static CookieContainer userCookies = new CookieContainer();

        // Background workers
        //private delegate void DELEGATE(); // do I really need this delegate
        BackgroundWorker CFAOSBW = new BackgroundWorker();      //Check FurAffinity Online Status Background Worker
        BackgroundWorker URBW = new BackgroundWorker();        // Update Rows Background worker
        BackgroundWorker WLIBW = new BackgroundWorker();        // Watch List Import Background worker
        BackgroundWorker SSIBW = new BackgroundWorker();        // Set Status Indicator Background worker
        BackgroundWorker SSIABW = new BackgroundWorker();        // Set Status Indicator Background worker
        BackgroundWorker WFCBW = new BackgroundWorker();          // Wait for Captcha thread Background Worker
        BackgroundWorker DLBW = new BackgroundWorker();          // Downloader Background Worker
        BackgroundWorker ASBW = new BackgroundWorker();         // Audio Stream Background Worker
        BackgroundWorker UPBBW = new BackgroundWorker();         // Audio Stream Background Worker

        //Login
        private static bool showPassword = false;

        // ???DELETE??? - Settings File
        private static string artistFile = "C:/Users/Garrett/Dropbox/Private/Projects/Code/artists.txt";
        private static string filterFile = "C:/Users/Garrett/Dropbox/Private/Projects/Code/filter.txt";
        private static string fileToParse = "";

        // Artist List variables
        private static int[] bottomLineColumnsToDisable = { 0, 2, 3, 4, 5 }; // bottom linie columns to disable
        private static int[] columnsToEnable = { 2, 3, 4, 5, };              // columns to re-enable
        ArrayList rowIndexes = new ArrayList();                             // Index grabbed from total lines, used for name verification
        private List<DataGridViewRow> rowsToDelete;                         // list of rows to delete
        private HashSet<string> existingValues = new HashSet<string>();     // Temp hashset for comparison
        public static bool isClosing = false;                               // Check if program is closing

        // Download settings
        public static bool createArtistSubfolder = false;       // move to download handler?
        public static bool createGalleryTypeSubfolder = false;  // move to download handler?
        #endregion

        ////////////
        // SYSTEM //
        ////////////

        #region
        /// <summary>
        /// ENTRY
        /// </summary>
        public downloaderForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ON LOAD COMMANDS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downloaderForm_Load(object sender, EventArgs e)
        {
            setupComboBoxSelections(); // have to do this before loading settings...
            loadSettings();
            setUpBWSubs();
            //checkFAOnlineStatus(); // moving to when the form is shown. slower, but looks cooler
            tbPassword.PasswordChar = '+';
            importArtistList();
            AddBottomRow(); // THCOLD
            setArtistListVisuals();
            setLoadUI();
            setlbOutputWordWrap();
            setImageandSoundInfo();
            autoCookieVerification();
        }

        /// <summary>
        /// ON SHOWN COMMANDS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downloaderForm_Shown(object sender, EventArgs e)
        {
            //lbOutput.Items.Clear();
            deletePotentiallyBadFile();
            CFAOSBW_Launch();
        }

        /// <summary>
        /// If we were in the middle of downloading a file when the program crashed, prompt the user
        /// </summary>
        private void deletePotentiallyBadFile()
        {
            //if (Settings.Default.potentiallyBadFile != null)
            if (File.Exists(Settings.Default.potentiallyBadFile))
            {
                MessageBox.Show("The following file may not have completed successfully "
                    + Environment.NewLine
                    + "and may be corrupt. It will be deleted from your system:"
                    + Environment.NewLine
                    + Environment.NewLine
                    + Environment.NewLine
                    + downloadHandler.potentiallyBadFile);

                while (File.Exists(downloadHandler.potentiallyBadFile))
                {
                    Logger.logStatus("Removing potentially corrupt file:");
                    Logger.logStatus(downloadHandler.potentiallyBadFile);
                    File.Delete(downloadHandler.potentiallyBadFile);
                }

                if (!File.Exists(downloadHandler.potentiallyBadFile))
                {
                    downloadHandler.potentiallyBadFile = null;
                }
                else
                {
                    Logger.logError("Problem deleting corrupt file.");
                }
            }
        }

        /// <summary>
        /// Sets up background worker subs so they don't run multiple times
        /// </summary>
        private void setUpBWSubs()
        {
            ///////////////////////////////////////////////////////
            // Check FurAffinity Online Status Background Worker //
            ///////////////////////////////////////////////////////

            CFAOSBW.DoWork // Sub to threaded background Run
                += (obj, e) =>
                CFAOSBW_Run
                (
                    HTMLHandler.connectedToFA
                    , HTMLHandler.FAOnlineStatus
                    //,DoWorkEventArgs // can I fix this?
                    );

            CFAOSBW.RunWorkerCompleted // Sub to threaded background worker Completed
                += (obj, e) =>
                CFAOSBW_Completed
                (
                    HTMLHandler.connectedToFA
                    , HTMLHandler.FAOnlineStatus
                    //,RunWorkerCompletedEventArgs  // can I fix this?
                    );

            ////////////////////////////////////////
            // Watchlist Import Background Worker //
            ////////////////////////////////////////

            URBW.DoWork // Sub to threaded background Run
                += (obj, e) => URBW_Run();

            URBW.RunWorkerCompleted // Sub to threaded background worker Completed
                += (obj, e) => URBW_Completed();

            ////////////////////////////////////////
            // Watchlist Import Background Worker //
            ////////////////////////////////////////

            WLIBW.DoWork // Sub to threaded background Run
                += (obj, e) => WLIBW_Run();

            WLIBW.RunWorkerCompleted // Sub to threaded background worker Completed
                += (obj, e) => WLIBW_Completed();

            ////////////////////////////////
            // Download Background Worker //
            ////////////////////////////////

            DLBW.DoWork // Sub to threaded background Run
                += (obj, e) => DLBW_Run();

            DLBW.RunWorkerCompleted // Sub to threaded background worker Completed
                += (obj, e) => DLBW_Completed();

            ////////////////////////////////////////////
            // Set Status Indicator Background Worker //
            ////////////////////////////////////////////

            SSIBW.DoWork // Sub to threaded background Run
                += (obj, e) => SSIBW_Run();

            SSIBW.RunWorkerCompleted // Sub to threaded background worker Completed
                += (obj, e) => SSIBW_Completed();

            ////////////////////////////////////////////
            // Set Status Indicator Background Worker //
            ////////////////////////////////////////////

            //SSIABW.DoWork // Sub to threaded background Run
            //    += (obj, e) => SSIABW_Run();

            //SSIABW.RunWorkerCompleted // Sub to threaded background worker Completed
            //    += (obj, e) => SSIABW_Completed();

            ////////////////////////////////////////
            // Wait for Captcha Background Worker //
            ////////////////////////////////////////

            WFCBW.DoWork // Sub to threaded background Run
                += (obj, e) => WFCBW_Run();

            WFCBW.RunWorkerCompleted // Sub to threaded background worker Completed
                += (obj, e) => WFCBW_Completed();

            ////////////////////////////////////
            // Audio Stream Background Worker //
            ////////////////////////////////////

            ASBW.DoWork // Sub to threaded background Run
                += (obj, e) => ASBW_Run();

            ASBW.RunWorkerCompleted // Sub to threaded background worker Completed
                += (obj, e) => ASBW_Completed();

            ////////////////////////////////////
            // Audio Stream Background Worker //
            ////////////////////////////////////

            UPBBW.DoWork // Sub to threaded background Run
                    += (obj, e) => UPBBW_Run
                    (downloadHandler.downloadedImage);

            UPBBW.RunWorkerCompleted // Sub to threaded background worker Completed
                    += (obj, e) => UPBBW_Completed
                    (downloadHandler.downloadedImage);
        }

        /// <summary>
        /// Checks if Background Worker is busy before launching
        /// </summary>
        /// <param name="BW"></param>
        public void BW_Launch(BackgroundWorker BW)
        {
            if (!BW.IsBusy)
            {
                BW.RunWorkerAsync();
            }
            else
            {
                Logger.logDebug("Can't run " + BW + " twice!");
                Logger.logStatus("That action is already running, "
                    + "please wait until completion and try again.");
            }
        }

        /// <summary>
        /// ???DELETE???SETTINGS FILE BULLSHIT
        /// </summary>
        public void parseFileByLine()
        {
            Logger.logStatus("Parsing file for contents...");
        }

        /// <summary>
        /// ???DELETE???SETTINGS FILE BULLSHIT
        /// </summary>
        public void readArtistFile()
        {
            Logger.logStatus("Reading Artist file.");
            fileToParse = artistFile;
            parseFileByLine();
        }

        /// <summary>
        /// ???DELETE???SETTINGS FILE BULLSHIT
        /// </summary>
        public void readFilterFile()
        {
            Logger.logStatus("Reading Filter file.");
            fileToParse = filterFile;
            parseFileByLine();
        }

        // source: http://stackoverflow.com/questions/17613613/are-there-anyway-to-make-listbox-items-to-word-wrap-if-string-width-is-higher-th
        /// <summary>
        /// Set up List Box Word Wrap
        /// </summary>
        public void setlbOutputWordWrap()
        {
            //lbOutput.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            //lbOutput.MeasureItem += lbOutput_MeasureItem;
            //lbOutput.DrawItem += lbOutput_DrawItem;
        }

        // source: http://stackoverflow.com/questions/17613613/are-there-anyway-to-make-listbox-items-to-word-wrap-if-string-width-is-higher-th
        /// <summary>
        /// Set up List Box Word Wrap - Measure Item
        /// </summary>
        private void lbOutput_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            //e.ItemHeight = (int)e.Graphics.MeasureString(lbOutput.Items[e.Index].ToString(), lbOutput.Font, lbOutput.Width).Height;
        }

        // source: http://stackoverflow.com/questions/17613613/are-there-anyway-to-make-listbox-items-to-word-wrap-if-string-width-is-higher-th
        /// <summary>
        /// Set up List Box Word Wrap - Draw Item
        /// </summary>
        private void lbOutput_DrawItem(object sender, DrawItemEventArgs e)
        {
            //e.DrawBackground();
            //e.DrawFocusRectangle();
            //e.Graphics.DrawString(lbOutput.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }

        /// <summary>
        /// Set default image and sound for picture box
        /// </summary>
        public void setImageandSoundInfo()
        {
            HTMLHandler.setPictureBox();
            currentImage = HTMLHandler.currentImage;
            currentSoundClip = HTMLHandler.currentSoundClip;
            pbPreview.ImageLocation = currentImage;
            lblLiveInfo.Text = HTMLHandler.readOnlineText(liveInfoURL);
            lblLiveMOTD.Text = HTMLHandler.readOnlineText(liveMOTDURL);
            lnklblLiveMOTDLink.Text = HTMLHandler.readOnlineText(liveMOTDLinkText);

            if (HTMLHandler.readOnlineText(liveMOTDLinkText) == null
                || HTMLHandler.readOnlineText(liveMOTDURL) == null)
            {
                lnklblLiveMOTDLink.Visible = false;
            }

            //lblInfo.Text =
            //    File.ReadAllText
            //    ("https://dl.dropboxusercontent.com/u/50590573/Projects/Code/FADigger/info.txt");
        }

        /// <summary>
        /// MOTD Link Lable clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnklblLiveMOTDLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (HTMLHandler.readOnlineText(liveMOTDLinkText) != null
                || HTMLHandler.readOnlineText(liveMOTDURL) != null)
            {
                System.Diagnostics.Process.Start(HTMLHandler.readOnlineText(liveMOTDLinkURL));
            }
        }

        public void setupComboBoxSelections()
        {
            cbDownloadMethod.Items.Add("Download files when they're found");
            cbDownloadMethod.Items.Add("Dig all pages then download files");
        }

        /// <summary>
        /// Sets Loading UI - hides FA options while checking site status
        /// </summary>
        public void setLoadUI()
        {
            //hide all FA options

            lblLoginInfo.Visible = false;
            lblUsername.Visible = false;
            lblPassword.Visible = false;
            tbUsername.Visible = false;
            tbPassword.Visible = false;
            btnLogin.Visible = false;
            cbLogInOnLaunch.Visible = false;
            cbShowPassword.Visible = false;
            lblLoginStatus.Visible = false;
            lblRatings.Visible = false;
            cbAllFARatings.Visible = false;
            cbGeneral.Visible = false;
            cbMature.Visible = false;
            cbAdult.Visible = false;

            // Show the connecting lable in the FA options
            gbFAConnectionStatus.Visible = true;
            lblFAConnectionStatus.Visible = true;
            //btnAttemptReconnection.Visible = false;

            // Set Logged In lable
            this.lblLoginStatus.ForeColor = Color.White;
            this.lblLoginStatus.Text = "You are not logged in.";

            // Set enabled status
            cbAllFARatings.Enabled = HTMLHandler.loggedIn;
            cbMature.Enabled = HTMLHandler.loggedIn;
            cbAdult.Enabled = HTMLHandler.loggedIn;
            btnImportWatchList.Enabled = HTMLHandler.loggedIn;

            // Set checked ratings
            cbAllFARatings.Checked = HTMLHandler.loggedIn;
            cbMature.Checked = HTMLHandler.loggedIn;
            cbAdult.Checked = HTMLHandler.loggedIn;
        }

        // MOVE TO APPROPRIATE AREAS?
        /// <summary>
        /// Set UI based on state
        /// </summary>
        public void setUI()
        {

            // set FA UI
            tbUsername.Enabled = !downloadHandler.runningDownloadProcess;
            tbPassword.Enabled = !downloadHandler.runningDownloadProcess;
            btnLogin.Enabled = !downloadHandler.runningDownloadProcess;

            cbAllFARatings.Enabled = !downloadHandler.runningDownloadProcess;
            cbGeneral.Enabled = !downloadHandler.runningDownloadProcess;
            cbMature.Enabled = !downloadHandler.runningDownloadProcess;
            cbAdult.Enabled = !downloadHandler.runningDownloadProcess;

            // set artist UI
            dgvArtistList.Enabled = !downloadHandler.runningDownloadProcess;

            btnSelectNone.Enabled = !downloadHandler.runningDownloadProcess;
            btnSelectAll.Enabled = !downloadHandler.runningDownloadProcess;

            cbGallery.Enabled = !downloadHandler.runningDownloadProcess;
            cbScraps.Enabled = !downloadHandler.runningDownloadProcess;
            cbFavorites.Enabled = !downloadHandler.runningDownloadProcess; ;
            cbJournals.Enabled = !downloadHandler.runningDownloadProcess;
            btnArtistApplyDownloads.Enabled = !downloadHandler.runningDownloadProcess; // change name to button
            btnRemoveArtists.Enabled = !downloadHandler.runningDownloadProcess;
            btnImportWatchList.Enabled = !downloadHandler.runningDownloadProcess;

            // set filter UI
            lbFilter.Enabled = !downloadHandler.runningDownloadProcess;

            tbAddToFilter.Enabled = !downloadHandler.runningDownloadProcess;
            cbFilterKeywords.Enabled = !downloadHandler.runningDownloadProcess;
            cbFilterDescription.Enabled = !downloadHandler.runningDownloadProcess;
            cbFilterComments.Enabled = !downloadHandler.runningDownloadProcess;
            cbFilterSubmissionTitle.Enabled = !downloadHandler.runningDownloadProcess;
            cbFilterFileName.Enabled = !downloadHandler.runningDownloadProcess;

            // set download options
            tbDownloadDirectory.Enabled = !downloadHandler.runningDownloadProcess;
            btnFolderSelect.Enabled = !downloadHandler.runningDownloadProcess;
            cbSubfolderByArtistName.Enabled = !downloadHandler.runningDownloadProcess;
            cbSubfolderBySubmissionType.Enabled = !downloadHandler.runningDownloadProcess;
            cbOverwrite.Enabled = !downloadHandler.runningDownloadProcess;
            btnDownload.ForeColor = Color.ForestGreen;
            btnDownload.Text = "DOWNLOAD";
        }

        /// <summary>
        /// Empty function needed for tooltip to work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
        #endregion

        ///////////////////////////////////
        // FA ONLINE STATUS CHECK THREAD // (CFAOS)
        ///////////////////////////////////

        #region
        /// <summary>
        /// Check FA Online Status (CFAOS)
        /// </summary>
        public void CFAOSBW_Launch()
        {
            Logger.logStatus(Strings.attemptconnection);
            lblStatus.ForeColor = Color.Orange;
            lblStatus.Text = (Strings.attemptconnection);
            lblFAConnectionStatus.ForeColor = Color.Orange;
            lblFAConnectionStatus.Text = (Strings.attemptconnection);

            BW_Launch(CFAOSBW);
        }

        /// <summary>
        /// !!! SET UP ARGS !!! CFAOS Background Worker running
        /// </summary>
        /// <param name="connectedToFA"></param>
        /// <param name="FAOnlineStatus"></param>
        public void CFAOSBW_Run
            (
            bool connectedToFA
            , string FAOnlineStatus
            //,DoWorkEventArgs e // can I fix this?
            )
        {
            if (Thread.CurrentThread.Name == null)
            {
                Thread.CurrentThread.Name = "CFAOSBW";
            }
            connectedToFA = false;

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("Check FurAffinity Online Status Background Worker running")
            ));

            HTMLHandler.checkFAOnlineStatus(); // unthreaded

            //Delegate del = new DELEGATE(CFAOSBW_Work);
            //this.Invoke(del);
        }

        /// <summary>
        /// !!! SET UP ARGS !!! CFAOS Background Worker completed
        /// </summary>
        public void CFAOSBW_Completed
            (
            bool connectedToFA
            , string FAOnlineStatus
            //,runWorkerCompleteEventArgs e // can I fix this?
            )
        {
            Logger.logDebug("Check FurAffinity Online Status Background Worker completed");

            setConnectionUI(connectedToFA, FAOnlineStatus);
        }

        /// <summary>
        /// Set UI based on CFAOS
        /// </summary>
        /// <param name="connectedToFA"></param>
        /// <param name="FAOnlineStatus"></param>
        public void setConnectionUI(bool connectedToFA, string FAOnlineStatus)
        {
            HTMLHandler.FAOnlineStatus = FAOnlineStatus;    // Set variables in html handler
            HTMLHandler.connectedToFA = connectedToFA;      // Set variables in html handler

            Logger.logDebug("Setting UI based on connection status");
            string FAonlineStatusString = "FurAffinity is " + FAOnlineStatus;

            if (HTMLHandler.connectedToFA)
            {
                lblStatus.ForeColor = Color.LightGreen;

                if (HTMLHandler.FAOnlineStatus == "read only")
                {
                    lblStatus.ForeColor = Color.Orange;
                }
            }

            else if (!HTMLHandler.connectedToFA)
            {
                lblStatus.ForeColor = Color.IndianRed;
            }

            Logger.logStatus(FAonlineStatusString);

            //gbLogin.Enabled = connectedToFA;
            lblStatus.Text = FAonlineStatusString;
            // lblStatus.Text = (Strings.FAOnlineStatus); // broken?? why?? strings look right

            // Artist list
            btnImportWatchList.Visible = HTMLHandler.connectedToFA;

            // Download button
            btnDownload.Visible = HTMLHandler.connectedToFA;

            // FA Options info lable
            lblLoginInfo.Visible = HTMLHandler.connectedToFA;

            // login stuff
            lblUsername.Visible = HTMLHandler.connectedToFA;
            lblPassword.Visible = HTMLHandler.connectedToFA;
            tbUsername.Visible = HTMLHandler.connectedToFA;
            tbPassword.Visible = HTMLHandler.connectedToFA;
            cbLogInOnLaunch.Visible = HTMLHandler.connectedToFA;
            cbShowPassword.Visible = HTMLHandler.connectedToFA;
            btnLogin.Visible = HTMLHandler.connectedToFA;
            lblLoginStatus.Visible = HTMLHandler.connectedToFA;

            // ratings
            lblRatings.Visible = HTMLHandler.connectedToFA;
            cbAllFARatings.Visible = HTMLHandler.connectedToFA;
            cbGeneral.Visible = HTMLHandler.connectedToFA;
            cbMature.Visible = HTMLHandler.connectedToFA;
            cbAdult.Visible = HTMLHandler.connectedToFA;

            // reconnection stuff in login area
            gbFAConnectionStatus.Visible = !HTMLHandler.connectedToFA;
            btnAttemptReconnection.Visible = !HTMLHandler.connectedToFA; // sleep to prevent too many hits
            lblFAConnectionStatus.Visible = !HTMLHandler.connectedToFA;
            lblFAConnectionStatus.ForeColor = Color.IndianRed;
            lblFAConnectionStatus.Text = FAonlineStatusString;
            //lblFADown.Text = (Strings.FAOnlineStatus); // broken?? why?? strings look right

            // check boxes user has checked in their settings

            if (HTMLHandler.connectedToFA)
            {
                //autoLogInCheck();
                //autoCookieVerification();
                HTMLHandler.overWriteStatuses = false;
                SSIBW_Launch();
            }
        }

        /// <summary>
        /// Attempt Reconnection button - runs CFAOS - appears in FA Settings if FA is offline
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAttemptReconnection_Click(object sender, EventArgs e)
        {
            Logger.logDebug("Button clicked");
            CFAOSBW_Launch();
        }
        #endregion

        /////////////////////
        // ARTIST SETTINGS //
        /////////////////////

        #region
        /// <summary>
        /// Set Artist List visuals
        /// </summary>
        public void setArtistListVisuals()
        {
            foreach (int c in bottomLineColumnsToDisable)
            {
                this.dgvArtistList.Columns[c].DefaultCellStyle.SelectionBackColor = this.dgvArtistList.DefaultCellStyle.BackColor;
                this.dgvArtistList.Columns[c].DefaultCellStyle.SelectionForeColor = this.dgvArtistList.DefaultCellStyle.ForeColor;
            }
            this.dgvArtistList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvArtistList.Columns[0].DefaultCellStyle.Font = new Font(dgvArtistList.Font, FontStyle.Bold);
        }

        /// <summary>
        /// Import Artist List from library into grid
        /// </summary>
        public void importArtistList()
        {
            // thcold
            if (Program.myArtistList == null || Program.myArtistList.Count == 0)
            {
                // Nothing to do
                Logger.logDebug("Artists list is null or empty.");
                return;
            }


            Logger.logDebug("Importing artists to artist list");
            // artist handler stuff goes here

            // Populate the rows based on existing artist list, skip existing names

            // New hashset based on names existing in rows
            existingValues = new HashSet<string>();

            // start by removing all lines
            dgvArtistList.Rows.Clear();

            // add lines for each artist in artistlist
            foreach (ArtistObject artist in Program.myArtistList.Values)
            {
                Logger.logDebug("Adding row for artist " + artist.artistName);
                dgvArtistList.Rows.Add();
                Logger.logDebug("Row count is now " + dgvArtistList.Rows.Count);
            }

            // fill lines with artist list
            foreach (DataGridViewRow row in dgvArtistList.Rows)
            {
                foreach (ArtistObject artist in Program.myArtistList.Values)
                {
                    if
                        (
                        row.Cells[1].Value == null
                        && !existingValues.Contains(artist.artistName)
                        && row.Cells[1].Value != artistName
                        )
                    {
                        row.Cells[1].Value = artist.artistName;
                        row.Cells[2].Value = artist.downloadGallery;
                        row.Cells[3].Value = artist.downloadScraps;
                        row.Cells[4].Value = artist.downloadFavorites;
                        row.Cells[5].Value = artist.downloadJournals;

                        existingValues.Add((string)row.Cells[1].Value);
                    }
                }
            }
            AddBottomRow();

            int lastRow = dgvArtistList.Rows.Count - 1;
            dgvArtistList.CurrentCell = dgvArtistList.Rows[lastRow].Cells[1];
            lblArtistCount.Text = (Program.myArtistList.Count + " artists");
        }

        /// <summary>
        /// !!! FIX CRASH !!! Artist List selection changed - Keeps selection out of status row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvArtistList_SelectionChanged(object sender, EventArgs e)
        {
            // Crashing when deleting all artists
            //    if ((dgvArtistList.CurrentCell != null
            //        && dgvArtistList.Columns[dgvArtistList.CurrentCell.ColumnIndex].Index == 0)
            //        ||
            //        (dgvArtistList.Columns[dgvArtistList.CurrentCell.RowIndex].Index
            //        == dgvArtistList.Rows.Count - 1
            //        &&
            //        (dgvArtistList.Columns[dgvArtistList.CurrentCell.ColumnIndex].Index == 0
            //        || dgvArtistList.Columns[dgvArtistList.CurrentCell.ColumnIndex].Index == 2
            //        || dgvArtistList.Columns[dgvArtistList.CurrentCell.ColumnIndex].Index == 3
            //        || dgvArtistList.Columns[dgvArtistList.CurrentCell.ColumnIndex].Index == 4
            //        || dgvArtistList.Columns[dgvArtistList.CurrentCell.ColumnIndex].Index == 5
            //        )))
            //    {
            //        dgvArtistList.CurrentCell = dgvArtistList.Rows
            //            [dgvArtistList.Columns[dgvArtistList.CurrentCell.RowIndex]
            //            .Index].Cells[1];
            //    }
        }

        /// <summary>
        /// Artist List Cell End Edit - Updates rows after editing a cell (invoked to prevent bug)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvArtistList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Only call on artist name row
            if (e.ColumnIndex == 1)
            {
                // Invoke keeps this from crashing
                BeginInvoke(new MethodInvoker(URBW_Launch));
            }
        }

        /// <summary>
        /// Artist list click - creates context menu on right click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvArtistList_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //dgvArtistListContextMenu = new ContextMenu();
                int currentMouseOverRow = dgvArtistList.HitTest(e.X, e.Y).RowIndex;
                int currentMouseOverColumn = dgvArtistList.HitTest(e.X, e.Y).ColumnIndex;
                dgvArtistListContextMenu.Items.Clear();

                // set column/row boundary for clicks
                if (currentMouseOverColumn == 1 && currentMouseOverRow >= 0)
                {
                    // select last row if clickd during multi-select
                    if (!dgvArtistList.SelectedCells.Contains
                        (dgvArtistList.Rows[currentMouseOverRow].Cells[1]))
                    {
                        dgvArtistList.CurrentCell = dgvArtistList.Rows[currentMouseOverRow].Cells[1];
                    }

                    if (dgvArtistList.SelectedCells.Count > 1)
                    {
                        if (currentMouseOverRow == dgvArtistList.Rows.Count - 1)
                        {
                            foreach (DataGridViewCell cell in dgvArtistList.SelectedCells)
                            {
                                cell.Selected = false;
                            }
                            dgvArtistList.CurrentCell = dgvArtistList.Rows[currentMouseOverRow].Cells[1];
                        }
                        else if (currentMouseOverRow >= 0
                        && currentMouseOverRow < dgvArtistList.Rows.Count - 1)
                        {
                            dgvArtistList.Rows[dgvArtistList.Rows.Count - 1].Cells[1].Selected = false;
                        }
                    }

                    // set up context menu for last row
                    if (currentMouseOverRow == dgvArtistList.Rows.Count - 1)
                    {
                        dgvArtistList.Rows[currentMouseOverRow].Cells[1].Selected = true;
                        dgvArtistListContextMenu.Items.Add
                            (
                            "Paste clipboard into artist list"
                            );
                    }

                    // set up context menu for all other rows
                    if (currentMouseOverRow >= 0
                        && currentMouseOverRow < dgvArtistList.Rows.Count - 1)
                    {
                        //foreach (DataGridViewCell cell in dgvArtistList.SelectedCells)
                        //{
                        //    dgvArtistListContextMenu.Items.Add
                        //        (
                        //        "Selected: " +
                        //        "Row: " + cell.RowIndex +
                        //        "Column: " + cell.ColumnIndex
                        //        );

                        //}

                        // set up context menu based on multi select
                        if (dgvArtistList.SelectedCells.Count == 1)
                        {
                            dgvArtistListContextMenu.Items.Add
                                ("Copy "
                                + '"' + dgvArtistList.CurrentCell.Value + '"'
                                + " to clipboard");
                            dgvArtistListContextMenu.Items.Add
                                (
                                "Remove " +
                                dgvArtistList.CurrentCell.Value
                                ); // //deleteSelectedArtistsFromList();
                            dgvArtistListContextMenu.Items.Add
                                (
                                "Download from "
                                + dgvArtistList.CurrentCell.Value
                                );
                            dgvArtistListContextMenu.Items.Add
                                (
                                "Update " +
                                dgvArtistList.CurrentCell.Value +
                                "'s online status");
                            dgvArtistListContextMenu.Items.Add
                                (
                                "Open " +
                                dgvArtistList.CurrentCell.Value +
                                "'s Furaffinity user page");
                            dgvArtistListContextMenu.Items.Add
                                (
                                "Open " +
                                dgvArtistList.CurrentCell.Value +
                                "'s download folder");
                        }
                        else if (dgvArtistList.SelectedCells.Count > 1)
                        {
                            // add menu items
                            dgvArtistListContextMenu.Items.Add
                                ("Copy artist names to clipboard");
                            dgvArtistListContextMenu.Items.Add
                                ("Remove selected artists"); // //deleteSelectedArtistsFromList();
                            dgvArtistListContextMenu.Items.Add
                                ("Download from selected artists");
                            dgvArtistListContextMenu.Items.Add
                                ("Update selected artist's online statuses");

                            // assign events
                        }
                    }
                }
                dgvArtistListContextMenu.Show(dgvArtistList, new Point(e.X, e.Y));
            }
        }

        /// <summary>
        /// dgvArtistList Context Menu click - handles clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvArtistListContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text.Contains("to clipboard"))
            {
                copyDGVArtistListSelectionToClipboard();
            }
            Logger.logDebug(e.ClickedItem.Text);
            if (e.ClickedItem.Text.Contains("Remove "))
            {
                Logger.logDebug("Should remove selected artists");
                deleteSelectedArtistsFromList();
                URBW_Launch();
            }
            if (e.ClickedItem.Text.Contains("Download from"))
            {
                Logger.logDebug("Should download from selected artists");
                setmyArtistListToSelected();
                DLBW_LauncDialogue();
                //btnDownload.PerformClick();
            }
            if (e.ClickedItem.Text.Contains("Update "))
            {
                Logger.logDebug("Should update statuses of selected artists");
                HTMLHandler.updateAllStatuses = false;
                HTMLHandler.overWriteStatuses = true;
                setmyArtistListToSelected();
                //URBW_Launch();
                SSIBW_Launch();
            }
            if (e.ClickedItem.Text.Contains("Paste clipboard into artist list"))
            {
                Logger.logDebug("Should paste clipboard");
                pasteDataIntoArtistList();
            }
            if (e.ClickedItem.Text.Contains("Furaffinity user page"))
            {
                Logger.logDebug("Should open FA page");
                System.Diagnostics.Process.Start
                    ("http://furaffinity.net/user/" + dgvArtistList.CurrentCell.Value);
            }
            if (e.ClickedItem.Text.Contains("'s download folder"))
            {
                Logger.logDebug("Should open FA page");
                downloadHandler.downloadDir = tbDownloadDirectory.Text;
                if (Directory.Exists(downloadHandler.downloadDir + @"\" +
                    (string)dgvArtistList.CurrentCell.Value + @"\"))
                {
                    System.Diagnostics.Process.Start
                        (downloadHandler.downloadDir + @"\" +
                    (string)dgvArtistList.CurrentCell.Value + @"\");
                }
                else
                {
                    System.Diagnostics.Process.Start
                        (downloadHandler.downloadDir);
                }
            }
        }

        private void setmyArtistListToSelected()
        {
            Program.activeArtistList.Clear(); // clear dictionary

            foreach (DataGridViewCell cell in dgvArtistList.SelectedCells)
            {
                string artistName = (string)cell.Value;
                if (Program.myArtistList.ContainsKey(artistName))
                {
                    Logger.logDebug("Adding " + artistName + " to active dictionary");
                    Program.activeArtistList.Add(artistName, Program.myArtistList[artistName]);
                }

                //foreach (ArtistObject artist in Program.myArtistList.Values)
                //{
                //    if ((string)cell.Value == artist.artistName)
                //    {
                //        Logger.logDebug("Adding " + artist.artistName + " to active dictionary");
                //        Program.activeArtistList.Add(artist.artistName, artist);
                //        break;
                //    }
                //}
            }

            Logger.logDebug("Active dictionary updated with selected artists.");
        }

        /// <summary>
        /// Artist Lisit Key Down - Sets controls when not editing a cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvArtistList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                URBW_Launch();
            }

            if (e.KeyCode == Keys.Delete)
            {
                deleteSelectedArtistsFromList();
                URBW_Launch();
            }

            if (e.Control && e.KeyCode == Keys.V)
            //if (e.KeyCode == (Keys.Control | Keys.V))
            {
                pasteDataIntoArtistList();
            }

            if (e.Control && e.KeyCode == Keys.A)
            {
                dgvSelectAll();
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                copyDGVArtistListSelectionToClipboard();
            }
        }

        /// <summary>
        /// Artist List Editing Control Showing - janky thing to set up controls if editing a cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvArtistList_EditingControlShowing
            (object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
            tb.KeyDown += new KeyEventHandler(dgvArtistListTextBoxEditingControl_KeyDown);
        }

        /// <summary>
        /// Artist List Text Box Editing Control Key Down - more janky controls, handles paste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvArtistListTextBoxEditingControl_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Control && e.KeyCode == Keys.V)
            if (e.KeyCode == (Keys.Control | Keys.V))
            {
                pasteDataIntoArtistList();
            }

            if (e.Control && e.KeyCode == Keys.A)
            {
                dgvSelectAll();
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                copyDGVArtistListSelectionToClipboard();
            }
        }


        private void copyDGVArtistListSelectionToClipboard()
        {
            DataObject dataObj = dgvArtistList.GetClipboardContent();
            Clipboard.SetDataObject(dataObj, true);
        }

        /// <summary>
        /// Artist List Sorted - Handles sorting, deletes and re-adds bottom row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvArtistList_Sorted(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvArtistList.Rows)
            {
                if ((string)row.Cells[1].Value == "Add artist...")
                {
                    dgvArtistList.Rows.Remove(row);
                }
            }
            AddBottomRow();
        }

        public void URBW_Launch()
        {
            dgvArtistList.Visible = false;
            lblBigStatus.Text = "Updating Rows. Please wait...";
            dgvArtistList.Columns[4].ReadOnly = true; // may break
            BW_Launch(URBW);
        }

        /// <summary>
        /// Update all Artist List rows - by Mango (with Muki edits)
        /// </summary>
        public void URBW_Run()
        {

            if (Thread.CurrentThread.Name == null)
                Thread.CurrentThread.Name = "URBW";

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("Update Rows Background Worker running")
            ));

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("Updating artist list rows")
            ));

            // build a list of rows to delete
            rowsToDelete = new List<DataGridViewRow>();
            // Wipe out the exsiting values hashset and start over; we'll repopulate it here
            existingValues = new HashSet<string>();

            foreach (DataGridViewRow row in dgvArtistList.Rows)
            {
                updateRow(row);
            }

            // delete the shitty rows
            foreach (DataGridViewRow rowToDelete in rowsToDelete)
            {
                Program.mainForm.dgvArtistList.BeginInvoke(new Action(() =>
                dgvArtistList.Rows.Remove(rowToDelete)
                ));
            }
            rowsToDelete = null;
        }

        public void URBW_Completed()
        {
            Logger.logDebug("Update Rows Background Worker completed");

            if (!isClosing)
            {
                dgvArtistList.Columns[4].ReadOnly = false; // may break
                AddBottomRow();
                lblArtistCount.Text = (Program.myArtistList.Count + " artists");
                HTMLHandler.overWriteStatuses = false;
                SSIBW_Launch();
            }
            // Update the dictionary containing the list of artists
            updateArtistList();
            dgvArtistList.Visible = true;
            lblBigStatus.Text = "URBW_Completed";
        }

        /// <summary>
        /// Update Row - Updates an individual row - by Mango
        /// </summary>
        /// <param name="row"></param>
        public void updateRow(DataGridViewRow row)
        {
            if (row.Cells[1].Value == null
                || row.Cells[1].Value.ToString().Equals("")
                || row.Cells[1].Value.ToString().Equals("Add artist...")
                )

            {
                rowsToDelete.Add(row);
                return;
            }

            string artistName
                = row.Cells[1].Value.ToString();

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("Updating artist list row with name: " + artistName)
            ));

            // either create a new artist object or use the existing one
            if (artistName == null || artistName.Equals(""))
            {
                rowsToDelete.Add(row);
            }
            else if (Program.myArtistList.ContainsKey(artistName))
            {
                // Check to see if this row already exists
                if (existingValues.Contains(artistName))
                {
                    Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                    Logger.logDebug("Marking duplicate artist list row for deletion")
                    ));

                    rowsToDelete.Add(row);
                    return;
                }

                // already exists

                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logDebug("Artist list row already exists, update settings")
                ));
                //collectDuplicateNames(row, artistName);
                //Program.myArtistList[artistName].updateSettings()
                //Program.myArtistList[artistName].updateName(name)
            }
            else
            {
                // name not in list, create new
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logDebug("Artist list row is new, adding new object")
                ));

                Program.myArtistList.Add
                    (artistName, new ArtistObject
                    (artistName, AccountStatus.Unknown, false, false, false, false));
            }

            existingValues.Add(artistName);
        }

        /// <summary>
        /// Update Artist List - Creates a temp, merges with original - by Mango (with Muki edits)
        /// </summary>
        public void updateArtistList()
        {
            Logger.logDebug("Updating artist list to remove bad entries");

            // Create the new dictionary to hold the new list of valid ArtistObjects
            Dictionary<string, ArtistObject> newArtistList
                = new Dictionary<string, ArtistObject>();

            // for each row, add the associated item to a NEW dictionary
            foreach (DataGridViewRow row in dgvArtistList.Rows)
            {
                string artistName
                    = row.Cells[1].Value.ToString();

                // Add item to the new dictionary only if it exists in our list of rows
                // This prevents old entires (zombies) from coming along
                if (Program.myArtistList.ContainsKey(artistName)
                    && artistName != "Add artist..."
                    && row.Cells[2].GetType() != typeof(DataGridViewTextBoxCell)
                    && row.Cells[3].GetType() != typeof(DataGridViewTextBoxCell)
                    && row.Cells[4].GetType() != typeof(DataGridViewTextBoxCell)
                    && row.Cells[5].GetType() != typeof(DataGridViewTextBoxCell)
                    )
                {
                    bool downloadGallery
                        = (bool)row.Cells[2].Value;
                    bool downloadScraps
                        = (bool)row.Cells[3].Value;
                    bool downloadFavorites
                        = (bool)row.Cells[4].Value;
                    bool downloadJournals
                        = (bool)row.Cells[5].Value;

                    // Update the exsiting artist object with the new settings
                    Program.myArtistList[artistName].updateSettings(
                        downloadGallery, downloadScraps, downloadFavorites, downloadJournals);

                    // Add the artist object to the new artist list
                    newArtistList.Add(artistName, Program.myArtistList[artistName]);
                }
            }

            // Replace the old list with the new list
            Program.myArtistList = newArtistList;

            // SAVE ARTIST LISTTTT
            string artistListDictionaryString = JsonConvert.SerializeObject(Program.myArtistList);
            Settings.Default.artistListJSON = artistListDictionaryString;
        }

        /// <summary>
        /// Adds "Add Artist..." row to bottom of Artist List
        /// </summary>
        public void AddBottomRow()
        {
            Logger.logDebug("Adding 'Add Artist...' line to bottom of artist list");

            int newRow = dgvArtistList.Rows.Add();

            // if last row does not contain "Add Artist"
            if (newRow == 0
                || ((string)dgvArtistList.Rows[newRow - 1].Cells[1].Value != "Add artist..."))
            {
                dgvArtistList.Rows[newRow].Cells[1].Value = "Add artist...";
                disableBottomRowCheckBoxes(newRow);
            }
            else if ((string)dgvArtistList.Rows[newRow - 1].Cells[1].Value == "Add artist...")
            {
                dgvArtistList.Rows.RemoveAt(newRow);
                disableBottomRowCheckBoxes(newRow - 1);
            }
        }

        /// <summary>
        /// Disables checkboxes on "Add Artist..." row
        /// </summary>
        /// <param name="rowToDisableCheckboxes"></param>
        public void disableBottomRowCheckBoxes(int rowToDisableCheckboxes)
        {

            Logger.logDebug("Enabling all checkboxes in artist list");
            foreach (DataGridViewRow row in dgvArtistList.Rows)
            {
                foreach (int enableThis in columnsToEnable)
                {
                    if (
                        (string)row.Cells[1].Value != "Add artist..."
                        &&
                        (row.Cells[2].GetType() == typeof(DataGridViewTextBoxCell)
                        || row.Cells[3].GetType() == typeof(DataGridViewTextBoxCell)
                        || row.Cells[4].GetType() == typeof(DataGridViewTextBoxCell)
                        || row.Cells[5].GetType() == typeof(DataGridViewTextBoxCell)
                        ))
                    {
                        row.Cells[enableThis].ReadOnly = false;
                        row.Cells[enableThis] = new DataGridViewCheckBoxCell();
                        row.Cells[enableThis].Value = false;
                        row.Cells[enableThis].Style.BackColor = Color.White;
                        row.Cells[0].Style.BackColor = Color.White;
                    }
                }
            }
            Logger.logDebug("Disabling checkboxes on last row of artist list");
            foreach (int disableThis in bottomLineColumnsToDisable)
            {
                dgvArtistList[disableThis, rowToDisableCheckboxes] = new DataGridViewTextBoxCell();
                dgvArtistList[disableThis, rowToDisableCheckboxes].Value = "";
                dgvArtistList[disableThis, rowToDisableCheckboxes].ReadOnly = true;
                dgvArtistList[disableThis, rowToDisableCheckboxes].Style.BackColor =
                    System.Drawing.Color.FromArgb
                    (((int)(((byte)(106)))),
                    ((int)(((byte)(114)))),
                    ((int)(((byte)(131)))));
            }
        }

        /// <summary>
        /// Deselect All in Artist List button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            dgvArtistList.ClearSelection();
        }

        /// <summary>
        /// Select All in Artist List button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            dgvSelectAll();
        }

        /// <summary>
        /// Select All in Artist List function
        /// </summary>
        private void dgvSelectAll()
        {
            // method 1 - programatically select

            dgvArtistList.ClearSelection(); // clear selection... for ctrl+a

            foreach (DataGridViewRow row in dgvArtistList.Rows)
            {
                if (row.Index != dgvArtistList.Rows.Count - 1)
                {
                    dgvArtistList.Rows[row.Index].Cells[1].Selected = true;
                }
            }

            ////method 2 - select all then deselect shit we don't need
            //dgvArtistList.SelectAll();

            //dgvArtistList.Columns[0].Selected = false;
            //dgvArtistList.Columns[2].Selected = false;
            //dgvArtistList.Columns[3].Selected = false;
            //dgvArtistList.Columns[4].Selected = false;
            //dgvArtistList.Columns[5].Selected = false;

            //dgvArtistList.Rows[dgvArtistList.Rows.Count - 1].Selected = false;
        }

        /// <summary>
        /// ??? IMPROVE ??? All Gallery Type checkbox check changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAllGalleryTypes_CheckedChanged(object sender, EventArgs e)
        {
            cbGallery.Checked = cbAllGalleryTypes.Checked;
            cbScraps.Checked = cbAllGalleryTypes.Checked;
            cbFavorites.Checked = cbAllGalleryTypes.Checked;
            cbJournals.Checked = cbAllGalleryTypes.Checked;
        }

        // Do I need other Gallery Type checkbox functions?
        // Do I need other Gallery Type checkbox functions?
        // Do I need other Gallery Type checkbox functions?
        // Do I need other Gallery Type checkbox functions?
        // Do I need other Gallery Type checkbox functions?

        /// <summary>
        /// Apply Download Gallery Types button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnArtistApplyDownloads_Click(object sender, EventArgs e)
        {

            List<DataGridViewRow> rowCollection = new List<DataGridViewRow>();

            foreach (DataGridViewCell cell in dgvArtistList.SelectedCells)
            {
                rowCollection.Add(dgvArtistList.Rows[cell.RowIndex]);
            }

            foreach (DataGridViewRow row in rowCollection)
            {
                if
                    (row.Cells[2].GetType() != typeof(DataGridViewTextBoxCell)
                    && row.Cells[3].GetType() != typeof(DataGridViewTextBoxCell)
                    && row.Cells[4].GetType() != typeof(DataGridViewTextBoxCell)
                    && row.Cells[5].GetType() != typeof(DataGridViewTextBoxCell)
                    )
                {
                    row.Cells[2].Value = cbGallery.Checked;
                    row.Cells[3].Value = cbScraps.Checked;
                    row.Cells[4].Value = cbFavorites.Checked;
                    row.Cells[5].Value = cbJournals.Checked;
                }
            }
        }

        /// <summary>
        /// Remove Selected Artists button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveArtists_Click(object sender, EventArgs e)
        {
            deleteSelectedArtistsFromList();

            //List<DataGridViewRow> rowCollection = new List<DataGridViewRow>();

            //foreach (DataGridViewCell cell in dgvArtistList.SelectedCells)
            //{
            //    rowCollection.Add(dgvArtistList.Rows[cell.RowIndex]);
            //}

            //foreach (DataGridViewRow row in rowCollection)
            //{
            //    if (row.Cells[2].GetType() != typeof(DataGridViewTextBoxCell)
            //        && row.Cells[3].GetType() != typeof(DataGridViewTextBoxCell)
            //        && row.Cells[4].GetType() != typeof(DataGridViewTextBoxCell)
            //        && row.Cells[5].GetType() != typeof(DataGridViewTextBoxCell)
            //        )
            //    {
            //        dgvArtistList.Rows.Remove(row);
            //    }
            //}
        }


        /// <summary>
        /// Get Get All Artist Statuses button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetArtistStatuses_Click(object sender, EventArgs e)
        {
            HTMLHandler.updateAllStatuses = true;
            SSIBW_Launch();
        }

        //source: http://stackoverflow.com/questions/1547476/easiest-way-to-split-a-string-on-newlines-in-net
        /// <summary>
        /// Handles pasting multiple lines into artist list
        /// </summary>
        public void pasteDataIntoArtistList()
        {
            ArrayList ArtistsInClipboard = new ArrayList();

            ArtistsInClipboard.AddRange
                (Clipboard.GetText().Split
                (new string[] { "\r\n", "\n" },
                StringSplitOptions.RemoveEmptyEntries));

            addNewArtistsToList(ArtistsInClipboard);
            importArtistList();
            URBW_Launch();
        }

        public void deleteSelectedArtistsFromList()
        {
            //delete selected rows and update
            foreach (DataGridViewCell cell in this.dgvArtistList.SelectedCells)
            {
                if (cell.RowIndex != dgvArtistList.Rows.Count - 1)
                {
                    Logger.logDebug("Removing artist list row " + cell.RowIndex);
                    dgvArtistList.Rows.RemoveAt(cell.RowIndex);
                }
            }
        }

        /// <summary>
        /// Add new artists to artist list
        /// </summary>
        /// <param name="newArtists"></param>
        public void addNewArtistsToList(ArrayList newArtists)
        {
            foreach (string newArtist in newArtists)
            {
                if (!Program.myArtistList.ContainsKey(newArtist))
                {
                    Program.myArtistList.Add(newArtist, new ArtistObject(newArtist));
                }
            }
        }

        /// <summary>
        /// Set UI based on watchlist importing status
        /// </summary>
        private void watchListSetUI()
        {
            btnDownload.Enabled = watchListImporter.notImportingWatchList;
            tbUsername.Enabled = watchListImporter.notImportingWatchList;
            tbPassword.Enabled = watchListImporter.notImportingWatchList;
            btnLogin.Enabled = watchListImporter.notImportingWatchList;
            gbArtistSettings.Enabled = watchListImporter.notImportingWatchList;
            gbArtistSettings.Enabled = watchListImporter.notImportingWatchList;
        }

        /// <summary>
        /// ???ADD??? Artist Settings File button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnArtistSettingsFile_Click(object sender, EventArgs e)
        {
            // DO WE WANT A SETTINGS FILE?
            // DO WE WANT A SETTINGS FILE?
            // DO WE WANT A SETTINGS FILE?
            // DO WE WANT A SETTINGS FILE?
            // DO WE WANT A SETTINGS FILE?
        }
        #endregion

        //////////////////////////////////
        // SET STATUS INDICATORS THREAD //
        //////////////////////////////////

        #region
        /// <summary>
        /// Set Status Indicator Background Worker (SSIBW)  - Launch
        /// </summary>
        public void SSIBW_Launch()
        {
            while (SSIBW.IsBusy)
            {
                SSIBW.CancelAsync();
            }
            BW_Launch(SSIBW);
        }

        /// <summary>
        /// Set Status Indicator Background Worker (SSIBW) - run
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="row"></param>
        public void SSIBW_Run()
        {
            SSIBW.WorkerSupportsCancellation = true;
            if (Thread.CurrentThread.Name == null)
                Thread.CurrentThread.Name = "SSIBW";

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("Set Status Indicator Background Worker running")
            ));


            if (HTMLHandler.connectedToFA)
            {
                if (HTMLHandler.updateAllStatuses)
                {
                    setStatusIndicators(Program.myArtistList);
                }
                else
                {
                    setStatusIndicators(Program.activeArtistList);
                }
            }
            else
            {
                Logger.logDebug(Strings.FAOnlineStatus + HTMLHandler.FAOnlineStatus);

                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logDebug("Cannot set empty artist statuses")
                ));
            }
        }

        /// <summary>
        /// Set Status Indicator Background Worker (SSIBW) completed
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="row"></param>
        public void SSIBW_Completed()
        {
            Logger.logDebug("Set Status Indicator Background Worker completed");

            HTMLHandler.updateAllStatuses = true;
            HTMLHandler.overWriteStatuses = false;

            if (HTMLHandler.connectedToFA)
            {

            }
            else
            {
                setConnectionUI(HTMLHandler.connectedToFA, HTMLHandler.FAOnlineStatus);
            }
        }

        /// <summary>
        /// Set the Status Indicator for each row, based on user's logged in state
        /// </summary>
        public void setStatusIndicators(Dictionary<String, ArtistObject> artistList)
        {
            if (HTMLHandler.updateAllStatuses)
            {
                //Program.activeArtistList = Program.myArtistList;
            }

            foreach (DataGridViewRow row in dgvArtistList.Rows)
            {
                foreach (ArtistObject artist in artistList.Values)
                {
                    // Load the status indicators if valid status exists
                    if (artist.accountStatus != AccountStatus.Unknown)
                    {
                        setStatusIndicator(row, artist, "Refresh");
                    }

                    // If we're logged in, update statuses that require login
                    if (HTMLHandler.loggedIn)
                    {
                        if (artist.artistName == (string)row.Cells[1].Value
                        && artist.accountStatus == AccountStatus.PageRequiresLogin)
                        {
                            row.Cells[0].Style.ForeColor = Color.Black;
                            row.Cells[0].Value = "...";

                            HTMLHandler.getArtistStatus(artist);
                            setStatusIndicator(row, artist, "RequireLogin");
                        }
                    }

                    // If overwrite statuses, we will re-check all applicable statuses
                    if (HTMLHandler.overWriteStatuses)
                    {
                        if ((string)row.Cells[1].Value != "Add artist...")
                        {
                            if (artist.artistName == (string)row.Cells[1].Value)
                            {
                                row.Cells[0].Style.ForeColor = Color.Black;
                                row.Cells[0].Value = "...";

                                HTMLHandler.getArtistStatus(artist);
                                setStatusIndicator(row, artist, "Overwrite");
                            }
                        }
                    }



                    // update all rows with unknown status
                    if ((string)row.Cells[1].Value != "Add artist..."
                        && cbStatusAutoUpdate.Checked
                        //&& ((string)row.Cells[0].Value == ""
                        //|| (string)row.Cells[0].Value == null))
                        )
                    {
                        if (artist.artistName == (string)row.Cells[1].Value
                            && artist.accountStatus == AccountStatus.Unknown)
                        {
                            row.Cells[0].Style.ForeColor = Color.Black;
                            row.Cells[0].Value = "...";

                            HTMLHandler.getArtistStatus(artist);
                            setStatusIndicator(row, artist, "UpdateUnknown");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Set the Status Indicator next to the artist name
        /// </summary>
        /// <param name="row"></param>
        public static void setStatusIndicator(DataGridViewRow row, ArtistObject artist, string updateType)
        {
            if (HTMLHandler.connectedToFA)
            {
                string artistNameInRow = row.Cells[1].Value.ToString();

                if (artist.artistName == artistNameInRow)
                {
                    /*
                    Refresh
                    UpdateUnknown
                    Overwrite
                    RequireLogin
                    */

                    // move to html handler
                    //Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                    //Logger.logStatus(artist.artistName + "'s status is " + artist.accountStatus)
                    //));

                    switch (artist.accountStatus)
                    {
                        case AccountStatus.Available:
                            row.Cells[0].Style.ForeColor = Color.DarkGreen;
                            row.Cells[0].Value = "O";
                            row.Cells[0].ToolTipText = "Artist is available";
                            break;
                        case AccountStatus.PageRequiresLogin:
                            row.Cells[0].Style.ForeColor = Color.Orange;
                            row.Cells[0].Value = "!";
                            row.Cells[0].ToolTipText = "Artist page requires login";
                            break;
                        case AccountStatus.AccountDisabled:
                            row.Cells[0].Style.ForeColor = Color.Red;
                            row.Cells[0].Value = "!";
                            row.Cells[0].ToolTipText = "Artist account is disabled";
                            break;
                        case AccountStatus.AccountDisabledVoluntary:
                            row.Cells[0].Style.ForeColor = Color.Red;
                            row.Cells[0].Value = "!";
                            row.Cells[0].ToolTipText = "Artist acount is voluntarily disabled";
                            break;
                        case AccountStatus.PageDoesNotExist:
                            row.Cells[0].Style.ForeColor = Color.Red;
                            row.Cells[0].Value = "X";
                            row.Cells[0].ToolTipText = "Artist does not exist";
                            break;
                        default:
                            row.Cells[0].Style.ForeColor = Color.DarkGray;
                            row.Cells[0].Value = "?";
                            row.Cells[0].ToolTipText = "Artist status unknown";
                            break;
                    }
                }
            }
        }
        #endregion

        ///////////////////////////////////////////
        // SET STATUS INDICATOR ANIMATION THREAD //
        ///////////////////////////////////////////

        #region
        /// <summary>
        /// Set Status Indicator Animation (SSIA) background worker - launch
        /// </summary>
        private void SSIABW_Launch()
        {
            BW_Launch(SSIABW);
        }

        /// <summary>
        /// Set Status Indicator Animation (SSIA) background worker - run
        /// </summary>
        /// <param name="row"></param>
        /// <param name="artistList"></param>
        private string SSIABW_Run(DataGridViewRow row, ArtistObject artist)
        {
            if (Thread.CurrentThread.Name == null)
                Thread.CurrentThread.Name = "SSIABW";

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("Set Status Indicator Animation Background Worker running")
                ));

            if (HTMLHandler.connectedToFA)
            {
                return "-";
                Thread.Sleep(250);
                return "/";
                Thread.Sleep(250);
                return "-";
                Thread.Sleep(250);
                return @"\";
                Thread.Sleep(250);
            }
            else
            {
                setConnectionUI(HTMLHandler.connectedToFA, HTMLHandler.FAOnlineStatus);
                return null;
            }
        }

        /// <summary>
        /// Set Status Indicator Animation (SSIA) background worker - complete
        /// </summary>
        private void SSIABW_Completed()
        {
            Logger.logDebug("Set Status Indicator Animation Background Worker completed");
        }
        #endregion

        ////////////////////////////////
        // WATCHLIST IMPORTING THREAD //
        ////////////////////////////////

        #region
        /// <summary>
        /// Import Watch List button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportWatchList_Click(object sender, EventArgs e)
        {
            DialogResult importWatchList = MessageBox.Show
                    (
                    "Depending on the size of your watch list,"
                    + Environment.NewLine +
                    "this process can take a while."
                    + Environment.NewLine +
                    "Continue with watch list import?",
                    "Import watch list?",
                    MessageBoxButtons.YesNo
                    );
            if (importWatchList == DialogResult.Yes)
            {
                if (HTMLHandler.loggedIn)
                {
                    Logger.logStatus("Importing watch list.");

                    watchListImporter.notImportingWatchList = false;
                    watchListSetUI();
                    WLIBW_Launch();
                }
                else
                {
                    Logger.logError(Strings.Error);
                }
            }
            else if (importWatchList == DialogResult.No)
            {
                Logger.logStatus("Watchlist will not be imported.");
            }
        }

        /// <summary>
        /// Watch list importing (WLI)
        /// </summary>
        public void WLIBW_Launch()
        {
            if (HTMLHandler.connectedToFA)
            {
                BW_Launch(WLIBW);             // Begin thread
            }
        }

        /// <summary>
        /// !!! SET UP ARGS !!! WLI Background Worker running
        /// </summary>
        /// <param name="connectedToFA"></param>
        /// <param name="FAOnlineStatus"></param>
        public void WLIBW_Run()
        {
            if (Thread.CurrentThread.Name == null)
            {
                Thread.CurrentThread.Name = "WLIBW";
            }

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("Watch List Import Background Worker running")
            ));

            HTMLHandler.checkFAOnlineStatus();
            if (HTMLHandler.connectedToFA)
            {
                watchListImporter.importWatchList();
                addNewArtistsToList(watchListImporter.watchedArtists);
                watchListImporter.watchedArtists = new ArrayList(); // clear our arraylist
            }
        }

        /// <summary>
        /// !!! SET UP ARGS !!! WLI Background Worker completed
        /// </summary>
        public void WLIBW_Completed()
        {
            Logger.logDebug("Watch List Import Background Worker completed");

            if (HTMLHandler.connectedToFA)
            {
                watchListImporter.notImportingWatchList = true;
                importArtistList();
                watchListSetUI();
                URBW_Launch();
            }
            else
            {
                setConnectionUI(HTMLHandler.connectedToFA, HTMLHandler.FAOnlineStatus);
            }
        }

        #endregion

        ///////////////////////////////////////////////
        // FURAFFINITY SETTINGS (OLD, CAPTCHA LOGIN) //
        ///////////////////////////////////////////////

        #region
        /// <summary>
        /// ???FIX??? Username textbox text changed - move to enter press?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbUsername_TextChanged(object sender, EventArgs e)
        {
            HTMLHandler.faUsername = tbUsername.Text;
        }

        /// <summary>
        /// ???FIX??? Username textbox key press, enter key switches to password box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                tbPassword.Focus();
            }
        }

        /// <summary>
        /// ???FIX??? Password Textbox text changed - move to enter press?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            HTMLHandler.faPassword = tbPassword.Text;
        }

        /// <summary>
        /// ???FIX??? Password textbox key press, enter key switches to password box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!HTMLHandler.loggedIn)
                {
                    btnLogin.Focus();
                    btnLogin.PerformClick();
                }
            }
        }

        /// <summary>
        /// Auto Log In checkbox check changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbLogInOnLaunch_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Show Password checkbox check changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            showPassword = cbShowPassword.Checked;
            if (showPassword)
            {
                tbPassword.PasswordChar = '\0';
            }
            else if (!showPassword)
            {
                tbPassword.PasswordChar = '+';
            }
        }
        #endregion

        /////////////////////////////////////////
        // FURAFFINITY SETTINGS (NEW, COOKIES) //
        /////////////////////////////////////////

        #region
        /// <summary>
        /// Cookies Tutorial Button click, creates new thread and launches Cookies Tutorial form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CookieTut_Click(object sender, EventArgs e)
        {
            Thread ct = new Thread(launchCookiesTutorial);
            ct.Name = "aboutWindow";
            ct.Start();
        }

        /// <summary>
        /// Launches About Window, called from About Button click
        /// </summary>
        private void launchCookiesTutorial()
        {
            CookiesTutorial CookiesTutorial = new CookiesTutorial();
            CookiesTutorial.ShowDialog();
        }

        /// <summary>
        /// ???FIX??? Username textbox key press, enter key switches to password box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbCookieA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                tbCookieB.Focus();
            }
        }

        /// <summary>
        /// ???FIX??? Password textbox key press, enter key switches to password box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbCookieB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!HTMLHandler.loggedIn)
                {
                    btnVerifyCookies.Focus();
                    btnVerifyCookies.PerformClick();
                }
            }
        }
        #endregion

        /////////////////////////////////////////
        // LOGIN HANDLING (OLD, CAPTCHA LOGIN) //
        /////////////////////////////////////////

        #region
        /// <summary>
        /// Login button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (HTMLHandler.connectedToFA)
            {
                if (!cbLogInOnLaunch.Checked)
                {
                    CFAOSBW_Launch(); // precaution to catch if site goes offline
                }

                Logger.logStatus("Logging into FurAffinity...");

                if (!HTMLHandler.loggedIn)
                {
                    wbLogin.Url =
                        new Uri(@"https://www.furaffinity.net/login");
                    wbLogin.DocumentCompleted +=
                        new WebBrowserDocumentCompletedEventHandler(loadLoginPage);

                    lblLoginStatus.ForeColor = Color.Orange;
                    lblLoginStatus.Text = "Logging in...";
                }
                else
                {
                    wbLogin.Url =
                        new Uri(@"http://www.furaffinity.net/logout");
                    wbLogin.DocumentCompleted +=
                        new WebBrowserDocumentCompletedEventHandler(loadLogoutPage);

                    lblLoginStatus.ForeColor = Color.Orange;
                    lblLoginStatus.Text = "Logging out...";
                }
                HTMLHandler.loggingIn = true;
                setLoggingInUI();
            }
            else
            {
                Logger.logDebug(Strings.FAOnlineStatus + HTMLHandler.FAOnlineStatus);
                Logger.logError("Failure at btnLogin_Click. Cannot login.");
                Logger.logError(Strings.Error);
            }
        }

        /// <summary>
        /// Automatically logs in if checkbox is checked and user is not logged in
        /// </summary>
        private void autoLogInCheck()
        {
            if (
                cbLogInOnLaunch.Checked
                && !HTMLHandler.loggedIn
                && HTMLHandler.connectedToFA
                )
            {
                btnLogin.PerformClick();
            }
        }

        /// <summary>
        /// !!! ADD FAILSAFE !!! Load the login page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void loadLoginPage(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!HTMLHandler.connectedToFA)
            {
                Logger.logDebug(Strings.FAOnlineStatus + HTMLHandler.FAOnlineStatus);
                Logger.logError("Failure at loadLoginPage. Cannot connect to FA.");
                Logger.logError(Strings.Error);

                return;
            }
            //if(TITLE CONTAINS APPROPRIATE TITLE)
            {
                //MOVE EVERYTHING UP HERE
            }

            //else
            {
                //checkFAOnlineStatus();
            }

            // If these two elements exist,
            if (
            wbLogin.Document.GetElementById("name") != null &&
            wbLogin.Document.GetElementById("pass") != null
            )
            {
                // Fill out username
                wbLogin.Document.GetElementById("name").InnerText = HTMLHandler.faUsername;
                // Fill out password
                wbLogin.Document.GetElementById("pass").InnerText = HTMLHandler.faPassword;

                showCaptcha();
            }
            else
            {
                Logger.logError("Could not locate credentials fields");
                wbLogin.DocumentCompleted -= loadLoginPage; // UNSUB FROM LOGIN PAGE CHECK
                return;
            }
        }

        /// <summary>
        /// Show captcha group box
        /// </summary>
        void showCaptcha()
        {
            // Scrape for captcha image, save it off, and display it in the UI.;

            gbCaptcha.Visible = true;
            tbCaptcha.Focus();
            HtmlElement captcha = wbLogin.Document.GetElementById("captcha_img");

            if (captcha == null)
            {
                Logger.logStatus("Captcha is null");
                return;
            }
            else
            {
                if (!Directory.Exists(Application.StartupPath + @"\temp\"))
                {
                    Directory.CreateDirectory(Application.StartupPath + @"\temp\");
                }
                IHTMLDocument2 doc = (IHTMLDocument2)wbLogin.Document.DomDocument;
                IHTMLControlRange imgRange = (IHTMLControlRange)((HTMLBody)doc.body).createControlRange();

                foreach (IHTMLImgElement img in doc.images)
                {
                    if (img.nameProp.Contains("captcha"))
                    {
                        imgRange.add((IHTMLControlElement)img);

                        imgRange.execCommand("Copy", false, null);

                        using (Bitmap bmp = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap))
                        {
                            bmp.Save(Application.StartupPath + @"\temp\" + "captcha.jpg"); //+ img.nameProp);
                            Clipboard.Clear();
                        }
                    }
                }

                //IHTMLDocument2 doc = (IHTMLDocument2)wbLogin.Document.DomDocument;
                //IHTMLControlRange imgRange;
                //HTMLBody body = (HTMLBody)doc.body;

                //Bitmap bmp = null;

                //foreach (IHTMLImgElement img in doc.images)
                //{
                //    if (img.src.IndexOf("someinfo") > 0)
                //    {
                //        imgRange = (IHTMLControlRange)body.createControlRange();
                //        imgRange.add((IHTMLControlElement)img);
                //        imgRange.execCommand("Copy", false, null);
                //        bmp = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
                //    }
                //}

                //if (null != bmp)
                //{
                //    bmp.Save(Application.StartupPath + img.nameProp);
                //}

                Logger.logDebug("Captcha found");

                WFCBW_Launch();
            }
        }

        /// <summary>
        /// Wait For Captcha Background Worker (WFCBW) - launch
        /// </summary>
        public void WFCBW_Launch()
        {
            BW_Launch(WFCBW);
        }

        /// <summary>
        /// Wait For Captcha Background Worker (WFCBW) - run
        /// </summary>
        public void WFCBW_Run()
        {
            if (Thread.CurrentThread.Name == null)
                Thread.CurrentThread.Name = "WFCBW";

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("Wait for Captcha Background Worker running")
            ));

            while (!File.Exists(Application.StartupPath + @"\temp\captcha.jpg"))
            {
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logDebug("Sleeping. Waiting for captcha image download")
                ));
                Thread.Sleep(1000);
            }

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("Captcha file found.")
            ));

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("Please enter Captcha verification.")
            ));

            Program.mainForm.pbCaptcha.BeginInvoke(new Action(() =>
            pbCaptcha.LoadAsync(Application.StartupPath + @"\temp\captcha.jpg")
            ));
        }

        /// <summary>
        /// Wait For Captcha Background Worker (WFCBW) - completed
        /// </summary>
        public void WFCBW_Completed()
        {
            Logger.logDebug("Wait for Captcha Background Worker completed");
        }

        /// <summary>
        /// Captcha Textbox key press
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbCaptcha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnCaptchaSubmit.PerformClick();
            }
        }

        /// <summary>
        /// Captcah Submit Button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCaptchaSubmit_Click(object sender, EventArgs e)
        {
            gbCaptcha.Visible = false;
            File.Delete(Application.StartupPath + "/captcha.jpg");
            wbLogin.Document.GetElementById("captcha").InnerText = tbCaptcha.Text;
            tbCaptcha.Text = null;
            IOHandler.deleteDirectory((Application.StartupPath + @"\temp\"));
            submitCredentials();
        }

        /// <summary>
        /// Submit login credentials
        /// </summary>
        void submitCredentials()
        {
            // Scrape for login button and click it, can I condense this?
            HtmlElementCollection input = this.wbLogin.Document.GetElementsByTagName("input");

            foreach (HtmlElement he in input)
            {
                if (he.GetAttribute("type").Equals("submit"))
                {
                    Logger.logDebug("Login button found, clicking");
                    he.InvokeMember("Click");
                    wbLogin.DocumentCompleted += verifyLoginSuccess; // SUB TO VERIFY LOGIN
                    wbLogin.DocumentCompleted -= loadLoginPage; // UNSUB FROM LOGIN PAGE CHECK

                    userCookies = cookieHandler.GetUriCookieContainer(new Uri("https://www.furaffinity.net/"));

                    // cookie debug
                    Logger.logStatus("Cookies from FA login:");
                    CookieCollection myCookies = userCookies.GetCookies(new Uri("https://www.furaffinity.net/"));
                    foreach (Cookie c in myCookies)
                    {
                        Logger.logStatus("Cookie name: " + c.Name + "\nCookie value: " + c.Value);
                    }

                    break;
                }
                else
                {
                    Logger.logDebug("Locating login button...");
                    HTMLHandler.loggedIn = false;
                }
            }
        }

        /// <summary>
        /// ??? ADD FAILISAFE ??? Load page after login, verify Login Success
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void verifyLoginSuccess(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!HTMLHandler.connectedToFA)
            {
                Logger.logDebug(Strings.FAOnlineStatus + HTMLHandler.FAOnlineStatus);
                Logger.logError("Failure at loadLogoutPage. Cannot load logout page");
                Logger.logError(Strings.Error);

                return;
            }

            if (!wbLogin.Document.Title.Contains("Login"))
            {
                HTMLHandler.loggedIn = true;
                Logger.logStatus(Strings.loginSuccess);
                btnLogin.Text = "Log out";
                lblLoginStatus.ForeColor = Color.LightGreen;
                lblLoginStatus.Text = "Logged in!";
                HTMLHandler.overWriteStatuses = false;
                SSIBW_Launch();
                tbCaptcha.Text = null;

                // wbLogin.Visible = false; // uncomment to debug site
            }
            else
            {
                HTMLHandler.loggedIn = false;
                Logger.logStatus(Strings.invalidCredentials);
                lblLoginStatus.ForeColor = Color.OrangeRed;
                lblLoginStatus.Text = "Log in failed.";
                btnLogin.Text = "Log in";
            }
            HTMLHandler.loggingIn = false;
            setLoggedInUI();
            wbLogin.DocumentCompleted -= verifyLoginSuccess; // UNSUB FROM LOGIN SUCCESS CHECK
        }

        /// <summary>
        /// !!! ADD FAILSAFE !!! Load logout URL, log out of FurAffinity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void loadLogoutPage(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!HTMLHandler.connectedToFA)
            {
                Logger.logDebug(Strings.FAOnlineStatus + HTMLHandler.FAOnlineStatus);
                Logger.logError("Failure at loadLogoutPage. Cannot load logout page");
                Logger.logError(Strings.Error);

                return;
            }
            if (HTMLHandler.loggedIn)
            {
                HTMLHandler.loggedIn = false;
                Logger.logStatus(Strings.logOutSuccess);
                btnLogin.Text = "Log in";
                lblLoginStatus.ForeColor = Color.Orange;
                lblLoginStatus.Text = "You have been logged out.";
            }
            setLoggedInUI();
            wbLogin.DocumentCompleted -= loadLogoutPage; // UNSUB FROM LOGOUT CHECK
        }

        /// <summary>
        /// Sets UI After Login
        /// </summary>
        private void setLoggingInUI()
        {
            tbUsername.Enabled = !HTMLHandler.loggingIn;
            tbPassword.Enabled = !HTMLHandler.loggingIn;
            btnLogin.Enabled = !HTMLHandler.loggingIn;

            cbAllFARatings.Enabled = !HTMLHandler.loggingIn;
            cbMature.Enabled = !HTMLHandler.loggingIn;
            cbAdult.Enabled = !HTMLHandler.loggingIn;

            cbMature.Checked = !HTMLHandler.loggingIn;
            cbAdult.Checked = !HTMLHandler.loggingIn;

            btnImportWatchList.Enabled = !HTMLHandler.loggingIn;
            btnDownload.Enabled = !HTMLHandler.loggingIn;

            //if (HTMLHandler.loggingIn)
            //{
            //    cbAllFARatings.Enabled = HTMLHandler.loggedIn;
            //    cbMature.Enabled = HTMLHandler.loggedIn;
            //    cbAdult.Enabled = HTMLHandler.loggedIn;
            //    btnImportWatchList.Enabled = HTMLHandler.loggedIn;
            //    btnDownload.Enabled = !HTMLHandler.loggingIn;

            //    //cbAllFARatings.Visible = HTMLHandler.loggedIn;
            //    //cbMature.Visible = HTMLHandler.loggedIn;
            //    //cbAdult.Visible = HTMLHandler.loggedIn;
            //    //btnImportWatchList.Visible = HTMLHandler.loggedIn;
            //    //btnDownload.Visible = !HTMLHandler.loggingIn;
            //}
            //else
            //{
            //    tbUsername.Enabled = !HTMLHandler.loggingIn;
            //    tbPassword.Enabled = !HTMLHandler.loggingIn;
            //    btnLogin.Enabled = !HTMLHandler.loggingIn;

            //    cbMature.Checked = !HTMLHandler.loggingIn;
            //    cbAdult.Checked = !HTMLHandler.loggingIn;

            //    cbAllFARatings.Enabled = !HTMLHandler.loggingIn;
            //    cbMature.Enabled = !HTMLHandler.loggingIn;
            //    cbAdult.Enabled = !HTMLHandler.loggingIn;
            //    btnImportWatchList.Enabled = !HTMLHandler.loggingIn;
            //    btnDownload.Enabled = !HTMLHandler.loggingIn;

            //    //cbAllFARatings.Visible = !HTMLHandler.loggingIn;
            //    //cbMature.Visible = !HTMLHandler.loggingIn;
            //    //cbAdult.Visible = !HTMLHandler.loggingIn;
            //    //btnImportWatchList.Visible = !HTMLHandler.loggingIn;
            //    //btnDownload.Visible = !HTMLHandler.loggingIn;
            //}
        }

        /// <summary>
        /// Set UI Based on login results
        /// </summary>
        private void setLoggedInUI() // can move to ui handler?
        {
            if (HTMLHandler.connectedToFA)
            {
                cbAllFARatings.Enabled = HTMLHandler.loggedIn;
                cbMature.Enabled = HTMLHandler.loggedIn;
                cbAdult.Enabled = HTMLHandler.loggedIn;

                btnImportWatchList.Enabled = HTMLHandler.loggedIn;

                if (HTMLHandler.loggedIn)
                {
                    //setLoggingInUI();

                    cbAllFARatings.Checked = Settings.Default.cbAllFARatings;
                    cbGeneral.Checked = Settings.Default.cbGeneral;
                    cbMature.Checked = Settings.Default.cbMature;
                    cbAdult.Checked = Settings.Default.cbAdult;


                }
                else if (!HTMLHandler.loggedIn)
                {
                    //setLoggingInUI();

                    cbAllFARatings.Checked = HTMLHandler.loggedIn;
                    cbAdult.Checked = HTMLHandler.loggedIn;
                    cbMature.Checked = HTMLHandler.loggedIn;

                    tbUsername.Focus();
                    Logger.logDebug(Strings.invalidCredentials);
                }
            }
            else
            {
                Logger.logDebug(Strings.FAOnlineStatus + HTMLHandler.FAOnlineStatus);
                Logger.logError("FA Connection error. Cannot set UI based on login result");
            }

            tbUsername.Enabled = true;
            tbPassword.Enabled = true;
            btnLogin.Enabled = true;

            btnDownload.Enabled = true;
        }
        #endregion

        ///////////////////////////////////
        // LOGIN HANDLING (NEW, COOKIES) //
        ///////////////////////////////////

        #region
        /// <summary>
        /// (FIX?!) Automatically verify cookies on login
        /// </summary>
        private void autoCookieVerification()
        {
            if (HTMLHandler.connectedToFA)
            {
                if (tbCookieA.Text != null && tbCookieB.Text != null)
                {
                    btnVerifyCookies.PerformClick();
                }
            }
        }

        /// <summary>
        /// Verify Cookies button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerifyCookies_Click(object sender, EventArgs e)
        {
            //HTMLHandler.loggingIn = true;
            //btnVerifyCookies.Enabled = false;
            //setLoggingInUI();

            lblLoginStatus.ForeColor = Color.Orange;
            lblLoginStatus.Text = "Logging in...";


            userCookies = new CookieContainer();
            userCookies.Add(new Cookie("a", tbCookieA.Text, "/", "www.furaffinity.net"));
            userCookies.Add(new Cookie("b", tbCookieB.Text, "/", "www.furaffinity.net"));

            Logger.logStatus("Cookies added:");
            CookieCollection myCookies = userCookies.GetCookies(new Uri("https://www.furaffinity.net/"));
            foreach (Cookie c in myCookies)
            {
                Logger.logStatus("Cookie name: " + c.Name + "\nCookie value: " + c.Value);
            }

            Logger.logStatus("Verifying login...");
            HTMLHandler.logInCheck();

            if (HTMLHandler.loggedIn == true)
            {
                Logger.logStatus(Strings.loginSuccess);
                lblLoginStatus.ForeColor = Color.LightGreen;
                lblLoginStatus.Text = "Cookies are valid!";
                HTMLHandler.overWriteStatuses = false;
                SSIBW_Launch();
                setLoggedInUI();
            }
            else if (HTMLHandler.loggedIn == false)
            {
                HTMLHandler.loggedIn = false;
                Logger.logStatus(Strings.invalidCookies);
                lblLoginStatus.ForeColor = Color.OrangeRed;
                lblLoginStatus.Text = "Cookies are invalid.";
            }

            setLoggedInUI();
            //btnVerifyCookies.Enabled = true;
        }
        #endregion

        ///////////////////////////////
        // RATINGS DOWNLOAD SETTINGS //
        ///////////////////////////////

        #region
        /// <summary>
        /// All Ratings checkbox check changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAllFARatings_CheckedChanged(object sender, EventArgs e)
        {
            cbGeneral.Checked = cbAllFARatings.Checked;
            cbMature.Checked = cbAllFARatings.Checked;
            cbAdult.Checked = cbAllFARatings.Checked;
        }

        /// <summary>
        /// General Ratings checkbox check changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbGeneral_CheckedChanged(object sender, EventArgs e)
        {
            // deal with interaction with all ratings button
            // deal with interaction with all ratings button
            // deal with interaction with all ratings button
            // deal with interaction with all ratings button
            // deal with interaction with all ratings button

            downloadHandler.downloadGeneral = cbGeneral.Checked;
        }

        /// <summary>
        /// Mature Ratings checkbox check changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbMature_CheckedChanged(object sender, EventArgs e)
        {
            // deal with interaction with all ratings button
            // deal with interaction with all ratings button
            // deal with interaction with all ratings button
            // deal with interaction with all ratings button
            // deal with interaction with all ratings button

            downloadHandler.downloadMature = cbMature.Checked;
        }

        /// <summary>
        /// Adult Ratings checkbox check changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAdult_CheckedChanged(object sender, EventArgs e)
        {
            // deal with interaction with all ratings button
            // deal with interaction with all ratings button
            // deal with interaction with all ratings button
            // deal with interaction with all ratings button
            // deal with interaction with all ratings button

            downloadHandler.downloadAdult = cbAdult.Checked;
        }

        /// <summary>
        /// !!! BROKEN Check if All Ratings Checked, busted at the moment
        /// </summary>
        private void checkIfAllRatingsChecked()
        {
            if (cbGeneral.Checked && cbMature.Checked && cbAdult.Checked)
            {
                cbAllFARatings.Checked = true;
            }
            //else if (!cbGeneral.Checked || !cbMature.Checked || !cbAdult.Checked)
            else if (!cbGeneral.Checked && !cbMature.Checked && !cbAdult.Checked) // tidy this up
            {
                cbAllFARatings.Checked = false;
            }
        }
        #endregion

        //////////////////////
        // DOWNLOAD OPTIONS //
        //////////////////////

        #region
        /// <summary>
        /// Download Throttle NUD value changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudDownloadThrottle_ValueChanged(object sender, EventArgs e)
        {
            //Add throttling
            //Add throttling
            //Add throttling
            //Add throttling
            //Add throttling
        }

        /// <summary>
        /// Download Directory Textbox key down, handles enter key setting download directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbDownloadDirectory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Directory.Exists(tbDownloadDirectory.Text))
                {
                    downloadHandler.downloadDir = tbDownloadDirectory.Text;
                    Logger.logStatus("Download folder set to " + tbDownloadDirectory.Text);
                }
                else
                {
                    Logger.logStatus(Strings.invalidDirectory);
                    MessageBox.Show(Strings.invalidDirectory);
                }
                // shuts up the ding
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Download Directory Selection button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFolderSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog downloadDirectorySelector = new FolderBrowserDialog();
            downloadDirectorySelector.Description = "Select your download folder.";
            if (downloadDirectorySelector.ShowDialog() == DialogResult.OK)
            {
                tbDownloadDirectory.Text = (downloadDirectorySelector.SelectedPath);
                Logger.logStatus("Download folder set to " + tbDownloadDirectory.Text);
                downloadHandler.downloadDir = tbDownloadDirectory.Text;
            }
        }

        /// <summary>
        /// Open Download Directory button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenDownloadDir_Click(object sender, EventArgs e)
        {
            downloadHandler.downloadDir = tbDownloadDirectory.Text;

            if (downloadHandler.downloadDir != null
                && Directory.Exists(downloadHandler.downloadDir))
                System.Diagnostics.Process.Start(downloadHandler.downloadDir);
            else
            {
                Logger.logStatus(Strings.invalidDirectory);
                MessageBox.Show(Strings.invalidDirectory);
            }
        }

        /// <summary>
        /// Create Subfolders by Artist checkbox check changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSubfolderByArtistName_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSubfolderByArtistName.Checked)
            {
                Logger.logStatus("Artist subfolders will be created.");
                createArtistSubfolder = true;
            }
            else if (!cbSubfolderByArtistName.Checked)
            {
                Logger.logStatus("Artist subfolders will not be created.");
                createArtistSubfolder = false;
                cbSubfolderBySubmissionType.Checked = false;
            }
        }

        /// <summary>
        /// Create Subfolders By Submission Type checkbox check changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSubfolderBySubmissionType_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSubfolderBySubmissionType.Checked)
            {
                Logger.logStatus("Submission type subfolders will be created.");
                createGalleryTypeSubfolder = true;
                cbSubfolderByArtistName.Checked = true;
            }
            else if (!cbSubfolderBySubmissionType.Checked)
            {
                Logger.logStatus("Submission type subfolders will not be created.");
                createGalleryTypeSubfolder = false;
            }
        }

        /// <summary>
        /// Overwrite Files checkbox check changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbOverwrite_CheckedChanged(object sender, EventArgs e)
        {
            // Implement overwrite
            // Implement overwrite
            // Implement overwrite
            // Implement overwrite
            // Implement overwrite
        }

        /// <summary>
        /// HTML Page Load Delay NUD value change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudHTMLDelay_ValueChanged(object sender, EventArgs e)
        {
            // can I set to 0.5? double cannot be decimal
            if (nudHTMLDelay.Value < (decimal)0.5)
            {
                Logger.logStatus("Page load delay cannot go any lower.");
                MessageBox.Show(Strings.minimumDelayReached);
                nudHTMLDelay.Value = (decimal)0.5;
                Logger.logDebug("Resetting HTML delay field to " + nudHTMLDelay.Value);
            }
            else
            {
                HTMLHandler.htmlDelayLength = Convert.ToInt32(nudHTMLDelay.Value * 4 * 250);
            }
        }

        /// <summary>
        /// Download Delay NUD value change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudDownloadDelay_ValueChanged(object sender, EventArgs e)
        {
            // can I set to 0.5? double cannot be decimal
            if (nudDownloadDelay.Value < (decimal)(0.5))
            {
                Logger.logStatus("Download request delay cannot go any lower.");
                MessageBox.Show(Strings.minimumDelayReached);
                nudDownloadDelay.Value = (decimal)0.5;
                Logger.logDebug("Resetting download delay field to " + nudDownloadDelay.Value);
            }
            else
            {
                downloadHandler.downloadDelayLength = Convert.ToInt32(nudDownloadDelay.Value * 4 * 250);
            }
        }

        /// <summary>
        /// Slect Download Method combobox selection index changed - selects download method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbDownloadMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selected = cbDownloadMethod.SelectedItem.ToString();

            //cbDownloadMethod.Items.Add("Download each file as soon as it's found");
            //cbDownloadMethod.Items.Add("Dig all artist pages, then download all files");

            //if (selected.Contains("Download each file as soon as it's found"))
            if (cbDownloadMethod.SelectedIndex == 0)
            {
                downloadHandler.downloadAfterEachParse = true;
                btnDownload.Enabled = true;
            }
            //else if (selected.Contains("Dig all artist pages, then download all files"))
            else if (cbDownloadMethod.SelectedIndex == 1)
            {
                downloadHandler.downloadAfterEachParse = false;
                btnDownload.Enabled = true;
            }
            else
            {
                btnDownload.Enabled = false;
                Logger.logDebug("Please enter a valid download method.");
            }
        }

        /// <summary>
        /// Download button mouse enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_MouseEnter(object sender, EventArgs e)
        {
            if (!downloadHandler.runningDownloadProcess)
            {
                btnDownload.ForeColor = Color.ForestGreen;
                btnDownload.Text = "LETS DO THIS";
            }
            else
            {
                btnDownload.ForeColor = Color.OrangeRed;
                btnDownload.Text = "CANCEL";
            }
        }

        /// <summary>
        /// Download button mouse leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_MouseLeave(object sender, EventArgs e)
        {
            if (!downloadHandler.runningDownloadProcess)
            {
                btnDownload.ForeColor = Color.ForestGreen;
                btnDownload.Text = "DOWNLOAD";
            }
            else
            {
                btnDownload.ForeColor = Color.OrangeRed;
                btnDownload.Text = "CANCEL";
            }
        }

        /////////////////////
        // DOWNLOAD THREAD //
        /////////////////////

        /// <summary>
        /// Download button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnDownload_Click(object sender, EventArgs e)
        {

            if (!downloadHandler.runningDownloadProcess)
            {
                if (HTMLHandler.connectedToFA)
                {
                    preDownloadVerifyFolder();

                    if (!HTMLHandler.loggedIn)
                    {
                        DialogResult notLoggedInDialog = MessageBox.Show
                            (
                            "You are not logged into FurAffinity."
                            + Environment.NewLine +
                            "Mature and Adult files will not be downloaded."
                            + Environment.NewLine +
                            "Continue with the download?",
                            "Not logged into FurAffinity",
                            MessageBoxButtons.YesNo
                            );

                        if (notLoggedInDialog == DialogResult.Yes)
                        {
                            Program.activeArtistList = Program.myArtistList;
                            DLBW_LauncDialogue();
                        }
                        else if (notLoggedInDialog == DialogResult.No)
                        {
                            downloadHandler.downloadCancelled = true;
                            downloadHandler.runningDownloadProcess = false;
                            setDownloadUI();
                        }


                        else if (notLoggedInDialog == DialogResult.No)
                        {
                            Logger.logStatus("Download will not be started.");
                            setDownloadUI();
                        }
                    }
                    else
                    {
                        Program.activeArtistList = Program.myArtistList;
                        DLBW_LauncDialogue();
                    }
                }
                else
                {
                    Logger.logDebug(Strings.FAOnlineStatus + HTMLHandler.FAOnlineStatus);
                    Logger.logDebug("Cannot begin download");
                }
            }
            else
            {
                Logger.logStatus("Cancelling. Please wait...");
                btnDownload.Enabled = false;
                btnDownload.Visible = false;
                downloadHandler.downloadCancelled = true;
            }
        }

        private void DLBW_LauncDialogue()
        {
            string ConfirmDownload = "";

            if (Program.activeArtistList.Keys.Count > 10)
            {
                ConfirmDownload =
                    (
                    "Download from "
                    + Program.activeArtistList.Keys.Count +
                    " artists?"
                    );

            }
            if (Program.activeArtistList.Keys.Count <= 10)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var item in Program.activeArtistList)
                {
                    sb.AppendFormat("{0}{1}", item.Key, Environment.NewLine);
                }

                string artistListToString = sb.ToString().TrimEnd();

                ConfirmDownload =
                    (
                    "Download from the following artists?"
                    + Environment.NewLine
                    + Environment.NewLine
                    + artistListToString
                    );
            }
            DialogResult confirmDialogue = MessageBox.Show
                    (ConfirmDownload,
                    "Downloading from "
                    + Program.activeArtistList.Keys.Count
                    //+"selected"
                    + " artists",
                    MessageBoxButtons.YesNo
                            );
            if (confirmDialogue == DialogResult.Yes)
            {
                DLBW_Launch();
            }
            else if (confirmDialogue == DialogResult.No)
            {
                downloadHandler.downloadCancelled = true;
                downloadHandler.runningDownloadProcess = false;
                Logger.logStatus("Download will not be started.");
                setDownloadUI();
            }
        }

        /// <summary>
        /// Begin the download process
        /// </summary>
        private void DLBW_Launch()
        {
            downloadHandler.downloadCancelled = false;
            Logger.logStatus("Beginning download process.");
            downloadHandler.downloadDir = tbDownloadDirectory.Text;
            downloadHandler.runningDownloadProcess = true;
            HTMLHandler.dupeHitMax = (int)nudMaxDupes.Value;

            HTMLHandler.htmlDelayLength = Convert.ToInt32(nudHTMLDelay.Value * 4 * 250);
            downloadHandler.downloadDelayLength = Convert.ToInt32(nudDownloadDelay.Value * 4 * 250);

            setDownloadUI();
            updateArtistList();
            URBW_Launch();

            dgvArtistList.Visible = false; // hacky
            lblBigStatus.Text = "Downloading"; // hacky

            // set up ratings
            downloadHandler.downloadGeneral = cbGeneral.Checked;
            downloadHandler.downloadMature = cbMature.Checked;
            downloadHandler.downloadAdult = cbAdult.Checked;

            // set up filter
            HTMLHandler.filterKeywords = cbFilterKeywords.Checked;
            HTMLHandler.filterDescription = cbFilterDescription.Checked;
            HTMLHandler.filterSubmissionTitle = cbFilterSubmissionTitle.Checked;
            HTMLHandler.filterFileName = cbFilterFileName.Checked;
            HTMLHandler.filterComments = cbFilterComments.Checked;

            // set up filtered words array
            HTMLHandler.filteredWords.Clear();
            foreach (string s in lbFilter.Items)
            {
                HTMLHandler.filteredWords.Add(s);
            }

            // set up overwrite
            downloadHandler.overwriteFiles = cbOverwrite.Checked;

            BW_Launch(DLBW);
        }

        /// <summary>
        /// Download (DL) background worker run
        /// </summary>
        private void DLBW_Run()
        {
            if (Thread.CurrentThread.Name == null)
            {
                Thread.CurrentThread.Name = "DLWB";
            }

            HTMLHandler.numCurrentArtist = 0;
            HTMLHandler.numMaxArtist = 0;
            downloadHandler.numCurrentDownload = 0;
            downloadHandler.numMaxDownload = 0;

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("Download Background Worker running")
            ));

            downloadHandler.beginDownload(); // unthreaded
        }

        /// <summary>
        /// Download (DL) background worker completed
        /// </summary>
        private void DLBW_Completed()
        {
            Logger.logDebug("Download Background Worker completed.");
            downloadHandler.runningDownloadProcess = false;
            downloadHandler.downloadCancelled = false;
            if (downloadHandler.downloadCancelled)
            {
                Logger.logStatus("Cancelled.");
            }
            else
            {
                Logger.logDebug("Process was not cancelled, everything should be completed.");
            }

            dgvArtistList.Visible = true; // hacky

            pbPreview.ImageLocation = currentImage;
            pbPreview.LoadAsync(currentImage);
            pbPreview.Refresh();
            setDownloadUI();
        }

        /// <summary>
        /// Sets the UI when Download button is clicked
        /// </summary>
        private void setDownloadUI()
        {
            gbLoginCookies.Enabled
                = !downloadHandler.runningDownloadProcess;
            gbLogin.Enabled
                = !downloadHandler.runningDownloadProcess;
            gbFilterSettings.Enabled
                = !downloadHandler.runningDownloadProcess;
            gbArtistSettings.Enabled
                = !downloadHandler.runningDownloadProcess;
            dgvArtistList.Visible
                = !downloadHandler.runningDownloadProcess;

            //// make invis?
            //gbLogin.Visible
            //    = !downloadHandler.runningDownloadProcess;
            //gbFilterSettings.Visible
            //    = !downloadHandler.runningDownloadProcess;
            //gbArtistSettings.Visible
            //    = !downloadHandler.runningDownloadProcess;

            lblDownloadDir.Enabled
                = !downloadHandler.runningDownloadProcess;
            tbDownloadDirectory.Enabled
                = !downloadHandler.runningDownloadProcess;
            btnFolderSelect.Enabled
                = !downloadHandler.runningDownloadProcess;
            btnOpenDownloadDir.Enabled
                = !downloadHandler.runningDownloadProcess;
            cbSubfolderByArtistName.Enabled
                = !downloadHandler.runningDownloadProcess;
            cbSubfolderBySubmissionType.Enabled
                = !downloadHandler.runningDownloadProcess;
            cbOverwrite.Enabled
                = !downloadHandler.runningDownloadProcess;
            cbDownloadMethod.Enabled
                = !downloadHandler.runningDownloadProcess;
            lblMaxDupes.Enabled
                = !downloadHandler.runningDownloadProcess;
            nudMaxDupes.Enabled
                = !downloadHandler.runningDownloadProcess;


            if (downloadHandler.runningDownloadProcess)
            {
                btnDownload.ForeColor = Color.OrangeRed;
                btnDownload.Text = "CANCEL";
                lblBigStatus.Text = "Downloading";
            }
            else if (!downloadHandler.runningDownloadProcess)
            {
                btnDownload.Visible = true;
                btnDownload.Enabled = true;

                btnDownload.ForeColor = Color.ForestGreen;
                btnDownload.Text = "DOWNLOAD";
                lblBigStatus.Text = "Not running downloads";
            }
        }

        /// <summary>
        /// Pre-Download Download Directory Verification
        /// </summary>
        public void preDownloadVerifyFolder()
        {
            if (!Directory.Exists(tbDownloadDirectory.Text))
            {
                downloadHandler.directoryIsValid = false;
                Logger.logStatus(Strings.invalidDirectory);
                MessageBox.Show("Valid directory not specified.");
                //setUI();
            }
            else
            {
                downloadHandler.directoryIsValid = true;
                Logger.logStatus("Valid directory specified: " + downloadHandler.downloadDir);
                //setUI();
            }
        }
        #endregion

        ////////////////
        // OUTPUT LOG //
        ////////////////

        #region
        /// <summary>
        /// All Logging Levels checkbox check changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAllLoggingLevels_CheckedChanged(object sender, EventArgs e)
        {
            cbDebug.Checked = cbAllLoggingLevels.Checked;
            cbErrors.Checked = cbAllLoggingLevels.Checked;
            cbStatus.Checked = cbAllLoggingLevels.Checked;
            cbDownloads.Checked = cbAllLoggingLevels.Checked;
        }

        /// <summary>
        /// Debug Logging checkbox check changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbDebug_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDebug.Checked)
            {
                Logger.logStatus("Debug logging enabled.");
                Logger.debugLogging = true;
            }
            else if (!cbDebug.Checked)
            {
                Logger.logStatus("Debug logging disabled.");
                Logger.debugLogging = false;
            }
            checkIfAllLoggingChecked();
        }

        /// <summary>
        /// Error Logging checkbox check changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbErrors_CheckedChanged(object sender, EventArgs e)
        {
            if (cbErrors.Checked)
            {
                Logger.logStatus("Error logging enabled.");
                Logger.errorLogging = true;
            }
            else if (!cbErrors.Checked)
            {
                Logger.logStatus("Error logging disabled.");
                Logger.errorLogging = false;
            }
            checkIfAllLoggingChecked();
        }

        /// <summary>
        /// Status Logging checkbox check changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStatus.Checked)
            {
                Logger.logStatus("Status logging enabled.");
                Logger.statusLogging = true;
            }
            else if (!cbStatus.Checked)
            {
                Logger.logStatus("Status logging disabled.");
                Logger.statusLogging = false;
            }
            checkIfAllLoggingChecked();
        }

        /// <summary>
        /// Download Logging checkbox check changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbDownloads_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDownloads.Checked)
            {
                Logger.logStatus("Download logging enabled.");
                Logger.downloadLogging = true;
            }
            else if (!cbDownloads.Checked)
            {
                Logger.logStatus("Download logging disabled.");
                Logger.downloadLogging = false;
            }
            checkIfAllLoggingChecked();
        }

        /// <summary>
        /// This is broken, delete/fix up
        /// </summary>
        private void checkIfAllLoggingChecked()
        {
            if (cbDebug.Checked && cbStatus.Checked && cbErrors.Checked && cbDownloads.Checked)
            {
                cbAllLoggingLevels.Checked = true;
            }
            //else if (!cbDebug.Checked || !cbStatus.Checked || !cbErrors.Checked || !cbDownloads.Checked)
            else if
                (!cbDebug.Checked
                && !cbStatus.Checked
                && !cbErrors.Checked
                && !cbDownloads.Checked
                ) // tidy this up
            {
                cbAllLoggingLevels.Checked = false;
            }
        }

        /// <summary>
        /// Clear Output Log button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearOutput_Click(object sender, EventArgs e)
        {
            Logger.logDebug("===========");
            Logger.logDebug("LOG CLEARED");
            Logger.logDebug("===========");

            lbOutput.Items.Clear();
        }

        /// <summary>
        /// Copy Output to Clipboard button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopyOutputToClipboard_Click(object sender, EventArgs e)
        {
            string s1 = "";
            foreach (object item in lbOutput.Items) s1 += item.ToString() + "\r\n";
            Clipboard.SetText(s1);
        }

        /* // missing CreateLog checkbox
        private void cbCreateLog_CheckedChanged(object sender, EventArgs e)
        {

        }
           
        */
        #endregion

        //////////////////////
        // FIILTER SETTINGS //
        //////////////////////

        #region
        /// <summary>
        /// Filter Textbox keypress, enter key adds word in text box to filter list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbAddToFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                addWordToFilter();
                tbAddToFilter.Clear();
            }
        }

        /// <summary>
        /// Add to Filter button click, adds word in text box to filter list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddToFilter_Click(object sender, EventArgs e)
        {
            addWordToFilter();
            tbAddToFilter.Clear();
        }

        /// <summary>
        /// Add word to filter function, adds word in text box to filter list
        /// </summary>
        private void addWordToFilter()
        {
            HashSet<string> exists = new HashSet<string>();

            foreach (string s in lbFilter.Items)
            {
                exists.Add(s);
            }
            if (!exists.Contains(tbAddToFilter.Text))
            {
                Logger.logStatus(tbAddToFilter.Text + " added to filter.");
                lbFilter.Items.Add(tbAddToFilter.Text);
            }
            else
            {
                Logger.logStatus(tbAddToFilter.Text + " already exists in filter.");
            }
        }

        /// <summary>
        /// Filter List Box keydown, delete key calls remove words from filter function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                removeWordsFromFilter();
            }
        }

        /// <summary>
        /// Remove words from filter button click, calls remove words from filter function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveFilteredWord_Click(object sender, EventArgs e)
        {
            removeWordsFromFilter();
        }

        /// <summary>
        /// Removes words from filter
        /// </summary>
        private void removeWordsFromFilter()
        {
            for (int i = lbFilter.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lbFilter.Items.RemoveAt(lbFilter.SelectedIndices[i]);
            }
        }

        /// <summary>
        /// Filter All checkbox check change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFilterAll_CheckedChanged(object sender, EventArgs e)
        {
            cbFilterComments.Checked = cbFilterAll.Checked;
            cbFilterDescription.Checked = cbFilterAll.Checked;
            cbFilterKeywords.Checked = cbFilterAll.Checked;
            cbFilterSubmissionTitle.Checked = cbFilterAll.Checked;
            cbFilterFileName.Checked = cbFilterAll.Checked;
        }

        /// <summary>
        /// Filter Comments checkbox check change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFilterComments_CheckedChanged(object sender, EventArgs e)
        {
            // deal with interaction with filter all button
            // deal with interaction with filter all button
            // deal with interaction with filter all button
            // deal with interaction with filter all button
            // deal with interaction with filter all button
        }

        /// <summary>
        /// Filter Submission Title checkbox check change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFilterSubmissionTitle_CheckedChanged(object sender, EventArgs e)
        {
            // deal with interaction with filter all button
            // deal with interaction with filter all button
            // deal with interaction with filter all button
            // deal with interaction with filter all button
            // deal with interaction with filter all button
        }

        /// <summary>
        /// Filter Description checkbox check change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFilterDescription_CheckedChanged(object sender, EventArgs e)
        {
            // deal with interaction with filter all button
            // deal with interaction with filter all button
            // deal with interaction with filter all button
            // deal with interaction with filter all button
            // deal with interaction with filter all button
        }

        /// <summary>
        /// Filter File Name checkbox check change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFilterFileName_CheckedChanged(object sender, EventArgs e)
        {
            // deal with interaction with filter all button
            // deal with interaction with filter all button
            // deal with interaction with filter all button
            // deal with interaction with filter all button
            // deal with interaction with filter all button
        }
        #endregion

        /////////////////
        // PICTURE BOX //
        /////////////////

        #region
        /// <summary>
        /// Preview Picture Box click, opens image shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbPreview_Click(object sender, EventArgs e)
        {
            //if not default image, open the shown image
            //if not default image, open the shown image
            //if on default image, play "OH BOY!!!"
            //if on default image, play "OH BOY!!!"
            if (downloadHandler.runningDownloadProcess)
            {
                if (downloadHandler.downloadedImage != null
                    && File.Exists(downloadHandler.downloadedImage))
                {
                    Logger.logStatus("Opening " + downloadHandler.downloadedImage);
                    System.Diagnostics.Process.Start(downloadHandler.downloadedImage);
                }
                else
                {
                    ASBW_Launch();
                }

            }
            else if (!downloadHandler.runningDownloadProcess)
            {
                ASBW_Launch();
            }
        }

        /// <summary>
        /// Preview Picture Box Mouse Enter - Changes cursor to hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbPreview_MouseEnter(object sender, EventArgs e)
        {
            pbPreview.Cursor = Cursors.Hand;
        }
        #endregion

        ///////////////////////////////
        // UPDATE PICTURE BOX THREAD //
        ///////////////////////////////

        #region
        /// <summary>
        /// Update Picture Box (UPB) background worker - launch
        /// </summary>
        /// <param name="downloadedImage"></param>
        public void UPBBW_Launch(string downloadedImage)
        {
            BW_Launch(UPBBW);
        }

        /// <summary>
        /// Update Picture Box (UPB) background worker - running
        /// </summary>
        /// <param name="imageLocation"></param>
        public void UPBBW_Run(string downloadedImage)
        {
            if (Thread.CurrentThread.Name == null)
                Thread.CurrentThread.Name = "UPBBW";

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("Update Picture Box Background Worker running")
                ));

            if (HTMLHandler.connectedToFA)
            {
                if
                    (downloadedImage.Contains(".jpg")
                    || downloadedImage.Contains(".gif")
                    || downloadedImage.Contains(".png")
                    || downloadedImage.Contains(".jpeg"))
                {
                    Program.mainForm.pbPreview.BeginInvoke(new Action(() =>
                    pbPreview.LoadAsync(downloadedImage)
                    ));
                }
                else if
                    (downloadedImage.Contains("mid")
                    || downloadedImage.Contains(".wav")
                    || downloadedImage.Contains(".mp3")
                    || downloadedImage.Contains(".mpeg"))
                {
                    Program.mainForm.pbPreview.BeginInvoke(new Action(() =>
                    pbPreview.Image = Resources.Music
                    ));
                }
                else if
                    (downloadedImage.Contains(".doc")
                    || downloadedImage.Contains(".docx")
                    || downloadedImage.Contains(".rtf")
                    || downloadedImage.Contains(".txt")
                    || downloadedImage.Contains(".pdf")
                    || downloadedImage.Contains(".odt"))
                {
                    Program.mainForm.pbPreview.BeginInvoke(new Action(() =>
                    pbPreview.Image = Resources.Writing
                    ));
                }
                else if (downloadedImage.Contains(".swf"))
                {
                    Program.mainForm.pbPreview.BeginInvoke(new Action(() =>
                    pbPreview.Image = Resources.SWF
                    ));
                }
                else if (downloadedImage.Contains(".html"))
                {
                    Program.mainForm.pbPreview.BeginInvoke(new Action(() =>
                    pbPreview.Image = Resources.Journals
                    ));
                }
                else
                {
                    Program.mainForm.pbPreview.BeginInvoke(new Action(() =>
                    pbPreview.Image = Resources.Image_Not_Found
                    ));
                }
            }
            else
            {
                setConnectionUI(HTMLHandler.connectedToFA, HTMLHandler.FAOnlineStatus);
            }
        }

        /// <summary>
        /// Update Picture Box (UPB) background worker - completed
        /// </summary>
        /// <param name="imageLocation"></param>
        public void UPBBW_Completed(string imageLocation)
        {
            Logger.logDebug("Update Picture Box Background Worker completed");
        }
        #endregion

        /////////////////////////
        // AUDIO STREAM THREAD //
        /////////////////////////

        #region
        /// <summary>
        /// Audio Stream (AS) background worker - launch
        /// </summary>
        public void ASBW_Launch()
        {
            BW_Launch(ASBW);
        }

        /// <summary>
        /// Audio Stream (AS) background worker - running
        /// </summary>
        public void ASBW_Run()
        {
            if (Thread.CurrentThread.Name == null)
            {
                Thread.CurrentThread.Name = "ASBW";
            }

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("Audio Stream Background Worker running")
            ));

            PlayMp3FromUrl(currentSoundClip); // unthreaded
        }

        /// <summary>
        /// Audio Stream (AS) background worker -  completed
        /// </summary>
        public void ASBW_Completed()
        {
            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("Audio Stream Background Worker completed")
            ));
        }

        // Source: http://stackoverflow.com/questions/184683/play-audio-from-a-stream-using-c-sharp
        // Using NAudio by Mark Heath
        /// <summary>
        /// Plays MP3/Wav when picture box is clicked
        /// </summary>
        /// <param name="url"></param>
        public static void PlayMp3FromUrl(string url)
        {
            using (Stream ms = new MemoryStream())
            {
                using (Stream stream = WebRequest.Create(url)
                    .GetResponse().GetResponseStream())
                {
                    byte[] buffer = new byte[32768];
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                }
                ms.Position = 0;
                using (WaveStream blockAlignedStream =
                    new BlockAlignReductionStream(
                        WaveFormatConversionStream.CreatePcmStream(
                            new Mp3FileReader(ms))))
                {
                    using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                    {
                        waveOut.Init(blockAlignedStream);
                        waveOut.Play();
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            System.Threading.Thread.Sleep(100);
                        }
                    }
                }
            }
        }
        #endregion

        //////////////////
        // ABOUT BUTTON //
        //////////////////

        #region
        /// <summary>
        /// About Button click, creates new thread and launches About form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbout_Click(object sender, EventArgs e)
        {
            Thread aw = new Thread(launchAboutWindow);
            aw.Name = "aboutWindow";
            aw.Start();
        }

        /// <summary>
        /// Launches About Window, called from About Button click
        /// </summary>
        private void launchAboutWindow()
        {
            aboutForm aboutForm = new aboutForm();
            aboutForm.ShowDialog();
        }
        #endregion

        ////////////////
        // DEBUG SHIT //
        ////////////////

        #region
        #endregion

        /////////////////////
        // SETTINGS SAVING //
        /////////////////////

        #region

        /// <summary>
        /// Form closing - saves settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downloaderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isClosing = true;
            URBW_Launch(); //thcold
            saveSettings();

        }

        /// <summary>
        /// Save the user settings
        /// </summary>
        private void saveSettings()
        {
            // Artist list
            string artistListDictionaryString = JsonConvert.SerializeObject(Program.myArtistList);
            Settings.Default.artistListJSON = artistListDictionaryString;

            // Filter list box
            using (StreamWriter file = new StreamWriter("filter"))
            {
                foreach (var item in lbFilter.Items)
                {
                    file.WriteLine(item.ToString());
                }
            }

            // Write values to settings
            if (this.WindowState == FormWindowState.Normal)
            {
                Settings.Default.formSize = this.Size;
            }
            Settings.Default.tbUsername = this.tbUsername.Text;
            Settings.Default.tbPassword = this.tbPassword.Text; // opt out?
            Settings.Default.tbCookieA = this.tbCookieA.Text;
            Settings.Default.tbCookieB = this.tbCookieB.Text;
            Settings.Default.cbLogInOnLaunch = this.cbLogInOnLaunch.Checked;
            Settings.Default.cbShowPassword = this.cbShowPassword.Checked;
            Settings.Default.cbAllFARatings = this.cbAllFARatings.Checked;
            Settings.Default.cbGeneral = this.cbGeneral.Checked;
            Settings.Default.cbMature = this.cbMature.Checked;
            Settings.Default.cbAdult = this.cbAdult.Checked;
            Settings.Default.cbAllGalleryTypes = this.cbAllGalleryTypes.Checked;
            Settings.Default.cbGallery = this.cbGallery.Checked;
            Settings.Default.cbScraps = this.cbScraps.Checked;
            Settings.Default.cbFavorites = this.cbFavorites.Checked;
            Settings.Default.cbJournals = this.cbJournals.Checked;
            Settings.Default.lbFilter = this.lbFilter.Text; // how does this listbox save?
            Settings.Default.cbFilterall = this.cbFilterAll.Checked;
            Settings.Default.cbFilterKeywords = this.cbFilterKeywords.Checked;
            Settings.Default.cbFilterDescription = this.cbFilterDescription.Checked;
            Settings.Default.cbFilterComments = this.cbFilterComments.Checked; // why error
            Settings.Default.cbFilterSubmissionTitle = this.cbFilterSubmissionTitle.Checked;
            Settings.Default.cbFilterFileName = this.cbFilterFileName.Checked;
            Settings.Default.cbAllLoggingLevels = this.cbAllLoggingLevels.Checked;
            Settings.Default.cbErrors = this.cbErrors.Checked;
            Settings.Default.cbStatus = this.cbStatus.Checked;
            Settings.Default.cbDownloads = this.cbDownloads.Checked;
            Settings.Default.cbDebug = this.cbDebug.Checked;
            Settings.Default.cbDownloadMethod = this.cbDownloadMethod.SelectedIndex;
            Settings.Default.nudMaxDupes = (int)this.nudMaxDupes.Value;
            Settings.Default.potentiallyBadFile = downloadHandler.potentiallyBadFile;

            if (this.nudHTMLDelay.Value < (decimal)0.5)
            {
                Settings.Default.nudHTMLDelay = (decimal)0.5;
            }
            else
            {
                Settings.Default.nudHTMLDelay = this.nudHTMLDelay.Value; // why error
            }
            if (this.nudDownloadDelay.Value < (decimal)0.5)
            {
                Settings.Default.nudDownloadDelay = (decimal)0.5;
            }
            else
            {
                Settings.Default.nudDownloadDelay = this.nudDownloadDelay.Value; // why error
            }

            Settings.Default.tbDownloadDirectory = this.tbDownloadDirectory.Text;
            Settings.Default.cbSubFolderByArtistName = this.cbSubfolderByArtistName.Checked;
            Settings.Default.cbSubFolderBySubmissionType = this.cbSubfolderBySubmissionType.Checked;
            Settings.Default.cbOverwrite = this.cbOverwrite.Checked;

            // Finally, save all
            Settings.Default.Save();
        }

        /// <summary>
        /// Load the user settings
        /// </summary>
        private void loadSettings()
        {
            //Artist list
            if (Program.myArtistList != null)
            {
                var stringToDictionary = JsonConvert.DeserializeObject<Dictionary<String, ArtistObject>>(Settings.Default.artistListJSON);

                //THCOLD
                if (stringToDictionary != null)
                {
                    Program.myArtistList = stringToDictionary;
                }
            }

            // Filter list box:
            if (File.Exists("filter"))
            {
                string[] lines = File.ReadAllLines("filter");
                foreach (string line in lines)
                {
                    lbFilter.Items.Add(line);
                }
            }


            // Reads values from settings
            if (Settings.Default.formSize.Width != 0 && Settings.Default.formSize.Height != 0)
            {
                this.Size = Properties.Settings.Default.formSize;
                // or
                // Settings.Default["FormSize"] = this.Size;
                // Settings.Default.Save(); //don't need to save?
            }
            this.tbUsername.Text = Settings.Default.tbUsername;
            this.tbPassword.Text = Settings.Default.tbPassword; // opt out?
            this.tbCookieA.Text = Settings.Default.tbCookieA;
            this.tbCookieB.Text = Settings.Default.tbCookieB;
            this.cbLogInOnLaunch.Checked = Settings.Default.cbLogInOnLaunch;
            this.cbShowPassword.Checked = Settings.Default.cbShowPassword;
            this.cbAllFARatings.Checked = Settings.Default.cbAllFARatings;
            this.cbGeneral.Checked = Settings.Default.cbGeneral;
            this.cbMature.Checked = Settings.Default.cbMature;
            this.cbAdult.Checked = Settings.Default.cbAdult;
            this.cbAllGalleryTypes.Checked = Settings.Default.cbAllGalleryTypes;
            this.cbGallery.Checked = Settings.Default.cbGallery;
            this.cbScraps.Checked = Settings.Default.cbScraps;
            this.cbFavorites.Checked = Settings.Default.cbFavorites;
            this.cbJournals.Checked = Settings.Default.cbJournals;
            this.lbFilter.Text = Settings.Default.lbFilter; // how does this listbox save?
            this.cbFilterAll.Checked = Settings.Default.cbFilterall;
            this.cbFilterKeywords.Checked = Settings.Default.cbFilterKeywords;
            this.cbFilterDescription.Checked = Settings.Default.cbFilterDescription;
            this.cbFilterComments.Checked = Settings.Default.cbFilterComments;
            this.cbFilterSubmissionTitle.Checked = Settings.Default.cbFilterSubmissionTitle;
            this.cbFilterFileName.Checked = Settings.Default.cbFilterFileName;
            this.cbAllLoggingLevels.Checked = Settings.Default.cbAllLoggingLevels;
            this.cbErrors.Checked = Settings.Default.cbErrors;
            this.cbStatus.Checked = Settings.Default.cbStatus;
            this.cbDownloads.Checked = Settings.Default.cbDownloads;
            this.cbDebug.Checked = Settings.Default.cbDebug;
            this.cbDownloadMethod.SelectedIndex = Settings.Default.cbDownloadMethod;
            downloadHandler.potentiallyBadFile = Settings.Default.potentiallyBadFile;

            if (Settings.Default.nudHTMLDelay < (decimal)0.5)
            {
                this.nudHTMLDelay.Value = (decimal)0.5;
            }
            else
            {
                this.nudHTMLDelay.Value = Settings.Default.nudHTMLDelay; // why error
            }
            if (Settings.Default.nudDownloadDelay < (decimal)0.5)
            {
                this.nudDownloadDelay.Value = (decimal)0.5;
            }
            else
            {
                this.nudDownloadDelay.Value = Settings.Default.nudDownloadDelay; // why error
            }

            this.tbDownloadDirectory.Text = Settings.Default.tbDownloadDirectory;
            this.cbSubfolderByArtistName.Checked = Settings.Default.cbSubFolderByArtistName;
            this.cbSubfolderBySubmissionType.Checked = Settings.Default.cbSubFolderBySubmissionType;
            this.nudMaxDupes.Value = Settings.Default.nudMaxDupes;
            this.cbOverwrite.Checked = Settings.Default.cbOverwrite;
        }
        #endregion

        private void cbStatusAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}