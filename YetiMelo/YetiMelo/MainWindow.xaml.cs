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
            "E:\\Test\\01.jpg" , "E:\\Test\\02.jpg" , "E:\\Test\\03.jpg",
            "E:\\Test\\01.mp3" , "E:\\Test\\02.mp3" , "E:\\Test\\03.mp3",
            "E:\\Test\\01.mp4" , "E:\\Test\\02.mp4" , "E:\\Test\\03.mp4"
        };

        int playListPosition = 0;
        bool isPlaying = false;

        public MainWindow()
        {
            InitializeComponent();
            myMedia.Volume = 100;
            InitPlayer();

            FolderScanner scanner = new FolderScanner();
            List<string> AllowedExtensions = new List<string> { ".mp3", ".jpg", ".mp4", };
            List<string> folders = new List<string> { "E:\\Test", "E:\\Test2" };
            FileList = scanner.GetFiles(folders, AllowedExtensions);
            List<CustomFileInfo> FileInfoList = new List<CustomFileInfo>();
            foreach (string item in FileList)
            {
                CustomFileInfo file = new CustomFileInfo(new FileInfo(item));
                FileInfoList.Add(file);
            }

            FileListView.ItemsSource = FileInfoList;


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
    }
}
