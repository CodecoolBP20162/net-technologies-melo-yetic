using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace YetiMelo
{
    class FolderWatcher
    {
        FileSystemWatcher watcher;
        public List<string> AllowedExtensions { get; set; }
        ListBox NotificationTarget;
        MainWindow ParentForm;

        public FolderWatcher() { }

        public FolderWatcher(ListBox target)
        {
            this.NotificationTarget = target;
        }
        //might need some info about from the wpf to make notifications from this class
        public void WatchFolder(string Path, List<string> AllowedExtensions, ListBox NotificationTarget, MainWindow MainForm)
        {
            watcher = new FileSystemWatcher();
            this.NotificationTarget = NotificationTarget;
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
                            //this.NotificationTarget.AppendText(string.Format("File created at: {0}", e.FullPath));
                            NotificationTarget.Items.Add(string.Format("File created at: {0}", e.FullPath));
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
