using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace YetiMelo
{
    class FolderWatcher
    {
        internal List<string> AllowedExtensions { get; set; }
        private FileSystemWatcher watcher;
        private MainWindow MainForm;
        private List<string> Folders;

        public FolderWatcher() { }

        public void WatchFolder(string Path, List<string> AllowedExtensions, MainWindow MainForm)
        {
            try
            {
                watcher = new FileSystemWatcher();
                this.AllowedExtensions = AllowedExtensions;
                this.MainForm = MainForm;
                watcher.Path = Path;
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                             | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                watcher.Filter = "*.*";
                watcher.IncludeSubdirectories = true;
                watcher.Created += new FileSystemEventHandler(OnCreated);
                watcher.EnableRaisingEvents = true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        public void WatchFolder(List<string> Folders, List<string> AllowedExtensions, MainWindow MainForm)
        {
            this.Folders = Folders;
            if(Folders != null)
            { 
                foreach (string Path in Folders)
                {
                    WatchFolder(Path, AllowedExtensions, MainForm);
                }
            }
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            string CreatedFileName = e.Name;
            FileInfo createdFile = new FileInfo(CreatedFileName);
            string extension = createdFile.Extension;
            string eventoccured = e.ChangeType.ToString();

            try
            {
                if (AllowedExtensions.Contains(System.IO.Path.GetExtension(e.FullPath).ToLower()))
                {

                    MainForm.Dispatcher.Invoke((Action)(() =>
                    {
                        {
                            MessageBox.Show(string.Format("File created at: {0}", e.FullPath));
                            MainForm.GetFilesFromFolders();
                        }
                    }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
