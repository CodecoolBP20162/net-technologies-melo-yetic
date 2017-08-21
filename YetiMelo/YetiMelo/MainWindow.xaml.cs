using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
        int SelectedIndexListView = 0;
        List<string> FilesFromFolders;
        List<string> FilesFromFolders2;
        FolderWatcher Watcher;

        MediaPlayerController MedCont;
        FolderScanner Scanner;


        public MainWindow()
        {
            InitializeComponent();
            myMedia.Volume = 100;
            Scanner = new FolderScanner();
            Watcher = new FolderWatcher();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            Loaded += MyWindow_Loaded;
        }

        private void MyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GetFilesFromFolders();
            MedCont = new MediaPlayerController(this, myMedia, FilesFromFolders, 0);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        internal void GetFilesFromFolders()
        {
            SelectedIndexListView = 0;
            List<string> folders = PathManager.ReadFromFile();
            List<string> AllowedExtensions = new List<string> { ".mp3", ".jpg", ".mp4", ".avi", ".png" };//need query form DB
            FilesFromFolders = null;
            FilesFromFolders = Scanner.GetFiles(folders, AllowedExtensions);
            FilesFromFolders2 = FilesFromFolders;
            FillFilesToListView();
            AddFolderWatch(AllowedExtensions);
            MedCont = new MediaPlayerController(this, myMedia, FilesFromFolders, 0);
            PathManager.SaveToFile(folders);
        }

        private void AddFolderWatch(List<string> AllowedExtensions)
        {
            Watcher.WatchFolder(PathManager.ReadFromFile(), AllowedExtensions, this);
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
            SelectedIndexListView = FileListView.SelectedIndex;
            MedCont.PlayPosition = FileListView.SelectedIndex;
            MedCont.PlayCurrent();
            ChangeMetadataInfo();
        }

        private void ChangeMetadataInfo()
        {
            HideMp3EditButtons();
            ChangeCommonMediaInfo();
            List<string> pictext = new List<string> { ".jpg", ".bmp", ".png" };
            List<string> vidext = new List<string> { ".avi", ".mkv", ".mp4" };
            List<string> music = new List<string> { ".mp3", ".wav", ".mid" };
            try
            {
                if (pictext.Contains(System.IO.Path.GetExtension(FilesFromFolders2[SelectedIndexListView]).ToLower())) ChangeMetadataForImg();
                else if (vidext.Contains(System.IO.Path.GetExtension(FilesFromFolders2[SelectedIndexListView]).ToLower())) ChangeMetadataForVideo();
                else if (music.Contains(System.IO.Path.GetExtension(FilesFromFolders2[SelectedIndexListView]).ToLower())) ChangeMetadataForMusic();
            }
            catch { }
        }

        private void ChangeMetadataForImg()
        {
            Bitmap bm = new Bitmap(Properties.Resources.pics);
            imgMedia.Source = ConvertBitmap(bm);

            PlayerBorder.Visibility = Visibility.Visible;
            ImageBorder.Visibility = Visibility.Collapsed;

            using (var imageStream = File.OpenRead(FilesFromFolders[SelectedIndexListView]))
            {
                var decoder = BitmapDecoder.Create(imageStream, BitmapCreateOptions.IgnoreColorProfile,
                    BitmapCacheOption.Default);
                var height = decoder.Frames[0].PixelHeight;
                var width = decoder.Frames[0].PixelWidth;
                lbFileInfoType2.Content = "Resolution: ";
                lbFileInfo2.Content = width.ToString() + "x" + height.ToString() + " px";
                lbFileInfo5.Content = "";
                lbFileInfoType5.Content = "";
            }
        }

        private void ChangeCommonMediaInfo()
        {
            try
            {

                lbTitle.Content = Path.GetFileName(FilesFromFolders2[SelectedIndexListView]);
                CustomFileInfo cs = new CustomFileInfo(FilesFromFolders[SelectedIndexListView]);
                lbFileInfo4.Content = cs.Creation.ToString();
                lbFileInfo6.Content = cs.Modification.ToString();
                lbFileInfo1.Content = cs.FileSize.ToString();
                lbFileInfo3.Content = cs.extension;
            }
            catch { }
        }

        private void ChangeMetadataForVideo()
        {
            lbFileInfoType2.Content = "Resolution: ";
            lbFileInfo2.Content = "no info so far";
            Bitmap bm = new Bitmap(Properties.Resources.video);
            imgMedia.Source = ConvertBitmap(bm);

            PlayerBorder.Visibility = Visibility.Visible;
            ImageBorder.Visibility = Visibility.Collapsed;
            lbFileInfo5.Content = "";
            lbFileInfoType5.Content = "";
        }

        private void ChangeMetadataForMusic()
        {
            Bitmap bm = new Bitmap(Properties.Resources.music);
            imgMedia.Source = ConvertBitmap(bm);

            PlayerBorder.Visibility = Visibility.Collapsed;
            ImageBorder.Visibility = Visibility.Visible;
            MedCont.ChangePictureForCoverArt();

            TagLib.File f = TagLib.File.Create(FilesFromFolders[SelectedIndexListView], TagLib.ReadStyle.Average);
            var duration = (int)f.Properties.Duration.TotalSeconds;
            TimeSpan time = TimeSpan.FromSeconds(duration);
            lbFileInfo2.Content = time.ToString();
            lbFileInfoType2.Content = "Duration: ";
            lbFileInfoType5.Content = "Album: ";
            lbFileInfo5.Content = f.Tag.Album;
            ShowMp3EditButtons();
        }

        private void ShowMp3EditButtons()
        {
            dpnButtons.Visibility = Visibility.Visible;
            btcutMp3.Visibility = Visibility.Visible;
            btcutMp3.Click += btCutMp3_Click;
            btConcatMp3.Visibility = Visibility.Visible;
            btConcatMp3.Click += btForgeMp3_Click;
            btChangeAlbum.Visibility = Visibility.Visible;
            btChangeAlbum.Click += ChangeAlbum_Click;
        }

        private void ChangeAlbum_Click(Object sender, EventArgs e)
        {
            //Microsoft.VisualBasic.Interaction.InputBox("Please enter a new album name" + "Title", "Default Text");
        }

        private void HideMp3EditButtons()
        {
            dpnButtons.Visibility = Visibility.Collapsed;
            btcutMp3.Visibility = Visibility.Collapsed;
            btConcatMp3.Visibility = Visibility.Collapsed;
            btChangeAlbum.Visibility = Visibility.Collapsed;
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

        public BitmapImage ConvertBitmap(Bitmap src)
        {
            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)src).Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
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
            ++FileListView.SelectedIndex;
        }

        private void PlayPrevious(Object sender, EventArgs e)
        {
            MedCont.PlayPrevious();
            --FileListView.SelectedIndex;
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
            Add_folder af = new Add_folder(this);
            af.Show();
        }

        private void btRemoveFolder_Click(object sender, RoutedEventArgs e)
        {
            RemoveFolder rf = new RemoveFolder(this);
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

        private void cbImg_Checked(object sender, RoutedEventArgs e)
        {
            List<string> ImgList = Sorter.ImgSorter(FilesFromFolders);
            if (cbVid.IsChecked ?? true)
            {
                ImgList = ImgList.Concat(Sorter.VideoSorter(FilesFromFolders)).ToList();
            }
            if (cbSong.IsChecked ?? true)
            {
                ImgList = ImgList.Concat(Sorter.SongSorter(FilesFromFolders)).ToList();
            }
            DisplayFiles(ImgList);
        }

        private void cbVid_Checked(object sender, RoutedEventArgs e)
        {
            List<string> VidList = Sorter.VideoSorter(FilesFromFolders);
            if (cbImg.IsChecked ?? true)
            {
                VidList = VidList.Concat(Sorter.ImgSorter(FilesFromFolders)).ToList();
            }
            if (cbSong.IsChecked ?? true)
            {
                VidList = VidList.Concat(Sorter.SongSorter(FilesFromFolders)).ToList();
            }
            DisplayFiles(VidList);
        }

        private void cbSong_Checked(object sender, RoutedEventArgs e)
        {
            List<string> SongList = Sorter.SongSorter(FilesFromFolders);
            if (cbVid.IsChecked ?? true)
            {
                SongList = SongList.Concat(Sorter.VideoSorter(FilesFromFolders)).ToList();
            }
            if (cbImg.IsChecked ?? true)
            {
                SongList = SongList.Concat(Sorter.ImgSorter(FilesFromFolders)).ToList();
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
            MedCont = new MediaPlayerController(this, myMedia, FilesToDisplay, 0);
            FilesFromFolders2 = FilesToDisplay;
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
                    DisplayFiles(FilesFromFolders);
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
                    DisplayFiles(FilesFromFolders);
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
                    DisplayFiles(FilesFromFolders);
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<string> FoundFiles = Sorter.Search(FilesFromFolders, tbSearch.Text);
            DisplayFiles(FoundFiles);
        }

        private void tbSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            tbSearch.Text = "";
        }

        private void FileListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!MedCont.IsItPicture())
            {
                StopPlaying();
            }

            MediaPlayer player = new MediaPlayer(SelectedIndexListView, FilesFromFolders2);
            player.Show();

        }

        private void btChangeAlbum_Click(object sender, RoutedEventArgs e)
        {
            EditMp3Album em = new EditMp3Album(FilesFromFolders[SelectedIndexListView]);
            em.Show();
        }
    }
}