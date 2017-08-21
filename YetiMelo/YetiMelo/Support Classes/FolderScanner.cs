using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace YetiMelo
{
    class FolderScanner
    {
        internal List<string> FoundFileList { get; set; }


        public FolderScanner()
        {
            FoundFileList = new List<string>();
        }

        internal List<string> GetFiles(string Destination, List<string> AllowedExtensions)
        {
            try
            {
                var files = Directory.GetFiles(Destination, "*.*", SearchOption.AllDirectories)
                                .Where(s => AllowedExtensions.Contains(Path.GetExtension(s).ToLower()));
                FoundFileList.AddRange(new List<string>(files));
                return FoundFileList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return FoundFileList;
            }
        }

        internal List<string> GetFiles(List<string> FolderList, List<string> AllowedExtensions)
        {
            FoundFileList = new List<string>();
            if (FolderList != null)
            { 
                foreach (string Destination in FolderList)
                {
                    GetFiles(Destination, AllowedExtensions);
                }
            }
            else
            {
                MessageBox.Show("Please add folders!");
            }

            return FoundFileList;
        }
    }
}
