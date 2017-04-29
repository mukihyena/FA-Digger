///////////////////
//COOKIES HANDLER//
///////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Net; // needed for net controls
using HtmlAgilityPack; //for for web client w/ cookies
using System.Runtime.InteropServices; // needed for import dll
using System.Threading;

namespace FADownloader
{
    class cookieHandler
    {
        // Grabs the cookies
        // source: http://stackoverflow.com/questions/3382498/is-it-possible-to-transfer-authentication-from-webbrowser-to-webrequest
        [DllImport("wininet.dll", SetLastError = true)] // can't use this? // needed System.Runtime.InteropServices;
        public static extern bool InternetGetCookieEx(
            string url,
            string cookieName,
            StringBuilder cookieData,
            ref int size,
            Int32 dwFlags,
            IntPtr lpReserved
                );

        private const Int32 InternetCookieHttponly = 0x2000;

        /// <summary>
        /// Gets the URI cookie container.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns></returns>
        public static CookieContainer GetUriCookieContainer(Uri uri)
        {
            // Determine the size of the cookie
            int datasize = 8192 * 16;
            CookieContainer cookies = null;

            StringBuilder cookieData = new StringBuilder(datasize);
            if (
                !InternetGetCookieEx
                (uri.ToString(),
                null,
                cookieData,
                ref datasize,
                InternetCookieHttponly,
                IntPtr.Zero)
                )
            {
                if (datasize < 0)
                    return null;
                // Allocate stringbuilder large enough to hold the cookie
                cookieData = new StringBuilder(datasize);
                if (
                    !InternetGetCookieEx
                    (uri.ToString(),
                    null, cookieData,
                    ref datasize,
                    InternetCookieHttponly,
                    IntPtr.Zero))
                    return null;
            }
            if (cookieData.Length > 0)
            {
                cookies = new CookieContainer();
                cookies.SetCookies(uri, cookieData.ToString().Replace(';', ','));
            }
            return cookies;
        }

        // Custom HtmlDocument webclient for HTMLAgilityPack
        public class MyWebClient // source: http://stackoverflow.com/questions/15206644/how-to-pass-cookies-to-htmlagilitypack-or-webclient
        {
            //The cookies will be here.
            //private CookieContainer cookies = new CookieContainer();
            private CookieContainer cookies = new CookieContainer();

            //In case you need to clear the cookies
            public void ClearCookies()
            {
                cookies = new CookieContainer();
            }

            public HtmlDocument GetPage(string url)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                //Set more parameters here...
                //...

                //This is the important part.
                //request.CookieContainer = cookies;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var stream = response.GetResponseStream();

                //When you get the response from the website, the cookies will be stored
                //automatically in "_cookies".

                using (var reader = new StreamReader(stream))
                {
                    string html = reader.ReadToEnd();
                    var doc = new HtmlDocument();
                    doc.LoadHtml(html);
                    return doc;
                }
            }

            public HtmlDocument GetPageWithCookies(string url, CookieContainer cookiesToSend)
            {
                // Try this with retries
                return GetPageWithCookiesAndRetry(url, cookiesToSend, 3);
            }

            public HtmlDocument GetPageWithCookiesAndRetry(string url, CookieContainer cookiesToSend, int retries)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                //Set more parameters here...
                //...

                //This is the important part.
                request.CookieContainer = cookiesToSend;

                // Try the web request
                HttpWebResponse response = null;
                try
                {
                    response = request.GetResponse() as HttpWebResponse;
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        Logger.logError("HTTP ERROR " + response.StatusCode.ToString() +
                            "\n:Failed to get URL " + url);

                        // Retry if we can
                        if (retries > 0)
                        {
                            Thread.Sleep(1000);
                            return GetPageWithCookiesAndRetry(url, cookiesToSend, --retries);
                        }
                        else
                        {
                            Logger.logError("Failed to get URL, RAN OUT OF RETRIES: " + url);
                            return null;
                        }
                    }

                    // If we get to here, that means that we've gotten an HTTP 200 (success) back
                    //  We should have data that we can process and return

                    //When you get the response from the website, the cookies will be stored
                    //automatically in "_cookies".
                    var stream = response.GetResponseStream();

                    using (var reader = new StreamReader(stream))
                    {
                        string html = reader.ReadToEnd();
                        var doc = new HtmlDocument();
                        doc.LoadHtml(html);
                        return doc;
                    }
                }
                catch
                {
                    // Something blew the fuck up with the web response
                    // Retry if we can
                    if (retries > 0)
                    {
                       Thread.Sleep(1000);
                        return GetPageWithCookiesAndRetry(url, cookiesToSend, --retries);
                    }
                    else
                    {
                        Logger.logError("Failed to get URL, RAN OUT OF RETRIES: " + url);
                        return null;
                    }
                }
                finally
                {
                    // Close the response
                    if (response != null)
                    {
                        response.Close();
                    }
                }
            }
        }
    }
}
    