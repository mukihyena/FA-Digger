using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections; // for arraylist

namespace FADownloader
{
    public class IOHandler
    {
        //// Create a dictionary that contains all files in the root download directory
        //public static Dictionary<string, FileInfo> existingFilesAll = new Dictionary<string, FileInfo>();
        //public static Dictionary<string, FileInfo> existingFilesInRoot = new Dictionary<string, FileInfo>();
        //public static Dictionary<string, FileInfo> existingFilesInArtistSubfolder = new Dictionary<string, FileInfo>();
        //public static Dictionary<string, FileInfo> existingFilesInGallerySubfolder = new Dictionary<string, FileInfo>();
        ////public static Dictionary<string, FileInfo> existingFilesInScrapsSubfolder = new Dictionary<string, FileInfo>();
        ////public static Dictionary<string, FileInfo> existingFilesInFavoritesSubfolder = new Dictionary<string, FileInfo>();
        ////public static Dictionary<string, FileInfo> existingFilesInJournalsSubfolder = new Dictionary<string, FileInfo>();
        ////public static Dictionary<string, FileInfo> existingFilesInUnknownSubfolder = new Dictionary<string, FileInfo>();
        //// Don't forget to check the individual artist folders also

        //    /// <summary>
        //    /// temp shit for reference
        //    /// </summary>
        //    /// <param name="fileName"></param>
        //public static void MANGOSTUFF(string fileName)
        //{
        //    DirectoryInfo rootDir = new DirectoryInfo(downloadHandler.downloadDir);
        //    foreach (FileInfo file in rootDir.GetFiles())
        //    {
        //        existingFilesInRoot.Add(file.Name, file);
        //    }

        //    // Check to see if the file dictionary aleady contains a file we want to download
        //    if (existingFilesInRoot.ContainsKey(fileName))
        //    {
        //        FileInfo fileToMove = existingFilesInRoot[fileName];
        //        fileToMove.MoveTo("new destination");
        //    }
        //}


        ///// <summary>
        ///// Create a list of existing files in our download directory
        ///// </summary>
        //public static void setExistingFiles()
        //{
        //    // populate the hashset with fileinfos

        //    // refresh file names
        //    existingFilesAll.Clear();

        //    DirectoryInfo di = new DirectoryInfo(downloadHandler.downloadDir);
        //    FileInfo[] fileInfosAll = di.GetFiles("*", SearchOption.AllDirectories);

        //    foreach (FileInfo existingFile in fileInfosAll)
        //    {
        //        if (downloadHandler.checkifDownloadCancelled())
        //        {
        //            return;
        //        }
        //        existingFilesAll.Add(//"/" + 
        //            existingFile.Name, existingFile);
        //    }

        //    Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
        //    Logger.logDebug("All existing files grabbed")
        //    ));
        //}

        //public static void setExistingFilesInFolder (Dictionary<string, FileInfo> existingFilesLocation)
        //{
        //    existingFilesLocation.Clear();

        //    DirectoryInfo di = new DirectoryInfo(downloadHandler.downloadDir);
        //    FileInfo[] fileInfos = di.GetFiles();

        //    foreach (FileInfo existingFile in fileInfos)
        //    {
        //        if (downloadHandler.checkifDownloadCancelled())
        //        {
        //            return;
        //        }
        //        existingFilesInRoot.Add(//"/" + 
        //            existingFile.Name, existingFile);
        //    }
        //    Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
        //    Logger.logDebug("All existing files grabbed")
        //    ));
        //}

        public static void moveExistingFilesToFolder
            (ArtistObject artist, string galleryTypeString, string fileName)
        {
            // File location for files in root directory
            string rootDirectoryLocation
                = (downloadHandler.downloadDir);

            // File location for files in Artist Subfolder
            string artistSubfolderLocation
                = (downloadHandler.downloadDir + @"\" + artist.artistName);

            // File location for files in Gallery Type Subfolder
            string galleryTypeSubfolderLocation
                = (downloadHandler.downloadDir + @"\" + artist.artistName + @"\" + galleryTypeString);

            string currentFilelocation = "";
            string fileMoveDestination = "";

            // default file location
            fileMoveDestination = (rootDirectoryLocation);

            // Check our settings, create folders and set our move destination accordingly
            if (downloaderForm.createArtistSubfolder)
            {
                if (downloaderForm.createGalleryTypeSubfolder)
                {
                    if (!Directory.Exists(galleryTypeSubfolderLocation))
                    {
                        Directory.CreateDirectory(galleryTypeSubfolderLocation);
                    }
                    fileMoveDestination = (galleryTypeSubfolderLocation);
                }
                else
                {
                    if (!Directory.Exists(artistSubfolderLocation))
                    {
                        Directory.CreateDirectory(artistSubfolderLocation);
                    }
                    fileMoveDestination = (artistSubfolderLocation);
                }
            }


            // If the file already exists in our move destination, STOP IT
            if (File.Exists
                (fileMoveDestination + @"\" + fileName))
            {
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logDownload("File exists. Skipping: " + fileName)
                ));

                HTMLHandler.dupeHit++;
                return;
            }

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("File " + fileName)
            ));

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("should be moved from " + currentFilelocation)
            ));

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("should be moved to " + fileMoveDestination)
            ));

            // Find where file lives

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("Find where the file lives.")
            ));

            if (File.Exists
                (rootDirectoryLocation + @"\" + fileName))
            {
                currentFilelocation = rootDirectoryLocation;
            }
            else if (File.Exists
                (artistSubfolderLocation + @"\" + fileName))
            {
                currentFilelocation = artistSubfolderLocation;
            }
            else if (File.Exists
                (galleryTypeSubfolderLocation + @"\" + fileName))
            {
                currentFilelocation = galleryTypeSubfolderLocation;
            }
            else if (File.Exists
                (rootDirectoryLocation + @"\Unsorted\" + fileName))
            {
                currentFilelocation = (rootDirectoryLocation + @"\Unsorted\");
            }
            else if (File.Exists
                (artistSubfolderLocation + @"\Unsorted\" + fileName))
            {
                currentFilelocation = (artistSubfolderLocation + @"\Unsorted\");
            }
            else
            {
                Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
                Logger.logStatus("Duplicate file " + fileName + " not in folder. Probably shares name with another file.")
                ));
                return;
            }

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("File " + fileName)
            ));

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDebug("lives in " + fileMoveDestination)
            ));

            // Move the file to it's destination!!!!!!!!!!
            File.Move
                ((
                currentFilelocation + @"\" + fileName
                ), (
                fileMoveDestination + @"\" + fileName
                ));

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDownload("Subfolder sorting has been changed.")
            ));

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDownload("Moving File " + fileName)
            ));

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logStatus("from " + currentFilelocation)
            ));

            Program.mainForm.lbOutput.BeginInvoke(new Action(() =>
            Logger.logDownload("to " + fileMoveDestination)
            ));
        }

        /// <summary>
        /// Move unsorted files into unsorted directory
        /// </summary>
        /// <param name="artist"></param>
        public static void moveUnsortedFiles(ArtistObject artist)
        {
            string artistDirectory = (downloadHandler.downloadDir + @"\" + artist.artistName);

            // Handle "Subfolder by Gallery Type"
            if (downloaderForm.createArtistSubfolder)
            {
                if (downloaderForm.createGalleryTypeSubfolder)
                {
                    if (!Directory.Exists(artistDirectory + @"\Unsorted\"))
                    {
                        Directory.CreateDirectory(artistDirectory + @"\Unsorted\");
                    }

                    DirectoryInfo diArtistDirectory
                        = new DirectoryInfo(artistDirectory);
                    FileInfo[] artistDirectoryFiles
                        = diArtistDirectory.GetFiles();

                    foreach (FileInfo ArtistDirectoryFile in artistDirectoryFiles)
                    {
                        if
                            (!ArtistDirectoryFile.Directory.Name.Contains(@"\Gallery\")
                            && !ArtistDirectoryFile.Directory.Name.Contains(@"\Scraps\")
                            && !ArtistDirectoryFile.Directory.Name.Contains(@"\Favorites\")
                            && !ArtistDirectoryFile.Directory.Name.Contains(@"\Journals\"))
                        {
                            ArtistDirectoryFile.MoveTo
                                (artistDirectory + @"\Unsorted\" + ArtistDirectoryFile.Name);
                        }
                    }
                }

                // Handle "Subfolder by Artist" if necessary. Seems fine as is
                else
                {

                }
            }
        }

        public static void removeEmptyArtistDirectories(string downloadDir)
        {
            foreach (var subDir in Directory.GetDirectories(downloadDir))
            {
                removeEmptyArtistDirectories(subDir);
                if (Directory.GetFiles(subDir).Length == 0 &&
                    Directory.GetDirectories(subDir).Length == 0)
                {
                    Directory.Delete(subDir, false);
                }
            }
        }

        public static void deleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                deleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }
    }
}
