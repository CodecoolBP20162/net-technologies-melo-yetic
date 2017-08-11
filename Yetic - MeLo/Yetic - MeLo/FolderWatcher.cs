using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSelector
{
    class FolderWatcher
    {
        FileSystemWatcher watcher;
        public List<string> AllowedExtensions { get; set; }

        public FolderWatcher() { }

        public void WatchFolder(string Path, List<string> AllowedExtensions)
        {
            watcher = new FileSystemWatcher();
            this.AllowedExtensions = AllowedExtensions;
            watcher.Path = Path;
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                         | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.*";
            watcher.IncludeSubdirectories = true;
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.EnableRaisingEvents = true;
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            if (AllowedExtensions.Contains(Path.GetExtension(e.FullPath).ToLower()))
            {
                Console.WriteLine("File created:");
                Console.WriteLine(e.FullPath);
            }

        }
    }
}
