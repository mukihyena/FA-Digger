////////////////
// Scrap Paper//
////////////////
/*
        // For notes and shit
*/

// Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; // testing multithreading
using System.Net; // for internet
using System.Diagnostics; // in case I need to run something
using System.IO; // File handling
using System.Collections; // more file handling
//using System.Windows.Forms; // to call back to forms
using HtmlAgilityPack; // For parsing journal name

//Pervdragon DownloadHandler rework
namespace FADownloader
{
    static class downloadHandler
    {
        //////////////////////
        // GLOBAL VARIABLES //
        //////////////////////

        #region
        //System
        public static bool directoryIsValid = true;
        public static string downloadDir = ""; // download folder selected in UI
        public static HashSet<string> existingFileNames = new HashSet<string>();
        public static string potentiallyBadFile = null; // potenitally bad file to be deleted

        // States
        public static bool runningDownloadProcess = false; // Detect if we're downloading, set UI accordingly
        public static bool downloadCancelled = false; // Detect if user has cancelled. hook up for htmlhandler?

        // Settings
        public static int downloadDelayLength = 0; // Delay length between downloads
        public static bool overwriteFiles = false; // check if we should overwrite
        public static bool downloadAfterEachParse = false;

        // Picture box/latest image to delete if crash/close
        public static string downloadedImage;

        // UI
        public static int numCurrentDownload = 0;
        public static int numMaxDownload = 0;

        // Ratings
        public static bool downloadGeneral = false;
        public static bool downloadMature = false;
        public static bool downloadAdult = false;
        #endregion

        ///////////////
        // INITIATOR //
        ///////////////

        #region           
        /// <summary>
        /// Begin the Download process
        /// </summary>
        public static void beginDownload()//rename this after cleanup
        {
            if (checkifDownloadCancelled())
            {
                return;
            }
            if (!verifyDownloadDirectory())
            {
                return;
            }
            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDownload("DOWNLOAD PROCESS COMMENCED")
            ));

            numMaxDownload = 0;

            // setup
            setExistingFiles();
            resetDownloadLinks();
            trimArtistList();

            Program.mainForm.lblDownloadingFile.BeginInvoke(new Action(() =>
            Program.mainForm.lblDownloadingFile.ForeColor = System.Drawing.Color.Orange
            ));

            Program.mainForm.lbDownloadProgress.BeginInvoke(new Action(() =>
            Program.mainForm.lbDownloadProgress.ForeColor = System.Drawing.Color.Orange
            ));

            // download
            HTMLHandler.dig();
            if (!HTMLHandler.faIsInBeta)    // BETA UNSUPPORTED
            {                               // BETA UNSUPPORTED
                if (!downloadAfterEachParse)
                {
                    artistSetup();
                }
            }                               // BETA UNSUPPORTED

            downloadCompleteCleanup();

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDownload("YOU'RE DONE SON")
            ));
        }
        #endregion

        ///////////
        // SETUP //
        ///////////

        #region
        /// <summary>
        /// Verify the folder before proceeding.
        /// </summary>
        public static bool verifyDownloadDirectory()
        {
            if (checkifDownloadCancelled())
            {
                return false;
            }
            if (Directory.Exists(downloadDir))
            {
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logStatus(
                    "Selected Download directory "
                    + downloadDir +
                    " exists, proceeding with download.")
                ));
                /*HTMLHandler.dig
                    (
                    (downloaderForm.htmlDelayLength * 1000),
                    new List<string>(),
                    new List<string>(),
                    false,
                    false,
                    true,
                    "string",
                    "string",
                    "http://furaffinity.net/scraps/",
                    "http://furaffinity.net/favorites/",
                    "http://furaffinity.net/journals/"
                    );*/
                return true;
            }
            else
            {
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logError("Your selected download directory does not exist.")
                ));
                return false;
            }
        }

        /// <summary>
        /// Create a list of existing files in our download directory
        /// </summary>
        public static void setExistingFiles()
        {
            // populate the hashset with fileinfos

            // refresh file names
            existingFileNames.Clear();

            DirectoryInfo di = new DirectoryInfo(downloadDir);
            FileInfo[] fileInfos = di.GetFiles("*", SearchOption.AllDirectories);

            foreach (FileInfo existingFile in fileInfos)
            {
                if (checkifDownloadCancelled())
                {
                    return;
                }
                existingFileNames.Add(//"/" + 
                    existingFile.Name);
            }
            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("All existing files grabbed")
            ));
        }

        /// <summary>
        /// Reset the download links for the download process
        /// </summary>
        public static void resetDownloadLinks()
        {
            if (checkifDownloadCancelled())
            {
                return;
            }
            foreach (ArtistObject artist in Program.myArtistList.Values)
            {
                if (checkifDownloadCancelled())
                {
                    return;
                }
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                    Logger.logDebug("Clearing " + artist + "'s file links...")
                    ));

                artist.galleryFileLinks.Clear();
                artist.scrapsFileLinks.Clear();
                artist.favoritesFileLinks.Clear();
                artist.journalsFileLinks.Clear();
            }
        }

        /// <summary>
        /// Strip out arists we don't need
        /// </summary>
        private static void trimArtistList()
        {
            Dictionary<String, ArtistObject> croppedList
                = new Dictionary<String, ArtistObject>();

                foreach (ArtistObject artist in Program.activeArtistList.Values)
            {
                croppedList.Add(artist.artistName, Program.myArtistList[artist.artistName]);
            }

            foreach (ArtistObject artist in Program.activeArtistList.Values)
            {
                if
                    (!artist.downloadGallery
                    && !artist.downloadScraps
                    && !artist.downloadFavorites
                    && !artist.downloadJournals
                    )
                {
                    croppedList.Remove(artist.artistName);
                }
            }
            Program.activeArtistList = croppedList;
        }
        #endregion

        /////////////////
        // DOWNLOADING //
        /////////////////

        #region
        /// <summary>
        /// Set up the artists, download the relevant files
        /// </summary>
        public static void artistSetup()
        {
            if (checkifDownloadCancelled())
            {
                return;
            }
            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("Initializing setup for each artist.")
            ));

            foreach (ArtistObject artist in Program.activeArtistList.Values)
            {
                if (checkifDownloadCancelled())
                {
                    return;
                }

                downloadFilesFromURLs(artist, SubmissionType.Gallery);
                downloadFilesFromURLs(artist, SubmissionType.Scraps);
                downloadFilesFromURLs(artist, SubmissionType.Favorites);
                downloadFilesFromURLs(artist, SubmissionType.Journals);
            }
        }

        /// <summary>
        /// Download the files in the list
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="subType"></param>
        public static void downloadFilesFromURLs(ArtistObject artist, SubmissionType subType)
        {
            if (checkifDownloadCancelled())
            {
                return;
            }
            ArrayList linksToDownload;
            string galleryType = "";
            switch (subType)
            {
                case SubmissionType.Gallery:
                    linksToDownload = artist.galleryFileLinks;
                    galleryType = "Gallery";
                    break;
                case SubmissionType.Scraps:
                    linksToDownload = artist.scrapsFileLinks;
                    galleryType = "Scraps";
                    break;
                case SubmissionType.Favorites:
                    linksToDownload = artist.favoritesFileLinks;
                    galleryType = "Favorites";
                    break;
                case SubmissionType.Journals:
                    linksToDownload = artist.journalsFileLinks;
                    galleryType = "Journals";
                    break;
                default:
                    linksToDownload = new ArrayList();
                    galleryType = "ERROR";
                    break;
            }

            // Setup the local download folder (create if necessary)
            string downloadFolder = downloadLocalFolderSetup
                (
                artist.artistName,
                galleryType,
                linksToDownload.Count
                );

            if (linksToDownload.Count == 0)
            {
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logStatus(
                    "Skipping "
                    + artist.artistName + "'s "
                    + galleryType)
                ));
            }
            else
            {
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logDownload(
                "Downloading "
                + linksToDownload.Count + " " + galleryType +
                " submissions for "
                + artist.artistName +
                " to " + downloadFolder)
                ));
            }

            foreach (string submissionURL in linksToDownload)
            {
                //numCurrentDownload++; // moved

                if (checkifDownloadCancelled())
                {
                    return;
                }
                string fileName = "";

                // download the journal HTML doc
                if (galleryType == "Journals")
                {
                    HtmlWeb hw = new HtmlWeb();
                    var client = new cookieHandler.MyWebClient();
                    HtmlDocument HTMLDoc
                        = client.GetPageWithCookies((submissionURL),
                        downloaderForm.userCookies);

                    string uncroppedJournalName
                        = HTMLDoc.DocumentNode.SelectSingleNode("//title[text()]").InnerText;

                    string journalName = uncroppedJournalName.Remove
                        (uncroppedJournalName.Length - 40);

                    // remove invalid characters from journal title
                    foreach (string invalidCharacter in HTMLHandler.invalidCharacters)
                        if (!checkifDownloadCancelled())
                        {
                            {
                                journalName = journalName.Replace(invalidCharacter, "_");
                            }
                            journalName = journalName.Replace("&#39;", "'");
                            fileName = ("/" + journalName + ".html");
                        }
                }
                else
                {
                    fileName = ("/" + Path.GetFileName(new Uri(submissionURL).LocalPath));
                    //string fileName = ("/" + Path.GetFileName(new Uri(submissionURL).LocalPath));
                }

                numCurrentDownload++; // moved
                // Check to see if we should download the file, then download it if so
                downloadFile(submissionURL, downloadFolder, fileName); //, galleryType);
            }
        }

        /// <summary>
        /// Set up the local folder structure for the file based on what's ticked in the UI
        /// </summary>
        /// <param name="submissionURL"></param>
        /// <param name="artistName"></param>
        /// <param name="type"></param>
        public static string downloadLocalFolderSetup
            (
            string artistName,
            string galleryType,
            int linksToDownloadCount
            )
        {
            if (checkifDownloadCancelled())
            {
                return null;
            }
            DirectoryInfo DI = new DirectoryInfo(downloadDir); // get directory info for downloadDir
            string downloadDestinationFolder = "";

            // If we should create artist subfolder,
            if (downloaderForm.createArtistSubfolder)
            {
                DI.CreateSubdirectory(artistName);
                downloadDestinationFolder = (downloadDir + @"\" + artistName);

                // AND a gallery type subfolder, and we don't have 0 links to download,
                if (downloaderForm.createGalleryTypeSubfolder && linksToDownloadCount != 0)
                {
                    DI.CreateSubdirectory(artistName + @"\" + galleryType);
                    downloadDestinationFolder = (downloadDir + @"\" + artistName + @"\" + galleryType);
                }
            }
            else if (!downloaderForm.createArtistSubfolder && !downloaderForm.createGalleryTypeSubfolder)
            {
                downloadDestinationFolder = (downloadDir);
            }
            return downloadDestinationFolder;
        }

        /// <summary>
        /// Download the actual file!!
        /// </summary>
        /// <param name="submissionURL"></param>
        /// <param name="downloadDestinationFolder"></param>
        /// <param name="fileName"></param>
        public static void downloadFile
            (
            string submissionURL,
            string downloadDestinationFolder,
            string fileName//,
            //string galleryType // possibly can delete this
            )
        {
            if (checkifDownloadCancelled())
            {
                return;
            }

            Thread.Sleep(downloadDelayLength);

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDownload(
                "Downloading file "
                + downloadDestinationFolder + fileName +
                " from "
                + submissionURL)
                ));

            //numCurrentDownload++; // moving...

            Program.mainForm.lbDownloadProgress.BeginInvoke(new Action(() =>
            Program.mainForm.lbDownloadProgress.Text
            = (numCurrentDownload + " of " + numMaxDownload)
            ));

            try
            {
                WebClient wc = new WebClient(); // Initialize a new web client for this download
                wc.DownloadFile(submissionURL, (downloadDestinationFolder + fileName));
            }
            catch
            {
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logError("Download failed??")
                ));
            }
            // fix image name
            downloadedImage = (downloadDestinationFolder + fileName);
            string imageLocationKindaFixed = downloadedImage.Replace("\\", "/");
            downloadedImage = imageLocationKindaFixed;

            potentiallyBadFile = imageLocationKindaFixed; // if we exit during download, this will be deleted
            Properties.Settings.Default.potentiallyBadFile = potentiallyBadFile; // save this to settings

            if (//type != "Journals" &&
                downloadedImage != null &&
                File.Exists(downloadedImage))
            {
                Program.mainForm.UPBBW_Launch(downloadedImage);
            }
        }

        public static void downloadCompleteCleanup()
        {
            potentiallyBadFile = null;  // reset potentially bad file upon completion of download process
            Properties.Settings.Default.potentiallyBadFile = potentiallyBadFile; // save this to settings

            IOHandler.removeEmptyArtistDirectories(downloadDir);

            Program.mainForm.lblDownloadingFile.BeginInvoke(new Action(() =>
            Program.mainForm.lblDownloadingFile.ForeColor = System.Drawing.Color.LightGreen
            ));

            Program.mainForm.lbDownloadProgress.BeginInvoke(new Action(() =>
            Program.mainForm.lbDownloadProgress.ForeColor = System.Drawing.Color.LightGreen
            ));
        }
        #endregion

        ////////////
        // CHECKS //
        ////////////

        #region
        /// <summary>
        /// Check if user has cancelled the operation
        /// </summary>
        /// <returns></returns>
        public static bool checkifDownloadCancelled()
        {
            if (downloadHandler.downloadCancelled)
            {
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logDebug(Strings.downloadCancelled)
                ));

                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}