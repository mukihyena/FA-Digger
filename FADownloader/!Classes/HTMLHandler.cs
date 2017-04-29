///////////////////
// HTML Handler /// - MukiHyena/PervDragon
///////////////////
/* brainstorm design spec

            // verify login.
            // prompt the user, open default browser to FA login? deal with cookies?
            // could I get this entire thing to run in a hidden browser? no that's stupid it'd load all the shit
            // and bog the internet

            // look at the list of artists to parse, their individual settings // ARTIST HANDLER CLASS?

            // start based on the indivdual settings, it will run this for each artist

            // for each artist:

            // Dig through gallery
            // Wait for x seconds
            // Open submission page
            // Add links to list of files to download
            // Repeat for each submission page
            // If no more links, check for next button
            // if next button exists, go to next page and repeat
            // if not, return

            // Dig through scraps
            // Wait for x seconds
            // Open submission page
            // Add links to list of files to download
            // Repeat for each submission page
            // If no more links, check for next button
            // if next button exists, go to next page and repeat
            // if not, return

            // Dig through favorites
            // Wait for x seconds
            // Open submission page
            // Add links to list of files to download
            // Repeat for each submission page
            // If no more links, check for next button
            // if next button exists, go to next page and repeat
            // if not, return

            // Dig through journals
            // Open each individual journal
            // Save off the HTML of each journal

            // Proceed to next artist
            // If no artist exists, move on

            // Set folders // PUT THIS IN FILE MANAGEMENT CLASS
            // Set up artist folder
            // Set settings folders
            // Gallery
            // Scraps
            // Favorites
            // Journals

            //Download files // PUT THIS IN DOWNLOAD HANDLER CLASS
            // Wait for X seconds
            // Compare file to local file
            // If local file exists and overwrite is not checked, skip
            // If not, download anyways
            // Could I compare the 
            // Download File in list
            // Loop  for each file

*/

// Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;                       // network
using System.Net.NetworkInformation;    // for pinging
using HtmlAgilityPack;                  // agility pack addon
using System.Threading;                 // for multithreading/sleeps
using System.IO;

// Code
namespace FADownloader
{
    public class HTMLHandler
    {
        //////////////////////
        // GLOBAL VARIABLES //
        //////////////////////

        #region
        // System
        public CookieContainer myCookieContainer;
        public static bool updatingAllArtistStatuses = false;
        public static bool artistStatusCancelled = false;
        public static bool updateAllStatuses = true;
        public static bool overWriteStatuses = false;
        public static int dupeHit = 0;
        public static int dupeHitMax = 0;

        public static int htmlDelayLength = 0; // quarter sec
        public static ArrayList invalidCharacters = new ArrayList(); // Handle this in the UI?
        public static ArrayList filteredWords = new ArrayList();
        public static ArrayList outerPageTerms = new ArrayList();
        public static ArrayList outerPageLinks = new ArrayList();

        // Picture Box shit
        public static string currentImage = "";
        public static string currentSoundClip = "";

        // UI shit
        public static int numCurrentArtist = 0;
        public static int numMaxArtist = 0;

        //Filter
        public static bool filterKeywords = false;
        public static bool filterDescription = false;
        public static bool filterSubmissionTitle = false;
        public static bool filterFileName = false;
        public static bool filterComments = false;

        // User settings
        public static bool loggedIn = false;
        public static bool logInFailed = false;
        public static bool loggingIn = false;
        public static bool loggingOut = false;
        public static string faUsername = "";
        public static string faPassword = "";

        // FA Online Status
        public static bool connectedToFA = false;
        public static string FAOnlineStatus = "";
        public static bool faIsInBeta = false; // Sets Xpaths based on FA Beta status

        // Xpaths

        //Defaults/Settings
        public static string XPathDefaultHref
            = "//a[@href]";
        public static string XPathTitle
            = "//title";
        public static string XPathCheckFABeta
            = "//head/script[text()]";

        // FA Digger
        public static string XPathLoggedInVerification
            = "/html[1]/body[1]/table[1]";
            //= "/html[1]/body[1]/div[1]/table[1]//a{@href]";
            //= "/html[1]/body[1]/div[1]/table[1]/tr[1]/td[2]/ul[1]/li[1]/a[2]";
            //= "li[@class='noblock']//a[@href]";
            //= "li[@class='noblock']/a[2]";
            //= "/html[1]/body[1]/table[1]/tr[1]/td[2]/ul[1]/li[1]/a[2]"
        public static string XPathReadOnlyMode
            = "/html[1]/body[1]/div[1]/table[2]/tr[1]/td[1]/table[1]/tr[1]/td[2]";
        public static string XPathReadOnlyModeAlt
            = "/html[1]/body[1]/div[1]/div[2]/a[1]";
        public static string XPathArtistStatus
            = "//td[@class='alt1']";
        public static string XPathArtistDoesntExist
            = "//td[@class='cat']/font/b";
        public static string XPathGallery
            //= "//div[@class='submission-list']/center/b"; // Broadened for rating check //old
            // = "//div[@class='submission-list']/section/figure/b/u" // too broad?
            = "//div[@class='submission-list']/section/figure"; // new as of 16/11/28
        public static string XPathScraps
            = XPathGallery; // identical to Gallery
        public static string XPathFavorites
            = "//div[@id='favorites']/table[2]/tr[1]/td[1]/table[1]/tr[2]/td[1]/center[1]/b"; // Broadened for rating check system
        public static string XPathJournals
            = "/html[1]/body[1]/div[1]/div[4]/table[2]/tr[2]/td[1]/table[1]/tr[1]/td[1]/table/tr[2]/td[1]/table[1]/tr[1]/td[2]/table[1]/tr[5]/td[1]//a[@href]";
        public static string XPathSubmissionPage
            //= "//div[@id='page-submission']//a[@href]"; // BREAKING ON KEYWORDS THAT SAY "DOWNLOAD"
            = "//div[@id='page-submission']//div[@class='alt1 actions aligncenter']//a[@href]"; // NARROWED TO BYPASS
        public static string XPathNoSubmissions
            = "//div[@id='no-images']";
        public static string XPathRating
            = "/html[1]/body[1]/div[1]/div[4]/div[2]/table[1]/tr[1]/td[1]/table[1]/tr[2]/td[1]/table[1]/tr[1]/td[2]/table[1]/tr[1]/td[1]";
        public static string XPathFilterKeywords
            = "//div[@id='keywords']";
        public static string XPathFilterDescription
            //= "/html[1]/body[1]/div[1]/div[4]/div[2]/table[1]/tr[1]/td[1]/table[1]/tr[2]/td[1]/table[1]/tr[2]/td[1]"; // raw
            = "//div[@id='page-submission']//table[@class='maintable']/tr[2]/td[1]/table[1]/tr[2]/td[1]"; // narrowed
        public static string XPathFilterSubmissionTitle   // could use page title? XPathTitle
                                                          //= "/html[1]/body[1]/div[1]/div[4]/div[2]/table[1]/tr[1]/td[1]/table[1]/tr[1]/th[1]/"; // raw
            = "//div[@id='page-submission']//th[@class='cat']"; // narrowed
        public static string XPathFilterFileName
            = XPathSubmissionPage; // should work
        public static string XPathFilterComments
            = "/html[1]/body[1]/div[1]/div[4]/div[2]/table[1]/tr[3]/td[1]";

        // Outer sites

        public static string XPathDescriptionLinks
            = "div[@id='page-submission']//table[@class='maintable']/tr[2]/td[1]/table[1]/tr[2]/td[1]//a[@href]";

        public static string XPathE6Download
            //= "/html[1]/body[1]/div[4]/div[1]/div[2]/div[5]/h4[1]//a[@href]";//raw
            = "//div[@id='post-view']/div[2]/div[5]/h4[1]//a[@href]";
        public static string XPathGyfcatFileLocation
            = "/html[1]/body[1]/div[4]/div[2]/figure[1]/video[1]/source[1]";//raw
                                                                            //= "//source[@id='webmSource']";//for webm
                                                                            //="//source[@id='mp4Source']";//for mp4

        // HEIRARCHY REQUEST ERRORS WITH THEIR JAVASCRIPT CODE - CURRENTLY UNSUPPORTED
        // HEIRARCHY REQUEST ERRORS WITH THEIR JAVASCRIPT CODE - CURRENTLY UNSUPPORTED
        // HEIRARCHY REQUEST ERRORS WITH THEIR JAVASCRIPT CODE - CURRENTLY UNSUPPORTED
        public static string XPathReadOnlyMode_beta = XPathReadOnlyMode;                    // BETA UNSUPPORTED
        public static string XPathReadOnlyModeAlt_beta = XPathReadOnlyModeAlt;              // BETA UNSUPPORTED
        public static string XPathArtistStatus_beta = XPathArtistStatus;                    // BETA UNSUPPORTED
        public static string XPathArtistDoesntExist_beta = XPathArtistDoesntExist;          // BETA UNSUPPORTED
        public static string XPathGallery_beta = XPathGallery;                              // BETA UNSUPPORTED
        public static string XPathScraps_beta = XPathScraps;                                // BETA UNSUPPORTED
        public static string XPathFavorites_beta = XPathFavorites;                          // BETA UNSUPPORTED
        public static string XPathJournals_beta = XPathJournals;                            // BETA UNSUPPORTED
        public static string XPathSubmissionPage_beta = XPathSubmissionPage;                // BETA UNSUPPORTED
        public static string XPathNoSubmissions_beta = XPathNoSubmissions;                  // BETA UNSUPPORTED
        public static string XPathFilterKeywords_beta = XPathFilterKeywords;                // BETA UNSUPPORTED
        public static string XPathFilterDescription_beta = XPathFilterDescription;          // BETA UNSUPPORTED
        public static string XPathFilterSubmissionTitle_beta = XPathFilterSubmissionTitle;  // BETA UNSUPPORTED
        public static string XPathFilterFileName_beta = XPathFilterFileName;                // BETA UNSUPPORTED
        public static string XPathFilterComments_beta = XPathFilterComments;                // BETA UNSUPPORTED
                                                                                            // HEIRARCHY REQUEST ERRORS WITH THEIR JAVASCRIPT CODE - CURRENTLY UNSUPPORTED
                                                                                            // HEIRARCHY REQUEST ERRORS WITH THEIR JAVASCRIPT CODE - CURRENTLY UNSUPPORTED
                                                                                            // HEIRARCHY REQUEST ERRORS WITH THEIR JAVASCRIPT CODE - CURRENTLY UNSUPPORTED
        #endregion

        /////////////////////////////////
        // LOGIN CHECK (COOKIE METHOD) //
        /////////////////////////////////

        #region
        /// <summary>
        /// Check to see if user is logged in
        /// </summary>
        public static void logInCheck()
        {
            bool faIsInBeta = true;

            faIsInBeta = checkIfFABeta();

            ///html[1]/body[1]/div[1]/table[1]/tr[1]/td[2]/ul[1]/li[1]/a[2];
            var client = new cookieHandler.MyWebClient();
            HtmlDocument HTMLDoc
                = client.GetPageWithCookies("http://www.furaffinity.net/", downloaderForm.userCookies);

            if (!faIsInBeta)
            {
                if (HTMLDoc.DocumentNode.SelectSingleNode(XPathTitle)
                    .OuterHtml.Contains("Index"))
                {
                    Logger.logDebug("Loaded index.");
                }

                foreach (HtmlNode node in HTMLDoc.DocumentNode.SelectNodes(XPathLoggedInVerification))
                {
                    if (node.OuterHtml.Contains("/logout/"))
                    {
                        loggedIn = true;
                        break;
                    }
                    else if (node.OuterHtml.Contains("/login/"))
                    {
                        loggedIn = false;
                        break;
                    }
                    else
                    {
                        Logger.logError("Login verification fucked up.");
                    }
                }

                //if (HTMLDoc.DocumentNode.SelectSingleNode(XPathLoggedInVerification)
                //                .OuterHtml.Contains("logout"))
                //{
                //    loggedIn = true;
                //}
                //else if (HTMLDoc.DocumentNode.SelectSingleNode(XPathLoggedInVerification)
                //                .OuterHtml.Contains("login"))
                //{
                //    loggedIn = false;
                //}
                //else
                //{
                //    Logger.logError("Login verification fucked up.");
                //}
            }
            else
            {
                faBetaUnsupported();
                loggedIn = false;
            }
        }
        #endregion

        ////////////////////////////
        // SET BLOCKED CHARACTERS //
        ////////////////////////////

        #region
        public static void setInvalidCharacters()
        {
            //invalidCharacters.Add(' ');
            invalidCharacters.Add(" ");
            invalidCharacters.Add("'");
            invalidCharacters.Add(@"\");
            invalidCharacters.Add("/");
            invalidCharacters.Add(":");
            invalidCharacters.Add("*");
            invalidCharacters.Add("?");
            //invalidCharacters.Add('"');
            invalidCharacters.Add("<");
            invalidCharacters.Add(">");
            invalidCharacters.Add("|");
            invalidCharacters.Add("*");
            invalidCharacters.Add("!");
        }

        #endregion

        //////////////////////////////////
        // SET CURRENT IMAGE/SOUND CLIP //
        //////////////////////////////////

        #region
        /// <summary>
        /// Digs for files to show in the the picture box
        /// </summary>
        public static void setPictureBox()
        {
            bool fileExists = false;

            // Image variaibles
            string image1Link
                = "https://dl.dropboxusercontent.com/u/50590573/Projects/Code/FADigger/current.png";
            string image2Link
                = "https://dl.dropboxusercontent.com/u/50590573/Projects/Code/FADigger/current.gif";
            string image3Link
                = "https://dl.dropboxusercontent.com/u/50590573/Projects/Code/FADigger/current.jpg";
            string image4Link
                = "https://dl.dropboxusercontent.com/u/50590573/Projects/Code/FADigger/current.jpeg";

            // Sound variables
            string soundLink
                = "https://dl.dropboxusercontent.com/u/50590573/Projects/Code/FADigger/current.mp3";

            // Check for current image URL
            if (fileExists = checkIfFileExists
                (image1Link))
            {
                currentImage = image1Link;
            }
            else if (fileExists = checkIfFileExists
                (image2Link))
            {
                currentImage = image2Link;
            }
            else if (fileExists = checkIfFileExists
                (image3Link))
            {
                currentImage = image3Link;
            }
            else if (fileExists = checkIfFileExists
                (image4Link))
            {
                currentImage = image4Link;
            }
            else
            {
                currentImage = "http://d.facdn.net/down"; // fix?!?!
                Logger.logDebug("Missing live image");
            }

            // Check for current sound clip URL
            if (fileExists = checkIfFileExists
                (soundLink))
            {
                currentSoundClip = soundLink;
            }
            else
            {
                Logger.logDebug("Missing live sound");
            }
        }

        /// <summary>
        /// Check if file exists (for picturebox, may expand)
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static bool checkIfFileExists(string url)
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                //Any exception will returns false.
                return false;
            }
        }
        #endregion

        ////////////////////////////////
        // CHECK SERVER ONLINE STATUS //
        ////////////////////////////////

        #region
        /// <summary>
        /// Checks for FA Online status
        /// </summary>
        /// <returns></returns>
        public static void checkFAOnlineStatus()
        {
            // Open the site
            HtmlWeb hw = new HtmlWeb();
            var client = new cookieHandler.MyWebClient();
            HtmlDocument HTMLDoc
                = client.GetPageWithCookies(("http://furaffinity.net/"),
                downloaderForm.userCookies);

            // ADD A NULL CHECK HERE:
            if (HTMLDoc == null)
            {
                // Handle null document here
                connectedToFA = false;
                FAOnlineStatus = "offline/status unknown"; // Probably fine with just this for offline
                return;
            }

            string XPathCheckFAOnlineStatusReadOnlyMode = "";
            string XPathCheckFAOnlineStatusReadOnlyModeAlt = "";

            switch (faIsInBeta)
            {
                case true:
                    XPathCheckFAOnlineStatusReadOnlyMode = XPathReadOnlyMode_beta;
                    XPathCheckFAOnlineStatusReadOnlyModeAlt = XPathReadOnlyModeAlt_beta;
                    break;

                case false:
                    XPathCheckFAOnlineStatusReadOnlyMode = XPathReadOnlyMode;
                    XPathCheckFAOnlineStatusReadOnlyModeAlt = XPathReadOnlyModeAlt;
                    break;

                default:
                    break;
            }

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("Digging front page for status...")
            ));

            // If Title contains Index
            if (HTMLDoc.DocumentNode.SelectSingleNode(XPathTitle)
                .OuterHtml.Contains("Index"))
            {
                connectedToFA = true;
                FAOnlineStatus = "online";

                if (
                    (HTMLDoc.DocumentNode.SelectSingleNode(XPathCheckFAOnlineStatusReadOnlyMode)
                    != null &&
                    HTMLDoc.DocumentNode.SelectSingleNode(XPathCheckFAOnlineStatusReadOnlyMode)
                    .InnerText.Contains("Read Only"))
                    ||
                    (HTMLDoc.DocumentNode.SelectSingleNode(XPathCheckFAOnlineStatusReadOnlyMode)
                    != null &&
                    HTMLDoc.DocumentNode.SelectSingleNode(XPathCheckFAOnlineStatusReadOnlyMode)
                .InnerText.Contains("Read Only")))

                {
                    connectedToFA = true;
                    FAOnlineStatus = "read only";
                }
                else
                {

                }
            }
            // If Title contains "FA is temporarily offline"
            else if (HTMLDoc.DocumentNode.SelectSingleNode(XPathTitle)
                .OuterHtml.Contains("FA is temporarily offline."))
            {
                connectedToFA = false;
                FAOnlineStatus = "down for maintainence";
            }

            else
            {
                connectedToFA = false;
                FAOnlineStatus = "offline/status unknown"; // Probably fine with just this for offline
            }
        }
        #endregion

        //////////////////
        // LIVE UPDATER //
        //////////////////

        #region
        /// <summary>
        /// Read live text URLs to send to UI
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string readOnlineText(string url)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(url);
            StreamReader reader = new StreamReader(stream);
            string content = reader.ReadToEnd();
            if (content == "")
            {
                return null;
            }
            else
            {
                return content;
            }
        }
        #endregion

        ////////////////////
        // STATUS PARSING //
        ////////////////////

        #region
        /// <summary>
        /// Grabs all artist statuses for the UI Artist List
        /// </summary>
        public static void getAllArtistStatuses()
        {
            faIsInBeta = checkIfFABeta();

            if (faIsInBeta)             // BETA UNSUPPORTED
            {                           // BETA UNSUPPORTED
                faBetaUnsupported();    // BETA UNSUPPORTED
                return;                 // BETA UNSUPPORTED
            }                           // BETA UNSUPPORTED

            foreach (ArtistObject artist in Program.activeArtistList.Values)
            {
                if (artistStatusCancelled)
                {
                    return;
                }
                updatingAllArtistStatuses = true;
                getArtistStatus(artist);
            }
            artistStatusCancelled = false;
        }

        /// <summary>
        /// Parses for artist status
        /// </summary>
        /// <param name="artist"></param>
        public static void getArtistStatus(ArtistObject artist)
        {
            if (!updatingAllArtistStatuses)
            {
                if (faIsInBeta)             // BETA UNSUPPORTED
                {                           // BETA UNSUPPORTED
                    faBetaUnsupported();    // BETA UNSUPPORTED
                    return;                 // BETA UNSUPPORTED
                }                           // BETA UNSUPPORTED
            }

            HtmlWeb hw = new HtmlWeb();
            ///HtmlDocument HTMLDoc = hw.Load("http://furaffinity.net/user/" + artist.name);
            var client = new cookieHandler.MyWebClient();
            HtmlDocument HTMLDoc
                = client.GetPageWithCookies
                (("http://furaffinity.net/user/" + artist.artistName + "/"),                                      // TEST CODE
                downloaderForm.userCookies);

            // ADD A NULL CHECK HERE:
            if (checkIfPageNull(artist, HTMLDoc, "user page"))
            {
                return;
            }

            string getArtistStatusXPath = "";
            string getArtistStatusXPathDoesntExist = "";

            switch (faIsInBeta)
            {
                case true:
                    getArtistStatusXPath = XPathArtistStatus_beta;
                    getArtistStatusXPathDoesntExist = XPathArtistDoesntExist_beta;
                    break;

                case false:
                    getArtistStatusXPath = XPathArtistStatus;
                    getArtistStatusXPathDoesntExist = XPathArtistDoesntExist;
                    break;

                default:
                    break;
            }

            // If the title contains "Userpage" and System Message does
            // not contain "registered users only," account is available
            if (
                (HTMLDoc.DocumentNode.SelectSingleNode(XPathTitle)
                .OuterHtml.Contains("Userpage")) &&
                (!HTMLDoc.DocumentNode.SelectSingleNode(getArtistStatusXPath)
                    .OuterHtml.Contains("registered users only"))
                )
            {
                artist.accountStatus = AccountStatus.Available;
            }
            // If the System Message contains "Registered Users Only,"
            // account access requires login
            else if (HTMLDoc.DocumentNode.SelectSingleNode(getArtistStatusXPath)
                    .OuterHtml.Contains("registered users only"))
            {
                artist.accountStatus = AccountStatus.PageRequiresLogin;
            }
            // If the system message contains "disabled" but does not
            // contain "voluntarily," the account is otherwise disabled
            else if
                (
                (HTMLDoc.DocumentNode.SelectSingleNode(getArtistStatusXPath)
                .OuterHtml.Contains("Disabled")) &&
                (!HTMLDoc.DocumentNode.SelectSingleNode(getArtistStatusXPath)
                .OuterHtml.Contains("voluntarily"))
                )
            {
                artist.accountStatus = AccountStatus.AccountDisabled;
            }
            // If the System Message contains "voluntarily," account
            // has been voluntarily disabled by the owner
            else if (HTMLDoc.DocumentNode.SelectSingleNode(getArtistStatusXPath)
                .OuterHtml.Contains("voluntarily"))
            {
                artist.accountStatus = AccountStatus.AccountDisabledVoluntary;
            }
            // If there is a "fatal system error" field, the account
            // does not exist
            else if (HTMLDoc.DocumentNode.SelectSingleNode(getArtistStatusXPathDoesntExist)
                    .OuterHtml.Contains("Fatal system error"))
            {
                artist.accountStatus = AccountStatus.PageDoesNotExist;
            }
            // otherwise, you fucked up.
            else
            {
                artist.accountStatus = AccountStatus.Unknown;
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logError(Strings.Error)
                ));
            }

            string artistStatus = "";
            if (artist.accountStatus == AccountStatus.Available)
            {
                artistStatus = "Online";
            }
            if (artist.accountStatus == AccountStatus.AccountDisabled)
            {
                artistStatus = "Account disabled";
            }
            if (artist.accountStatus == AccountStatus.AccountDisabledVoluntary)
            {
                artistStatus = "Account voluntarily disabled";
            }
            if (artist.accountStatus == AccountStatus.PageDoesNotExist)
            {
                artistStatus = "Artist does not exist";
            }
            if (artist.accountStatus == AccountStatus.PageRequiresLogin)
            {
                artistStatus = "Gallery access requires login";
            }
            if (artist.accountStatus == AccountStatus.Unknown)
            {
                artistStatus = "Unspecified error";
            }
            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDownload
            (artist.artistName + "'s status: " + artistStatus)
            ));

            Thread.Sleep(htmlDelayLength);
        }
        #endregion

        //////////////////////
        // MAIN FILE DIGGER // -- this entire process needs to be on a separate thread
        //////////////////////

        #region
        /// <summary>
        /// Let's get it going (dig through FA)
        /// </summary>
        public static void dig()
        {           

            if (checkIfHTMLParseCancelled())
            {
                return;
            }

            faIsInBeta = checkIfFABeta();

            if (faIsInBeta)                 // BETA UNSUPPORTED
            {                               // BETA UNSUPPORTED
                faBetaUnsupported();        // BETA UNSUPPORTED
                return;                     // BETA UNSUPPORTED
            }                               // BETA UNSUPPORTED

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDownload
            ("ARTIST PAGE DIGGING COMMENCED")
            ));

            outerPageTerms.Clear();
            outerPageTerms.Add(".webm");
            outerPageTerms.Add(".mp4");
            outerPageTerms.Add("https://static1.e621.net/");
            outerPageTerms.Add("https://gfycat.com/");
            outerPageTerms.Add("https://e621.net/post/show/");

            numMaxArtist = 0;
            setInvalidCharacters();

            numMaxArtist = Program.activeArtistList.Keys.Count();

            Program.mainForm.lbParseProgress.BeginInvoke(new Action(() =>
            Program.mainForm.lbParseProgress.Text
            = (numCurrentArtist + " of " + numMaxArtist)
            ));

            Program.mainForm.lbDownloadProgress.BeginInvoke(new Action(() =>
            Program.mainForm.lbDownloadProgress.Text
            = (downloadHandler.numCurrentDownload + " of " + downloadHandler.numMaxDownload)
            ));

            Program.mainForm.lblDiggingArtist.BeginInvoke(new Action(() =>
            Program.mainForm.lblDiggingArtist.ForeColor = System.Drawing.Color.Orange
            ));

            Program.mainForm.lbParseProgress.BeginInvoke(new Action(() =>
            Program.mainForm.lbParseProgress.ForeColor = System.Drawing.Color.Orange
            ));

            foreach (ArtistObject artist in Program.activeArtistList.Values)
            {
                if (checkIfHTMLParseCancelled())
                {
                    return;
                }

                getArtistStatus(artist);

                numCurrentArtist++;

                if (artist.accountStatus == AccountStatus.Unknown)
                {
                    Dictionary<string, ArtistObject> artistToUpdate = new Dictionary<string, ArtistObject>();

                    overWriteStatuses = true;
                    artistToUpdate.Add(artist.artistName, artist);
                    getArtistStatus(artist);
                    //downloaderForm.setStatusIndicators(artistToUpdate); // fuck
                    overWriteStatuses = true;
                    artistToUpdate.Clear();
                }

                Program.mainForm.lbParseProgress.BeginInvoke(new Action(() =>
                Program.mainForm.lbParseProgress.Text
                = (numCurrentArtist + " of " + numMaxArtist)
                ));
                if
                    (artist.accountStatus != AccountStatus.AccountDisabled
                    && artist.accountStatus != AccountStatus.AccountDisabledVoluntary
                    && artist.accountStatus != AccountStatus.PageDoesNotExist
                    && artist.accountStatus != AccountStatus.PageRequiresLogin)
                {
                    if (artist.downloadGallery)
                    {
                        setArtistArguments(artist, SubmissionType.Gallery);
                        dupeHit = 0;
                    }
                    if (artist.downloadScraps)
                    {
                        setArtistArguments(artist, SubmissionType.Scraps);
                        dupeHit = 0;
                    }
                    if (artist.downloadFavorites)
                    {
                        setArtistArguments(artist, SubmissionType.Favorites);
                        dupeHit = 0;
                    }
                    if (artist.downloadJournals)
                    {
                        setArtistArguments(artist, SubmissionType.Journals);
                        dupeHit = 0;
                    }
                }
                else
                {
                    string artistStatus = "";
                    if (artist.accountStatus == AccountStatus.AccountDisabled)
                    {
                        artistStatus = "Account disabled.";
                    }
                    if (artist.accountStatus == AccountStatus.AccountDisabledVoluntary)
                    {
                        artistStatus = "Account voluntarily disabled.";
                    }
                    if (artist.accountStatus == AccountStatus.PageDoesNotExist)
                    {
                        artistStatus = "Artist does not exist.";
                    }
                    if (artist.accountStatus == AccountStatus.PageRequiresLogin)
                    {
                        artistStatus = "Gallery access requires login.";
                    }
                    if (artist.accountStatus == AccountStatus.Unknown)
                    {
                        artistStatus = "Unspecified error.";
                    }
                    Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                    Logger.logDownload
                    ("Cannot download from "
                    + artist.artistName
                    + ":")
                    ));

                    Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                    Logger.logDownload(artistStatus)
                    ));
                }

                IOHandler.moveUnsortedFiles(artist); //low pri honestly
            }

            if (checkIfHTMLParseCancelled())
            {
                return;
            }

            Program.mainForm.lblDiggingArtist.BeginInvoke(new Action(() =>
            Program.mainForm.lblDiggingArtist.ForeColor = System.Drawing.Color.LightGreen
            ));

            Program.mainForm.lbParseProgress.BeginInvoke(new Action(() =>
            Program.mainForm.lbParseProgress.ForeColor = System.Drawing.Color.LightGreen
            ));

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDownload("PARSING IS DONE SON")
            ));
        }

        /// <summary>
        /// Set Artist Arguments to pass to the parser
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="pageType"></param>
        private static void setArtistArguments(ArtistObject artist, SubmissionType pageType)
        {
            if (checkIfHTMLParseCancelled())
            {
                return;
            }

            if (dupeHitMax != 0 && dupeHit == dupeHitMax)
            {
                return;
            }

            bool isGallery = false;                             // Page is a gallery page (gallery/scraps/favs)
            string pageTypeString = "";                         // String of page type
            string XPath = "";                                  // Xpath to parse through
            string lookingFor = "";                             // String in Xpath to parse for
            string baseGalleryPath = "";                        // Gallery path of page we're on
            ArrayList arrayListToUpdate = new ArrayList();      // Array list to update with links grabbed

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logStatus
            ("Setting artist values...")
            ));

            switch (pageType)
            {

                case SubmissionType.Gallery:
                    isGallery = true;
                    pageTypeString = "Gallery";
                    lookingFor = "/view/";
                    baseGalleryPath = "http://furaffinity.net/gallery/";
                    arrayListToUpdate = artist.galleryFileLinks;

                    switch (faIsInBeta)
                    {
                        case true:
                            XPath = XPathGallery_beta;
                            break;

                        case false:
                            XPath = XPathGallery;
                            break;

                        default:
                            break;
                    }

                    break;

                case SubmissionType.Scraps:
                    isGallery = true;
                    pageTypeString = "Scraps";
                    lookingFor = "/view/";
                    baseGalleryPath = "http://furaffinity.net/scraps/";
                    arrayListToUpdate = artist.scrapsFileLinks;

                    switch (faIsInBeta)
                    {
                        case true:
                            XPath = XPathScraps_beta;
                            break;

                        case false:
                            XPath = XPathScraps;
                            break;

                        default:
                            break;
                    }

                    break;

                case SubmissionType.Favorites:
                    isGallery = true;
                    pageTypeString = "Favorites";
                    lookingFor = "/view/";
                    baseGalleryPath = "http://furaffinity.net/favorites/";
                    arrayListToUpdate = artist.favoritesFileLinks;

                    switch (faIsInBeta)
                    {
                        case true:
                            XPath = XPathFavorites_beta;
                            break;

                        case false:
                            XPath = XPathFavorites;
                            break;

                        default:
                            break;
                    }

                    break;

                case SubmissionType.Journals:
                    isGallery = false; // Call a separate functoin
                    pageTypeString = "Journals";
                    //a[@href], // fallback, may work with new FA layout
                    lookingFor = "Read more...";
                    baseGalleryPath = "http://furaffinity.net/journals/";
                    arrayListToUpdate = artist.journalsFileLinks;

                    switch (faIsInBeta)
                    {
                        case true:
                            XPath = XPathJournals_beta;
                            break;

                        case false:
                            XPath = XPathJournals;
                            break;

                        default:
                            break;
                    }

                    break;

                default:

                    Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                    Logger.logError(Strings.Error)
                    ));
                    break;
            }

            if (isGallery)
            {
                digGalleryViewPage
                    (
                    artist,
                    arrayListToUpdate,
                    pageTypeString,
                    XPath,
                    lookingFor,
                    baseGalleryPath
                    );
            }
            else if (!isGallery)
            {
                digJournals
                    (
                    artist,
                    arrayListToUpdate,
                    pageTypeString,
                    XPath,
                    lookingFor,
                    baseGalleryPath
                    );

            }

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDownload
            ("HTML Dig for " + artist.artistName + "'s " + pageTypeString + " page completed.")
            ));

            Thread.Sleep(2000);
        }

        /// <summary>
        /// !!! IMPLEMENT!!! Check if user profile is in Fur Affinity Beta
        /// </summary>
        /// <returns></returns>
        public static bool checkIfFABeta()
        {
            if (checkIfHTMLParseCancelled())
            {
                return false;
            }

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug
            ("Parse FurAffinity site and check if user is in FA Beta (not yet implemented)")
            ));

            //if (!loggedIn)
            //{
            //    Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            //    Logger.logDebug
            //    ("Not logged in, FurAffinity is in classic mode.")
            //    ));

            //    return false;
            //}

            var client = new cookieHandler.MyWebClient();
            HtmlDocument HTMLDoc
                = client.GetPageWithCookies
                ("http://www.furaffinity.net/", downloaderForm.userCookies);

            bool b = false;

            if (HTMLDoc.DocumentNode.SelectSingleNode(XPathCheckFABeta) != null)
            {
                // If node contains a desired link, add it to the list of links
                if (HTMLDoc.DocumentNode.SelectSingleNode(XPathCheckFABeta)
                    .InnerText.Contains("/themes/beta"))
                {
                    Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                    Logger.logDebug
                    ("FurAffinity is in beta mode.")
                    ));

                    b = true;
                }
                else if (HTMLDoc.DocumentNode.SelectSingleNode(XPathCheckFABeta)
                    .InnerText.Contains("/themes/classic"))
                {
                    Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                    Logger.logDebug
                    ("FurAffinty is in classic mode.")
                    ));
                    b = false;
                }
            }

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug
            ("Beta mode: " + b)
            ));

            return b;
        }

        /// <summary>
        /// Dig through gallery/scraps/favorites type pages
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="arrayListToUpdate"></param>
        /// <param name="pageTypeString"></param>
        /// <param name="XPath"></param>
        /// <param name="lookingFor"></param>
        /// <param name="baseGalleryPath"></param>
        private static void digGalleryViewPage
            (
            ArtistObject artist,            // arg 1 - Which artist are we looking at?
            ArrayList arrayListToUpdate,    // arg 2 - What array list should we update?
            string pageTypeString,          // arg 3 - What type of page are we parsing? (string)
            string XPath,                   // arg 4 - What XPath should we use?
            string lookingFor,              // arg 5 - What are we searching for in the XPath?
            string baseGalleryPath          // arg 6 - What is the base gallery path?
            )
        {
            if (checkIfHTMLParseCancelled())
            {
                return;
            }
            if (dupeHitMax != 0 && dupeHit == dupeHitMax)
            {
                return;
            }

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                        Logger.logDownload
                        (
                            "Digging through "
                            + artist.artistName +
                            "'s "
                            + pageTypeString +
                            "..."
                            )
                            ));

            string galleryURL = (baseGalleryPath + artist.artistName);
            string currentPageURL = "";
            bool pageHasSubmissions = true;
            int pageNum = 1;

            string digSubmissionPagesXpath = "";
            string checkIfPageHasSubmissionsXpath = "";

            ArrayList submissionPageLinks = new ArrayList();
            HtmlWeb hw = new HtmlWeb();

            // Set Xpath based on beta mode
            switch (faIsInBeta)
            {
                case true:
                    digSubmissionPagesXpath = XPathSubmissionPage_beta;
                    checkIfPageHasSubmissionsXpath = XPathNoSubmissions_beta;
                    break;

                case false:
                    digSubmissionPagesXpath = XPathSubmissionPage;
                    checkIfPageHasSubmissionsXpath = XPathNoSubmissions;
                    break;

                default:
                    break;
            }


            {
                // check if page has submissions
                while (pageHasSubmissions)
                {
                    if (checkIfHTMLParseCancelled())
                    {
                        return;
                    }
                    if (dupeHitMax != 0 && dupeHit == dupeHitMax)
                    {
                        return;
                    }

                    // if page number is 1, use default url
                    if (pageNum == 1)
                    {
                        currentPageURL = (galleryURL);
                    }
                    // if page number is greater than 1, add page number to end of url
                    else if (pageNum > 1)
                    {
                        currentPageURL = (
                            galleryURL +
                            "/"
                            + pageNum +
                            "/"
                            );
                    }

                    // don't trip FA's bullshit
                    Thread.Sleep(htmlDelayLength);

                    var client = new cookieHandler.MyWebClient();
                    HtmlDocument HTMLDoc
                        = client.GetPageWithCookies(currentPageURL, downloaderForm.userCookies);

                    // ADD A NULL CHECK HERE:
                    if (checkIfPageNull(artist, HTMLDoc, pageTypeString))
                    {
                        return;
                    }

                    // check to see if current page is empty
                    pageHasSubmissions = checkIfPageHasSubmissions
                        (
                        artist,
                        HTMLDoc,
                        pageTypeString,
                        checkIfPageHasSubmissionsXpath,
                        currentPageURL
                        );

                    // move on to parse the submission pages we've gathered if gallery page is empty
                    if (!pageHasSubmissions)
                    {
                        break;
                    }

                    // parse gallery page
                    pageNum++; // add 1 to page #
                    parseForLinks // Parse the page accordingly
                        (
                        artist,
                        HTMLDoc,
                        submissionPageLinks,
                        null,
                        pageTypeString,
                        XPath,
                        lookingFor
                        );
                }
                // dig submission page and locate files
                digSubmissionPages
                    (
                    artist,
                    submissionPageLinks,
                    arrayListToUpdate,
                    pageTypeString,
                    "Submission",
                    digSubmissionPagesXpath,
                    "Download"
                    );
            }
        }

        /// <summary>
        /// Dig through submission page
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="submissionPageLinks"></param>
        /// <param name="arrayListToUpdate"></param>
        /// <param name="pageTypeString"></param>
        /// <param name="XPath"></param>
        /// <param name="lookingFor"></param>
        private static void digSubmissionPages
            (
            ArtistObject artist,            // arg 1 - Which artist are we looking at?
            ArrayList submissionPageLinks,  // arg 2 - What array list contains the pages to parse through??
            ArrayList arrayListToUpdate,    // arg 3 - What array list should we update?  (UNIQUE FOR THIS VOID)
            string galleryTypeString,       // arg 4 - What gallery type are we parsing? (string)
            string pageTypeString,          // arg 5 - What type of page are we parsing? (string)
            string XPath,                   // arg 6 - What XPath should we use?
            string lookingFor               // arg 7 - What are we searching for in the XPath?
            )
        {
            if (checkIfHTMLParseCancelled())
            {
                return;
            }
            if (dupeHitMax != 0 && dupeHit == dupeHitMax)
            {
                return;
            }
            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logDownload
                (
                    "Digging through "
                    + artist.artistName +
                    "'s "
                    + galleryTypeString + pageTypeString +
                    "..."
                    )
                    ));

            string baseSubmissionPath = "http://furaffinity.net/view/";
            HtmlWeb hw = new HtmlWeb();

            foreach (string submissionURLToParse in submissionPageLinks)
            {
                if (checkIfHTMLParseCancelled())
                {
                    return;
                }
                if (dupeHitMax != 0 && dupeHit == dupeHitMax)
                {
                    return;
                }

                Thread.Sleep(htmlDelayLength);

                var client = new cookieHandler.MyWebClient();
                HtmlDocument HTMLDoc
                    = client.GetPageWithCookies
                    (submissionURLToParse, downloaderForm.userCookies);

                // ADD A NULL CHECK HERE:
                if (checkIfPageNull(artist, HTMLDoc, pageTypeString))
                {
                    return;
                }

                // If our filter isn't tripped,
                if (!submissionFilterHit(HTMLDoc, submissionURLToParse))
                {
                    if (submissionURLToParse.Contains(baseSubmissionPath))
                    {
                        parseForLinks
                            (
                            artist,
                            HTMLDoc,
                            arrayListToUpdate,
                            galleryTypeString,
                            pageTypeString,
                            XPath,
                            lookingFor
                            );
                    }
                }
            }
        }

        /// <summary>
        /// Check if filtered word exists on submission page
        /// </summary>
        /// <param name="HTMLDoc"></param>
        /// <returns></returns>
        private static bool submissionFilterHit(HtmlDocument HTMLDoc, string submissionURLToParse)
        {
            bool filterHit = false;

            if (filterKeywords)
            {
                if (filterHit)
                {
                    return filterHit;
                }
                filterHit = (submissionFilterParse(HTMLDoc, XPathFilterKeywords, submissionURLToParse));
            }
            if (filterDescription)
            {
                if (filterHit)
                {
                    return filterHit;
                }
                filterHit = (submissionFilterParse(HTMLDoc, XPathFilterDescription, submissionURLToParse));
            }
            if (filterSubmissionTitle)
            {
                if (filterHit)
                {
                    return filterHit;
                }
                filterHit = (submissionFilterParse(HTMLDoc, XPathFilterSubmissionTitle, submissionURLToParse));
            }
            if (filterFileName)
            {
                if (filterHit)
                {
                    return filterHit;
                }
                filterHit = (submissionFilterParse(HTMLDoc, XPathFilterFileName, submissionURLToParse));
            }
            if (filterComments)
            {
                if (filterHit)
                {
                    return filterHit;
                }
                filterHit = (submissionFilterParse(HTMLDoc, XPathFilterComments, submissionURLToParse));
            }

            return filterHit;                        
        }

        /// <summary>
        /// Parse submission page to check for filtered word
        /// </summary>
        /// <param name="HTMLDoc"></param>
        /// <param name="XPath"></param>
        /// <returns></returns>
        public static bool submissionFilterParse(HtmlDocument HTMLDoc, string XPath, string submissionURLToParse)
        {
            bool filterHit = false;

            if (HTMLDoc.DocumentNode.SelectNodes(XPath) == null)
            {
                return filterHit;
            }

            foreach (HtmlNode node in HTMLDoc.DocumentNode.SelectNodes(XPath))
            {
                if (filterHit)
                {
                    return filterHit;
                }
                foreach (string filteredWord in filteredWords)
                {
                    if (filterHit)
                    {
                        return filterHit;
                    }
                    // using extention method to remove case sensitivity
                    if (node.OuterHtml.Contains(filteredWord, StringComparison.OrdinalIgnoreCase))
                    {
                        Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                        Logger.logStatus
                        (
                            "Filtered word " + filteredWord +
                            " hit in" + submissionURLToParse
                        )
                        ));
                        filterHit = true;
                        return filterHit;
                    }
                }
            }
            return filterHit;
        }

        /// <summary>
        /// WHO HONESTLY CARES M8
        /// </summary>
        /// <param name="HTMLDoc"></param>
        /// <param name="submissionURLToParse"></param>
        /// <returns></returns>
        private static bool outerPageExists(HtmlDocument HTMLDoc, string submissionURLToParse)
        {
            bool outerPageExists = false;
            {
                if (HTMLDoc.DocumentNode.SelectNodes(XPathDescriptionLinks) == null)
                {
                    return outerPageExists;
                }

                foreach (HtmlNode node in HTMLDoc.DocumentNode.SelectNodes(XPathDescriptionLinks))
                {
                    if (outerPageExists)
                    {
                        return outerPageExists;
                    }
                    foreach (string outerPageTerm in outerPageTerms)
                    {
                        if (outerPageExists)
                        {
                            return outerPageExists;
                        }
                        {
                            if (node.OuterHtml.Contains(outerPageTerm))
                            {
                                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                                Logger.logStatus
                                ("Outer page exists")
                                ));
                                outerPageExists = true;
                                return outerPageExists;
                            }
                        }
                    }
                }
            }
            return outerPageExists;
        }

        /// <summary>
        /// Check if the current gallery page has submissions
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="HTMLDoc"></param>
        /// <param name="pageTypeString"></param>
        /// <param name="XPath"></param>
        /// <param name="currentPageURL"></param>
        /// <returns></returns>
        private static bool checkIfPageHasSubmissions
            (
            ArtistObject artist,            // arg 1 - Which artist are we looking at?
            HtmlDocument HTMLDoc,           // arg 2 - What link are we searching through?
            string pageTypeString,          // arg 3 - What type of page are we parsing? (string)
            string XPath,                   // arg 4 - What XPath should we use?
            string currentPageURL           // arg 5 - What is the URL of the current page?
            )
        {
            if (checkIfHTMLParseCancelled())
            {
                return false;
            }
            if (dupeHitMax != 0 && dupeHit == dupeHitMax)
            {
                return false;
            }

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logStatus
            ("Checking if next page has submissions...")
            ));

            bool pageHasSubmissions = true;

            if (HTMLDoc.DocumentNode.SelectSingleNode(XPath) == null)
            {
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logDownload
                ("Submissions available on " + artist.artistName + "'s "
                + pageTypeString + " page " + currentPageURL)
                ));

                pageHasSubmissions = true;
            }
            else
            {
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logDownload
                ("No submissions available on " + artist.artistName + "'s "
                + pageTypeString + " page " + currentPageURL)
                ));

                pageHasSubmissions = false;
            }
            return (pageHasSubmissions);
        }

        /// <summary>
        /// Dig journals page
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="arrayListToUpdate"></param>
        /// <param name="pageTypeString"></param>
        /// <param name="XPath"></param>
        /// <param name="lookingFor"></param>
        /// <param name="baseGalleryPath"></param>
        private static void digJournals
            (
            ArtistObject artist,            // arg 1 - Which artist are we looking at?
            ArrayList arrayListToUpdate,    // arg 2 - What array list should we update?
            string pageTypeString,          // arg 3 - What type of page are we parsing? (string)
            string XPath,                   // arg 4 - What XPath should we use?
            string lookingFor,              // arg 5 - What are we searching for in the XPath?
            string baseGalleryPath          // arg 6 - What is the base gallery path?
            )
        {
            if (checkIfHTMLParseCancelled())
            {
                return;
            }
            if (dupeHitMax != 0 && dupeHit == dupeHitMax)
            {
                return;
            }

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDownload
            ("Digging through " + artist.artistName + "'s " + pageTypeString + "...")
            ));

            string journalsURL = (baseGalleryPath + artist.artistName);

            Thread.Sleep(htmlDelayLength);

            HtmlWeb hw = new HtmlWeb();
            var client = new cookieHandler.MyWebClient();
            HtmlDocument HTMLDoc = client.GetPageWithCookies(journalsURL, downloaderForm.userCookies);

            // ADD A NULL CHECK HERE:
            if (checkIfPageNull(artist, HTMLDoc, pageTypeString))
            {
                return;
            }

            if (journalsURL.Contains(baseGalleryPath))
            {
                parseForLinks
                    (
                    artist,
                    HTMLDoc,
                    arrayListToUpdate,
                    null,
                    pageTypeString,
                    XPath,
                    lookingFor
                    );
            }
        }

        /// <summary>
        /// Main parsing system
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="HTMLDoc"></param>
        /// <param name="arrayListToUpdate"></param>
        /// <param name="pageTypeString"></param>
        /// <param name="XPath"></param>
        /// <param name="lookingFor"></param>
        private static void parseForLinks
            (
            ArtistObject artist,            // arg 1 - Which artist are we looking at?
            HtmlDocument HTMLDoc,           // arg 2 - What link are we searching through?
            ArrayList arrayListToUpdate,    // arg 3 - Which array list should we update?
            string galleryTypeString,       // arg 4 - What type of gallery are we parsing?
            string pageTypeString,          // arg 4 - What type of page are we parsing? (string)
            string XPath,                   // arg 5 - Which XPath should we use?
            string lookingFor               // arg 6 - What are we searching for in the XPath?
            )
        {
            if (checkIfHTMLParseCancelled())
            {
                return;
            }
            if (dupeHitMax != 0 && dupeHit == dupeHitMax)
            {
                return;
            }

            string FAroot = "http://furaffinity.net";
            string foundLink = "";
            string linkGrabbed = "";

            if (galleryTypeString != null)
            {
                linkGrabbed =
                    (
                    "Found in "
                    + artist.artistName + "'s "
                    + galleryTypeString
                    + " "
                    + pageTypeString
                    + ": "
                    + foundLink
                    );
            }
            else
            {
                linkGrabbed =
                    (
                    "Found in "
                    + artist.artistName + "'s "
                    + pageTypeString + ": "
                    + foundLink
                    );
            }

            bool updateArray = true;

            if (galleryTypeString == null)
            {
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logDebug
                (
                    "Looking at "
                + artist + "'s "
                + pageTypeString
                )
                ));
            }
            else
            {
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logDebug
                (
                    "Looking at "
                + artist + "'s " +
                galleryTypeString + pageTypeString
                )
                ));
            }


            // Look at the nodes on the page
            if (HTMLDoc.DocumentNode.SelectSingleNode(XPath) == null)
            {
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logStatus
                (
                    "Xpath is null in "
                    + artist.artistName + "'s "
                    + pageTypeString +
                    ". If this is a user's favorite, you " +
                    "may need to log in to download."
                    )
                    ));
                return;
            }

            foreach (HtmlNode node in HTMLDoc.DocumentNode.SelectNodes(XPath))
            {
                if (checkIfHTMLParseCancelled())
                {
                    return;
                }
                if (dupeHitMax != 0 && dupeHit == dupeHitMax)
                {
                    return;
                }

                string hrefValue = node.GetAttributeValue("href", string.Empty);

                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logDebug
                ("XPath: " + XPath)
                ));

                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logDebug
                ("Parsing: " + node.OuterHtml)
                ));

                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logDebug
                ("Looking for: " + lookingFor)
                ));

                // If node contains a desired link, add it to the list of links
                if (node.OuterHtml.Contains(lookingFor))
                {

                    // Set foundLink based on type of page we are parsing
                    switch (pageTypeString)
                    {
                        case "Gallery":
                        case "Scraps":
                        case "Favorites":

                            // method 1: broken, skips everything
                            //string submissionLinkHrefValue = null;
                            //foreach (HtmlNode hrefnode in HTMLDoc.DocumentNode.SelectNodes(".//a[@href]"))
                            //{
                            //    if (node.OuterHtml.Contains(lookingFor))
                            //    {
                            //        submissionLinkHrefValue = node.GetAttributeValue("href", string.Empty);
                            //    }
                            //}

                            // method 2: occasionally crashes with null exception
                            HtmlNode hrefNode = node.SelectSingleNode(".//a[@href]");
                            string submissionLinkHrefValue
                                = hrefNode.GetAttributeValue("href", string.Empty);

                            //method 3: immediate crash
                            //string submissionLinkHrefValue = null;
                            //HtmlNode hrefNode = node.SelectSingleNode(".//a[@href]");
                            //if (node.OuterHtml.Contains(lookingFor))
                            //{
                            //    submissionLinkHrefValue
                            //    = hrefNode.GetAttributeValue("href", string.Empty);
                            //}

                            if (checkRating(artist, HTMLDoc, node, (FAroot + submissionLinkHrefValue)))
                            {
                                foundLink = (FAroot + submissionLinkHrefValue);

                                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                                Logger.logStatus(linkGrabbed + foundLink)
                                ));

                                updateArray = true;
                            }
                            else
                            {
                                updateArray = false;
                            }
                            break;

                        case "Journals":
                            foundLink = (FAroot + hrefValue);

                            //Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                            //Logger.logStatus(linkGrabbed + foundLink)
                            //));

                            downloadHandler.numMaxDownload++;

                            if (checkIfAlreadyDownloaded
                                (artist, "Journals", foundLink)
                                && !downloadHandler.overwriteFiles)
                            {
                                updateArray = false;

                                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                                Logger.logDownload(foundLink + " already exists, skipping.")
                                ));
                            }
                            else
                            {
                                updateArray = true;
                                dupeHit = 0;

                                downloadHandler.numMaxDownload++;

                                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                                Logger.logDownload(linkGrabbed + foundLink)
                                ));
                            }

                            break;

                        case "Submission":

                            foundLink = ("http:" + hrefValue);

                            if (checkIfAlreadyDownloaded
                                (artist, galleryTypeString, foundLink)
                                && !downloadHandler.overwriteFiles)
                            {
                                updateArray = false;

                                //Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                                //Logger.logDownload(foundLink + " already exists, skipping.")
                                //));
                            }
                            else
                            {
                                updateArray = true;
                                dupeHit = 0;

                                downloadHandler.numMaxDownload++;

                                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                                Logger.logDownload(linkGrabbed + foundLink)
                                ));
                            }

                            break;
                    }
                    // Add the found link to the array
                    if (updateArray)
                    {
                        arrayListToUpdate.Add(foundLink);
                    }
                    if (dupeHitMax != 0
                        && dupeHit == dupeHitMax)
                    {
                        Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                        Logger.logDownload
                        ("Duplicate file " + dupeHit + " of max " + dupeHitMax + "hit.")
                        ));

                        Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                        Logger.logDownload
                        ("Skipping the rest of this gallery.")
                        ));

                        return;
                    }

                }
            }

            if (numCurrentArtist == numMaxArtist)
            {
                Program.mainForm.lblDiggingArtist.BeginInvoke(new Action(() =>
                Program.mainForm.lblDiggingArtist.ForeColor = System.Drawing.Color.LightGreen
                ));

                Program.mainForm.lbParseProgress.BeginInvoke(new Action(() =>
                Program.mainForm.lbParseProgress.ForeColor = System.Drawing.Color.LightGreen
                ));
            }

            //Program.mainForm.lbParseProgress.BeginInvoke(new Action(() =>
            //Program.mainForm.lbParseProgress.Text
            //= ("Digging artist: "
            //+ numCurrentArtist
            //+ " of " + numMaxArtist)
            //));

            Program.mainForm.lbDownloadProgress.BeginInvoke(new Action(() =>
            Program.mainForm.lbDownloadProgress.Text
            = (downloadHandler.numCurrentDownload + " of " + downloadHandler.numMaxDownload)
            ));

            if (downloadHandler.downloadAfterEachParse)
            {
                if (galleryTypeString == "Gallery" && artist.galleryFileLinks.Count > 0)
                {
                    downloadHandler.downloadFilesFromURLs(artist, SubmissionType.Gallery);
                    artist.galleryFileLinks.Clear();
                }
                if (galleryTypeString == "Scraps" && artist.scrapsFileLinks.Count > 0)
                {
                    downloadHandler.downloadFilesFromURLs(artist, SubmissionType.Scraps);
                    artist.scrapsFileLinks.Clear();
                }
                if (galleryTypeString == "Favorites" && artist.favoritesFileLinks.Count > 0)
                {
                    downloadHandler.downloadFilesFromURLs(artist, SubmissionType.Favorites);
                    artist.favoritesFileLinks.Clear();
                }
                if (pageTypeString == "Journals" && artist.galleryFileLinks.Count > 0)
                {
                    downloadHandler.downloadFilesFromURLs(artist, SubmissionType.Journals);
                    artist.journalsFileLinks.Clear();
                }
            }
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
        private static bool checkIfHTMLParseCancelled()
        {
            if (downloadHandler.downloadCancelled)
            {
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logDebug(Strings.htmlParsingCancelled)
                ));

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check if page is available
        /// </summary>
        /// <param name="HTMLDoc"></param>
        /// <returns></returns>
        private static bool checkIfPageNull
            (
            ArtistObject artist,
            HtmlDocument HTMLDoc,
            string pageTypeString
            )
        {
            if (HTMLDoc == null
                || HTMLDoc.DocumentNode.SelectSingleNode(XPathTitle)
                .OuterHtml.Contains("FA is temporarily offline.")
                )
            {
                // Handle null document here
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logError
                ("Error accessing "
                + artist.artistName + "'s "
                + pageTypeString +
                "page, FA may have gone down.")
                ));
                checkFAOnlineStatus();
                // End the function if necessary
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Check to see if a file is already on the drive
        /// </summary>
        /// <param name="foundLink"></param>
        /// <returns></returns>
        private static bool checkIfAlreadyDownloaded(
            ArtistObject artist,
            string galleryTypeString,
            string foundLink            
            )
        {
            //foreach (string existingFilename in downloadHandler.existingFileNames)
            //{
            //    if (foundLink.Contains(existingFilename))
            //    {
            //        fileExists = true;
            //        break;
            //    }
            //
            //    else
            //    {
            //        fileExists = false;
            //    }
            //}

            bool fileExists = false;

            // Get the filename portion of the URL
            string fileName = "";
            Uri foundLinkUri = new Uri(foundLink);
            fileName = Path.GetFileName(foundLinkUri.LocalPath);

            if (downloadHandler.existingFileNames.Contains(//@"/" + 
                fileName))
            {
                fileExists = true;
                IOHandler.moveExistingFilesToFolder(artist, galleryTypeString, fileName);
            }
            else if (galleryTypeString == "Journals")
            {
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logDownload("Journals dupe checking currently unsupported.")
                ));
                fileExists = false;
            }
            return fileExists;
        }

        /// <summary>
        /// Check the rating of the submission link from the gallery page, determine if we should download
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="HTMLDoc"></param>
        /// <param name="foundLink"></param>
        /// <returns></returns>
        private static bool checkRating
            (
            ArtistObject artist,
            HtmlDocument HTMLDoc,
            HtmlNode node,
            string foundLink
            )
        {
            string rating = "";
            bool downloadRating = false;

            string submissionLinkRatingValue = node.GetAttributeValue("class", string.Empty);

            if (submissionLinkRatingValue.Contains("adult"))
            {
                rating = "adult";
            }
            else if (submissionLinkRatingValue.Contains("mature"))
            {
                rating = "mature";
            }
            else if (submissionLinkRatingValue.Contains("general"))
            {
                rating = "general";
            }

            if (rating == "adult" && downloadHandler.downloadAdult)
            {
                downloadRating = true;
            }
            else if (rating == "mature" && downloadHandler.downloadMature)
            {
                downloadRating = true;
            }
            else if (rating == "general" && downloadHandler.downloadGeneral)
            {
                downloadRating = true;
            }

            if (downloadRating)
            {
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logStatus
                (
                    artist.artistName + "'s "
                    + rating + " rating file at " +
                    foundLink + " will be added to submission file list."
                    )
                    ));
            }
            else
            {
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logStatus
                (
                    artist.artistName + "'s "
                    + rating + " rating file at "
                    + foundLink +
                    " skipped."
                    )
                    ));
            }
            return downloadRating;
        }
        #endregion

        //////////////////////
        // BETA UNSUPPORTED //
        //////////////////////

        #region
        /// <summary>
        /// Beta Unsupported dialog box
        /// </summary>
        private static void faBetaUnsupported()
        {
            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logError
            (Strings.betaModeUnsupported)
            ));

            System.Windows.Forms.DialogResult FABetaModeNotSupported
                = System.Windows.Forms.MessageBox.Show
                (
                    "Beta mode is currently unsupported."
                    + Environment.NewLine + Environment.NewLine +
                    "Please change to Classic mode in your"
                    + Environment.NewLine +
                    "FurAffinity account settings to use the downloader."
                    + Environment.NewLine + Environment.NewLine +
                    "Open account settings page?",
                    "FurAffinity Beta mode currently unsupported",
                    System.Windows.Forms.MessageBoxButtons.YesNo
                    );

            if (FABetaModeNotSupported == System.Windows.Forms.DialogResult.Yes)
            {
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logStatus
                ("Opening your account settings.")
                ));

                System.Diagnostics.Process.Start(@"http://www.furaffinity.net/controls/settings/");
            }
            else if (FABetaModeNotSupported == System.Windows.Forms.DialogResult.No)
            {
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logStatus
                ("Account settings not opened.")
                ));
            }
        }
        #endregion
    }
}