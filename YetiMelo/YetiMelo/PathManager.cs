using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YetiMelo
{
    public class PathManager
    {
        static public string FolderSettingPath = GetPathForSettings("Folders.txt");
        static public string VideoSettingPath = GetPathForSettings("Video.txt");
        static public string MusicSettingPath = GetPathForSettings("Music.txt");
        static public string PictureSettingPath = GetPathForSettings("Pictures.txt");
        static public string watchedFoldersSettingPath = GetPathForSettings("WatchedFolders.txt");


        public static string GetPathForSettings(string filename)
        {

            string systemPath = System.Environment.
                                 GetFolderPath(
                                     Environment.SpecialFolder.CommonApplicationData
                                 );
            string complete = Path.Combine(systemPath, filename);

            return complete;
        }

        public static void SaveToFile(List<string> FilePaths)
        {
            TextWriter tw = new StreamWriter(FolderSettingPath);

            foreach (String s in FilePaths)
                tw.WriteLine(s);

            tw.Close();
        }

        public static List<string> ReadFromFile()
        {
            List<string> Folders = new List<string>();
            var logFile = ReadLogLines(FolderSettingPath);
            foreach (var s in logFile)
            {
                Folders.Add(s);
            }
            return Folders;

        }

        static private IEnumerable<string> ReadLogLines(string logPath)
        {
            using (StreamReader reader = File.OpenText(logPath))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
