///////////////////
// Artist Object // - Pervdragon
///////////////////
/*
    Artist objects set in UI that control functionality on a per-artist basis
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json; // for json saving // thcold

namespace FADownloader
{
    // the different account states
    public enum AccountStatus
    {
        Unknown,
        Available,
        PageDoesNotExist,
        PageRequiresLogin,
        AccountDisabled,
        AccountDisabledVoluntary
    }

    public enum SubmissionType
    {
        Gallery,
        Scraps,
        Favorites,
        Journals
    }

    [Serializable] //thcold
    /// <summary>
    /// ArtistObject class
    /// </summary>
    public class ArtistObject
    {
        public string artistName;
        public bool downloadGallery;            // bool: gallery will be downloaded
        public bool downloadScraps;             // bool: scraps will be downloaded
        public bool downloadFavorites;          // bool: favorites will be downloaded
        public bool downloadJournals;           // bool: journals will be downloaded
        public bool nameValidated;              // unused
        public AccountStatus accountStatus;     // checks account status, populates the left field in UI
        public ArrayList galleryFileLinks;      // array list for individual artist's gallery submissions
        public ArrayList scrapsFileLinks;       // array list for individual artist's scraps submissions
        public ArrayList favoritesFileLinks;    // array list for individual artist's favorites submissions
        public ArrayList journalsFileLinks;     // array list for individual artist's journals submissions
        public HashSet<string> exsitingFiles;   // Hashset for files already downloaded 

        [JsonConstructor] // thcold
        public ArtistObject()
        {
        }

        // defaults if only the name is set
        public ArtistObject(string name) : this(name, AccountStatus.Unknown, false, false, false, false)
        {
            // SET DEFAULTS
            //this.nameValidated = true; // fake validated for initial construction
            //this.status = AccountStatus.Unknown;
        }

        // Initialize these
        public ArtistObject(string name, AccountStatus status, bool gallery, bool scraps, bool favorites, bool journals)
        {
            this.artistName = name;
            this.downloadGallery = gallery;
            this.downloadScraps = scraps;
            this.downloadFavorites = favorites;
            this.downloadJournals = journals;
            this.nameValidated = false;
            this.accountStatus = AccountStatus.Unknown;
            this.galleryFileLinks = new ArrayList();
            this.scrapsFileLinks = new ArrayList();
            this.favoritesFileLinks = new ArrayList();
            this.journalsFileLinks = new ArrayList();
            this.exsitingFiles = new HashSet<string>();
        }
        
        public void updateSettings(bool gallery, bool scraps, bool favorites, bool journals)
        {
            this.downloadGallery = gallery;
            this.downloadScraps = scraps;
            this.downloadFavorites = favorites;
            this.downloadJournals = journals;
        }

        public void updateName(string name)
        {
            this.artistName = name;
            this.nameValidated = false;
        }

        public bool validateName()
        {
            bool nameIsGood = true;

            foreach (string invalidCharacter in HTMLHandler.invalidCharacters)
            // check if any string contains an invalid character
            {
                if (this.artistName.Contains(invalidCharacter))
                // Break if name fails
                {
                    nameIsGood = false;
                    break;
                }
            }

            return nameIsGood;
        }

        public void downloadAllTheThings()
        {
            if (this.downloadGallery)
            {
                // downloadHandler.downloadGallery(name)
            }

            if (this.downloadFavorites) { }
            if (this.downloadScraps) { }
            if (this.downloadJournals) { }
            
        }
    }
}
