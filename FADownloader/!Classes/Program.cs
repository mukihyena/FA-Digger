//////////////////
// Main program //
//////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FADownloader
{
    static class Program
    {
        /// <summary>
        /// Public variables
        /// </summary>

        public static downloaderForm mainForm;
        public static Dictionary<String, ArtistObject> myArtistList = new Dictionary<String, ArtistObject>();
        public static Dictionary<String, ArtistObject> activeArtistList    // for selections
        = new Dictionary<String, ArtistObject>();                   // for selections

        //Extention method to remove case sensitivity
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source != null && toCheck != null && source.IndexOf(toCheck, comp) >= 0;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
       {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainForm = new downloaderForm();
            myArtistList = new Dictionary<String, ArtistObject>(); // create empty artist list on launch
            activeArtistList = new Dictionary<String, ArtistObject>(); // create empty artist list on launch

            //myArtistList.Add("pervdragon", new ArtistObject("pervdragon", true, false, false, true));// testing
            //myArtistList.Add("mukihyena", new ArtistObject("mukihyena", false, false, false, true));
            //myArtistList.Add("peacefultyranny", new ArtistObject("peacefultyranny", false, true, false, true));

            Application.Run(mainForm);
        }


    }
}
