using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace YetiMelo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int selectedIndexListView = 0;
        List<string> FilesFromFolders;
        FolderWatcher watcher;
        MediaPlayerController MedCont;
        FolderScanner scanner;

        public MainWindow()
        {
            InitializeComponent();
            myMedia.Volume = 100;
            scanner = new FolderScanner();
            watcher = new FolderWatcher();

            Loaded += MyWindow_Loaded;
        }

        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GetFilesFromFolders();
            MedCont = new MediaPlayerController(this, myMedia, FilesFromFolders, 0);
        }

        private void GetFilesFromFolders()
        {
            List<string> folders = new List<string> { "D:\\Test" };//need query form DB
            List<string> AllowedExtensions = new List<string> { ".mp3", ".jpg", ".mp4", };//need query form DB
            FilesFromFolders = scanner.GetFiles(folders, AllowedExtensions);
            FillFilesToListView();
        }

        private void addFolderWatch(List<string> folders, List<string> AllowedExtensions)
        {
            //wip, need to add support for multiple folders to be watched
            watcher.WatchFolder("D:\\Test", AllowedExtensions, this);
        }

        private void FillFilesToListView()
        {
            List<CustomFileInfo> FileInfoList = new List<CustomFileInfo>();
            foreach (string item in FilesFromFolders)
            {
                CustomFileInfo file = new CustomFileInfo(new FileInfo(item));
                FileInfoList.Add(file);
            }
            FileListView.ItemsSource = FileInfoList;
        }

        private void FileListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedIndexListView = FileListView.SelectedIndex;
            MedCont.PlayPosition = FileListView.SelectedIndex;
            MedCont.PlayCurrent();
        }

        void MediaPlay(Object sender, EventArgs e)
        {
            myMedia.Play();
        }

        private void TogglePlay(Object sender, EventArgs e)
        {
            if (!MedCont.IsPlaying)
            {
                ContinuePlaying();
            }
            else
            {
                StopPlaying();
            }
        }

        private void StopPlaying()
        {
            myMedia.Pause();
            MedCont.IsPlaying = false;
            PauseButton.Visibility = Visibility.Collapsed;
            PlayButton.Visibility = Visibility.Visible;
        }

        private void ContinuePlaying()
        {
            myMedia.Play();
            MedCont.IsPlaying = true;
            PlayButton.Visibility = Visibility.Collapsed;
            PauseButton.Visibility = Visibility.Visible;
        }

        private void PlayNext(Object sender, EventArgs e)
        {
            MedCont.PlayNext();
        }

        private void PlayPrevious(Object sender, EventArgs e)
        {
            MedCont.PlayPrevious();
        }

        private void MediaPause(Object sender, EventArgs e)
        {
            myMedia.Pause();
        }

        private void MediaMute(Object sender, EventArgs e)
        {
            if (myMedia.Volume == 100)
            {
                myMedia.Volume = 0;
                SoundOn.Visibility = Visibility.Collapsed;
                SoundOff.Visibility = Visibility.Visible;
            }
            else
            {
                myMedia.Volume = 100;
                SoundOff.Visibility = Visibility.Collapsed;
                SoundOn.Visibility = Visibility.Visible;
            }
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btResize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized) { this.WindowState = WindowState.Maximized; }
            else { this.WindowState = WindowState.Normal; }

        }

        private void btPutOnTray_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btSettings_Click(object sender, RoutedEventArgs e)
        {
            Window1 wind = new Window1();
            wind.Show();
        }

        private void btAddFolder_Click(object sender, RoutedEventArgs e)
        {
            Add_folder af = new Add_folder();
            af.Show();
        }

        private void btRemoveFolder_Click(object sender, RoutedEventArgs e)
        {
            RemoveFolder rf = new RemoveFolder();
            rf.Show();
        }

        private void btCutMp3_Click(object sender, RoutedEventArgs e)
        {
            CutMp3 cm = new CutMp3();
            cm.Show();
        }

        private void btForgeMp3_Click(object sender, RoutedEventArgs e)
        {
            MergeMp3 mm = new MergeMp3();
            mm.Show();
        }

        private void FileListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!MedCont.IsItPicture(FilesFromFolders[selectedIndexListView]))
            {
                StopPlaying();
            }

            MediaPlayer player = new MediaPlayer(selectedIndexListView, FilesFromFolders);
            player.Show();
        }
    }
}
