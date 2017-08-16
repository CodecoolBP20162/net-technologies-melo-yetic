using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YetiMelo
{
    class FolderScanner
    {
        public List<string> FoundFileList { get; set; }


        public FolderScanner()
        {
            FoundFileList = new List<string>();
        }

        public List<string> GetFiles(string Destination, List<string> AllowedExtensions)
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
                return null;
            }
        }

        public List<string> GetFiles(List<string> FolderList, List<string> AllowedExtensions)
        {

            foreach (string Destination in FolderList)
            {
                GetFiles(Destination, AllowedExtensions);
            }

            return FoundFileList;
        }
    }
}
