/////////////////////////
// WATCH LIST IMPORTER // - Muki
/////////////////////////

/*
Trimmed down version of the HTML Handler
specifically built to handle watch list importing
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;
using System.Web;
using HtmlAgilityPack;
using System.Threading;

namespace FADownloader
{
    class watchListImporter
    {
        public static ArrayList watchedArtists = new ArrayList();
        public static bool notImportingWatchList = true;

        /// <summary>
        /// Imports the watch list - ONE BIGASS FUNCTION
        /// </summary>
        public static void importWatchList()
        {
            if (HTMLHandler.loggedIn)
            {
                notImportingWatchList = false;
                string watchlistURL = (
                    "http://www.furaffinity.net/watchlist/by/"
                    + HTMLHandler.faUsername
                    );
                string lookingFor = "/user/";
                string XPath =
                    "/html[1]/body[1]/div[1]/table[1]/tr[2]/td[1]/table[1]//a[@href]"; // lazy
                string currentPageURL = "";

                bool pageHasWatches = true;
                int pageNum = 1;

                watchedArtists = new ArrayList();
                HtmlWeb hw = new HtmlWeb();

                {
                    // check if page has submissions
                    while (pageHasWatches)
                    {
                        // if page number is 1, use default url
                        if (pageNum == 1)
                        {
                            currentPageURL = (watchlistURL);
                        }
                        // if page number is greater than 1, add page number to end of url
                        else if (pageNum > 1)
                        {
                            currentPageURL = (
                                watchlistURL +
                                "/"
                                + pageNum +
                                "/"
                                );
                        }

                        var client = new cookieHandler.MyWebClient();
                        HtmlDocument HTMLDoc =
                            client.GetPageWithCookies(currentPageURL, downloaderForm.userCookies);

                        // ADD A NULL CHECK HERE:
                        if (HTMLDoc == null)
                        {
                            // Handle null document here

                            // End the function if necessary
                            return;
                        }

                        // check to see if current page is empty
                        Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                        Logger.logStatus("Checking Checking for watches on page " + pageNum + ".")
                        ));

                        switch (HTMLDoc.DocumentNode.SelectSingleNode(XPath) != null)
                        {
                            case false:
                                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                                Logger.logStatus("No watches on page " + pageNum + ".")
                                ));

                                pageHasWatches = false;
                                notImportingWatchList = true;
                                break;

                            case true:
                                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                                Logger.logStatus("watch found, proceeding with parse")
                                ));

                                pageHasWatches = true;
                                break;

                            default:
                                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                                Logger.logError(Strings.Error)
                                ));

                                break;
                        }

                        // Parse for watches
                        if (pageHasWatches)
                        {
                            foreach (HtmlNode node in HTMLDoc.DocumentNode.SelectNodes(XPath))
                            {
                                string hrefValue = node.GetAttributeValue("href", string.Empty);

                                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                                Logger.logDebug("Searching through " + hrefValue)
                                ));

                                // If contains a desired link, add it to the list of links
                                if (node.OuterHtml.Contains(lookingFor))
                                {
                                    Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                                    Logger.logDebug("Trimming :" + hrefValue)
                                    ));

                                    string trimEnd = hrefValue.Remove(hrefValue.Length - 1);
                                    string croppedName = trimEnd.Remove(0, 6);

                                    Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                                    Logger.logStatus("Found user " + croppedName)
                                    ));

                                    watchedArtists.Add(croppedName);
                                }
                            }
                        }
                        // add 1 to page #
                        pageNum++;
                        // don't trip FA's bullshit
                        Thread.Sleep(HTMLHandler.htmlDelayLength);
                    }
                }
            }
        }
    }
}