using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace YetiMelo
{
    public class PathManager
    {
        static internal string FolderSettingPath = GetPathForSettings("Folders.txt");
        static internal string VideoSettingPath = GetPathForSettings("Video.txt");
        static internal string MusicSettingPath = GetPathForSettings("Music.txt");
        static internal string PictureSettingPath = GetPathForSettings("Pictures.txt");
        static internal string watchedFoldersSettingPath = GetPathForSettings("WatchedFolders.txt");

        internal static string GetPathForSettings(string filename)
        {

            string systemPath = System.Environment.
                                 GetFolderPath(
                                     Environment.SpecialFolder.CommonApplicationData
                                 );
            string complete = Path.Combine(systemPath, filename);

            return complete;
        }

        internal static void SaveToFile(List<string> FilePaths)
        {
            TextWriter tw = new StreamWriter(FolderSettingPath);
            if (FilePaths != null)
            {
                foreach (String s in FilePaths)
                    tw.WriteLine(s);
            }
            tw.Close();
        }

        internal static List<string> ReadFromFile()
        {
            try
            {
                List<string> Folders = new List<string>();
                var logFile = ReadLogLines(FolderSettingPath);
                foreach (var s in logFile)
                {
                    Folders.Add(s);
                }
                return Folders;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

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
