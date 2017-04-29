using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FADownloader
{
    class Strings
    {
        //General
        public static string Error = "You fucked up. Or I fucked up. Note me on FA and let me know what happened.";
        public static string loginSuccess = "Welcome, " + HTMLHandler.faUsername + "!!! You have successfully logged into FurAffinity.";
        public static string logOutSuccess = "Goodbye, " + HTMLHandler.faUsername + ". See you again soon.";
        public static string invalidCredentials = "Invalid credentials. Please verify your username and password and the captcha.";
        public static string invalidCookies= "Cookies are invalid. Please verify they have been inputed correctly.";
        public static string invalidDirectory = "Invalid directory selected. Please specify an existing directory.";
        public static string FAOnlineStatus = "FurAffinity is " + HTMLHandler.FAOnlineStatus;
        public static string minimumDelayReached = "Don't be a jackass.";
        public static string attemptconnection = "Attempting to connect to FurAffinity...";
        public static string htmlParsingCancelled = "Please wait. Cancelling HTML parsing process...";
        public static string downloadCancelled = "Please wait. Cancelling download process...";
        public static string betaModeUnsupported = "Beta mode is currently unsupported. Please change to Classic mode in your FurAffinity account settings to use the downloader.";
        public static string artistProgress = "Digging artist:" + HTMLHandler.numCurrentArtist + " of " + HTMLHandler.numMaxArtist;
        public static string downloadProgress = "Downloading file:" + downloadHandler.numCurrentDownload + " of " + downloadHandler.numMaxDownload;

        // Tutorial
        public static string ct_Start = "-=HOW TO FIND YOUR LOGIN COOKIES=-/r/n/r/nPlease Select your preferred browser.";
        public static string ct_1 =     "Access FurAffinity front page while logged in.";
        public static string ct_2_CR =  "Press F12 to open the developer window.";
        public static string ct_2_FF =  "Press Ctrl+Shift+K to open the developer window.";
        public static string ct_3 =     "Click the 'Network' tab.";
        public static string ct_4 =     "Press F5 to refresh the page.";
        public static string ct_5 =     "Click the first entry that appears in the list to the show headers.";
        public static string ct_6 =     "Find and copy the values under 'Cookies.'";
        public static string ct_7 =     "Paste cookies into Notepad (or whatever else).";
        public static string ct_8 =     "Copy and Paste the A and B values into the appropriate fields.";
    }
}
