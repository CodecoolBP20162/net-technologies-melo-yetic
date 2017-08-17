using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace YetiMelo
{
    class FolderWatcher
    {
        FileSystemWatcher watcher;
        public List<string> AllowedExtensions { get; set; }
        MainWindow ParentForm;

        public FolderWatcher() { }

        public void WatchFolder(string Path, List<string> AllowedExtensions, MainWindow MainForm)
        {
            watcher = new FileSystemWatcher();
            this.AllowedExtensions = AllowedExtensions;
            this.ParentForm = MainForm;
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
            string CreatedFileName = e.Name;
            FileInfo createdFile = new FileInfo(CreatedFileName);
            string extension = createdFile.Extension;
            string eventoccured = e.ChangeType.ToString();

            try
            {
                if (AllowedExtensions.Contains(System.IO.Path.GetExtension(e.FullPath).ToLower()))
                {
                    ParentForm.Dispatcher.Invoke((Action)(() =>
                    {
                        {
                            Console.WriteLine(string.Format("File created at: {0}", e.FullPath));
                            MessageBox.Show(string.Format("File created at: {0}", e.FullPath));
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
