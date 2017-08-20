using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;


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
            List<string> folders = new List<string> { "E:\\Test" };//need query form DB
            List<string> AllowedExtensions = new List<string> { ".mp3", ".jpg", ".mp4", };//need query form DB
            FilesFromFolders = scanner.GetFiles(folders, AllowedExtensions);
            FillFilesToListView();
            AddFolderWatch(folders, AllowedExtensions);
        }

        private void AddFolderWatch(List<string> folders, List<string> AllowedExtensions)
        {
            watcher.WatchFolder("E:\\Test", AllowedExtensions, this);
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
            ChangeMetadataInfo();
        }

        private void ChangeMetadataInfo()
        {
            ChangeCommonMediaInfo();
            List<string> pictext = new List<string> { ".jpg", ".bmp", ".png" };
            List<string> vidext = new List<string> { ".avi", ".mkv", ".mp4" };
            List<string> music = new List<string> { ".mp3", ".wav", ".mid" };
            if (pictext.Contains(System.IO.Path.GetExtension(FilesFromFolders[selectedIndexListView]).ToLower())) ChangeMetadataForImg();
            else if (vidext.Contains(System.IO.Path.GetExtension(FilesFromFolders[selectedIndexListView]).ToLower())) ChangeMetadataForVideo();
            else if (music.Contains(System.IO.Path.GetExtension(FilesFromFolders[selectedIndexListView]).ToLower())) ChangeMetadataForMusic();
        }

        private void ChangeMetadataForImg()
        {
            PlayerBorder.Visibility = Visibility.Visible;
            ImageBorder.Visibility = Visibility.Collapsed;

            using (var imageStream = File.OpenRead(FilesFromFolders[selectedIndexListView]))
            {
                var decoder = BitmapDecoder.Create(imageStream, BitmapCreateOptions.IgnoreColorProfile,
                    BitmapCacheOption.Default);
                var height = decoder.Frames[0].PixelHeight;
                var width = decoder.Frames[0].PixelWidth;
                lbTitle.Content = Path.GetFileName(FilesFromFolders[selectedIndexListView]);
                lbFileInfoType2.Content = "Resolution: ";
                lbFileInfo2.Content = width.ToString() + "x" + height.ToString() + " px";
            }
        }

        private void ChangeCommonMediaInfo()
        {

            CustomFileInfo cs = new CustomFileInfo(FilesFromFolders[selectedIndexListView]);
            lbFileInfo4.Content = cs.creation.ToString();
            lbFileInfo6.Content = cs.modification.ToString();
            lbFileInfo1.Content = cs.FileSize.ToString();
            lbFileInfo3.Content = cs.extension;
        }

        private void ChangeMetadataForVideo()
        {
            PlayerBorder.Visibility = Visibility.Visible;
            ImageBorder.Visibility = Visibility.Collapsed;

            ///handle fileInfo Changing
        }

        private void ChangeMetadataForMusic()
        {
            PlayerBorder.Visibility = Visibility.Collapsed;
            ImageBorder.Visibility = Visibility.Visible;
            MedCont.ChangePictureForCoverArt();

            TagLib.File f = TagLib.File.Create(FilesFromFolders[selectedIndexListView], TagLib.ReadStyle.Average);
            var duration = (int)f.Properties.Duration.TotalSeconds;
            TimeSpan time = TimeSpan.FromSeconds(duration);
            lbFileInfo2.Content = time.ToString();
            lbFileInfoType2.Content = "Duration: ";
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
            FileListView.SelectedIndex++;
        }

        private void PlayPrevious(Object sender, EventArgs e)
        {
            MedCont.PlayPrevious();
            FileListView.SelectedIndex--;
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

        //NEW

        private void cbImg_Checked(object sender, RoutedEventArgs e)
        {
            List<string> ImgList = Sorter.ImgSorter(FileList);
            if (cbVid.IsChecked ?? true)
            {
                ImgList = ImgList.Concat(Sorter.VideoSorter(FileList)).ToList();
            }
            if (cbSong.IsChecked ?? true)
            {
                ImgList = ImgList.Concat(Sorter.SongSorter(FileList)).ToList();
            }
            DisplayFiles(ImgList);
            
        }

        private void cbVid_Checked(object sender, RoutedEventArgs e)
        {
            List<string> VidList = Sorter.VideoSorter(FileList);
            if (cbImg.IsChecked ?? true)
            {
                VidList = VidList.Concat(Sorter.ImgSorter(FileList)).ToList();
            }
            if (cbSong.IsChecked ?? true)
            {
                VidList = VidList.Concat(Sorter.SongSorter(FileList)).ToList();
            }
            DisplayFiles(VidList);

        }

        private void cbSong_Checked(object sender, RoutedEventArgs e)
        {
            List<string> SongList = Sorter.SongSorter(FileList);
            if (cbVid.IsChecked ?? true)
            {
                SongList = SongList.Concat(Sorter.VideoSorter(FileList)).ToList();
            }
            if (cbImg.IsChecked ?? true)
            {
                SongList = SongList.Concat(Sorter.ImgSorter(FileList)).ToList();
            }
            DisplayFiles(SongList);
        }

        private void DisplayFiles(List<string> FilesToDisplay)
        {
            List<CustomFileInfo> FileInfoList = new List<CustomFileInfo>();
            foreach (string item in FilesToDisplay)
            {
                CustomFileInfo file = new CustomFileInfo(new FileInfo(item));
                FileInfoList.Add(file);
            }
            FileListView.ItemsSource = FileInfoList;
        }

        private void ListViewEmpty()
        {
            FileListView.ItemsSource = null;
            FileListView.Items.Clear();
        }

        private void cbSong_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbImg.IsChecked ?? true)
            {
                cbImg_Checked(sender, e);
            }
            else
            {
                if (cbVid.IsChecked ?? true)
                {
                    cbVid_Checked(sender, e);
                }
                else
                {
                    DisplayFiles(FileList);
                }
            }
        }

        private void cbVid_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbImg.IsChecked ?? true)
            {
                cbImg_Checked(sender, e);
            }
            else
            {
                if (cbSong.IsChecked ?? true)
                {
                    cbSong_Checked(sender, e);
                }
                else
                {
                    DisplayFiles(FileList);
                }
            }
        }

        private void cbImg_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbSong.IsChecked ?? true)
            {
                cbSong_Checked(sender, e);
            }
            else
            {
                if (cbVid.IsChecked ?? true)
                {
                    cbVid_Checked(sender, e);
                }
                else
                {
                    DisplayFiles(FileList);
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<string> FoundFiles = Sorter.Search(FileList,tbSearch.Text);
            DisplayFiles(FoundFiles);
        }

        private void tbSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            tbSearch.Text = "";

        private void FileListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!MedCont.IsItPicture())
            {
                StopPlaying();
            }

            MediaPlayer player = new MediaPlayer(selectedIndexListView, FilesFromFolders);
            player.Show();

        }
    }
}
