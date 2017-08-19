using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace YetiMelo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int selectedIndexListView;
        List<string> FileList;
        FolderWatcher watcher;

        List<string> playList = new List<string>
        {
            "C:\\Users\\Dodo\\Desktop\\test\\new.mp3" , "C:\\Users\\Dodo\\Desktop\\test\\Radiorama - Yeti (album version)" , "C:\\Users\\Dodo\\Desktop\\test\\d.mp3",
            "C:\\Users\\Dodo\\Desktop\\test\\giga.mp3" , "C:\\Users\\Dodo\\Desktop\\test\\extralong.mp3"    
        };

        int playListPosition = 0;
        bool isPlaying = false;

        public MainWindow()
        {
            InitializeComponent();
            myMedia.Volume = 100;
            InitPlayer();

            FolderScanner scanner = new FolderScanner();
            List<string> AllowedExtensions = new List<string> { ".mp3", ".jpg", ".mp4", ".png"};
            List<string> folders = new List<string> { "C:\\Users\\Dodo\\Desktop\\test"};
            FileList = scanner.GetFiles(folders, AllowedExtensions);
            DisplayFiles(FileList);


            watcher = new FolderWatcher();


        }

        private void FileListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedIndexListView = FileListView.SelectedIndex;
        }

        private void FileListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MediaPlayer player = new MediaPlayer(selectedIndexListView, FileList);
            player.Show();
        }
        

        void UpdatePlayList(List<string> list)
        {
            playList = list;
        }

        void InitPlayer()
        {
            myMedia.Source = new Uri(playList[playListPosition], UriKind.Relative);
        }

        void MediaPlay(Object sender, EventArgs e)
        {
            myMedia.Play();

        }

        void TogglePlay(Object sender, EventArgs e)
        {
            if (!isPlaying)
            {
                myMedia.Play();
                isPlaying = true;
                PlayButton.Visibility = Visibility.Collapsed;
                PauseButton.Visibility = Visibility.Visible;
            }
            else
            {
                myMedia.Pause();
                isPlaying = false;
                PauseButton.Visibility = Visibility.Collapsed;
                PlayButton.Visibility = Visibility.Visible;
            }
        }

        void PlayNext(Object sender, EventArgs e)
        {
            try
            {
                playListPosition++;
                myMedia.Source = new Uri(playList[playListPosition], UriKind.Relative);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void PlayPrevious(Object sender, EventArgs e)
        {
            try
            {
                playListPosition--;
                myMedia.Source = new Uri(playList[playListPosition], UriKind.Relative);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void MediaPause(Object sender, EventArgs e)
        {
            myMedia.Pause();
            //btnPlay.Visibility = Visibility.Visible;
            //btnPause.Visibility = Visibility.Collapsed;
        }

        void MediaMute(Object sender, EventArgs e)
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
        }
    }
}
