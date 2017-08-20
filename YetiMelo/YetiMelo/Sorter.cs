using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YetiMelo
{
    public class Sorter
    {

        public static List<string> ImgSorter(List<string> FilePaths)
        {
            List<string> ImgFilePath = new List<string>();
            foreach(string Path in FilePaths)
            {
                if (Path.Substring(Path.Length - 4) == ".jpg" || Path.Substring(Path.Length - 4) == ".png" || Path.Substring(Path.Length - 4) == ".bmp")
                {
                    ImgFilePath.Add(Path);
                }
            }
            return ImgFilePath;
        }

        public static List<string> SongSorter(List<string> FilePaths)
        {
            List<string> SongFilePath = new List<string>();
            foreach (string Path in FilePaths)
            {
                if (Path.Substring(Path.Length - 4) == ".mp3" || Path.Substring(Path.Length - 4) == ".wav" || Path.Substring(Path.Length - 4) == ".mid")
                {
                    SongFilePath.Add(Path);
                }
            }
            return SongFilePath;
        }

        public static List<string> VideoSorter(List<string> FilePaths)
        {
            List<string> VidFilePath = new List<string>();
            foreach (string Path in FilePaths)
            {
                if (Path.Substring(Path.Length - 4) == ".avi" || Path.Substring(Path.Length - 4) == ".mp4" || Path.Substring(Path.Length - 4) == ".mkv")
                {
                    VidFilePath.Add(Path);
                }
            }
            return VidFilePath;
        }

        public static List<string> Search(List<string> FilePaths, string Pattern)
        {
            List<string> Found = new List<string>();
            foreach(string Path in FilePaths)
            {
                if (Path.Contains(Pattern))
                {
                    Found.Add(Path);
                }
            }
            return Found;
        }

    }
}
