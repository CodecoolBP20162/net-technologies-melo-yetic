using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace YetiMelo
{
    /// <summary>
    /// Interaction logic for MediaPlayer.xaml
    /// </summary>
    public partial class MediaPlayer : Window
    {
        MediaPlayerController MedCont;
        bool userIsDraggingSlider = false;

        public MediaPlayer()
        {
            InitializeComponent();
            myMedia.Volume = 100;


            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        public MediaPlayer(int playListPos, List<string> playL)
        {
            InitializeComponent();
            myMedia.Source = new Uri(playL[playListPos], UriKind.Relative);
            myMedia.Play();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
            MedCont = new MediaPlayerController(this, myMedia, playL, playListPos);
        }


        void TogglePlay(Object sender, EventArgs e)
        {
            if (!MedCont.IsPlaying)
            {
                myMedia.Play();
                MedCont.IsPlaying = true;
                PlayButton.Visibility = Visibility.Collapsed;
                PauseButton.Visibility = Visibility.Visible;
            }
            else
            {
                myMedia.Pause();
                MedCont.IsPlaying = false;
                PauseButton.Visibility = Visibility.Collapsed;
                PlayButton.Visibility = Visibility.Visible;
            }
        }

        //event handler for play button
        void MediaPlay(Object sender, EventArgs e)
        {
            myMedia.Play();
        }

        //event handler for changig the source of the media element to the next in the list
        void PlayNext(Object sender, EventArgs e)
        {
            MedCont.PlayNext();
        }
        //event hadler for changig the source of the media element to the previous in the list
        void PlayPrevious(Object sender, EventArgs e)
        {
            MedCont.PlayPrevious();
        }
        //event handler for pause button
        void MediaPause(Object sender, EventArgs e)
        {
            myMedia.Pause();

        }
        //event handler for mute button
        void MediaMute(Object sender, EventArgs e)
        {
            if (myMedia.Volume == 100)
            {
                myMedia.Volume = 0;
            }
            else
            {
                myMedia.Volume = 100;
            }
        }
        //event handler for hiding showing menu bar
        void ToggleMenu(object sender, MouseButtonEventArgs e)
        {
            if (menuBar.Visibility == Visibility.Visible)
            {
                menuBar.Visibility = Visibility.Hidden;
            }
            else
            {
                menuBar.Visibility = Visibility.Visible;
            }
        }
        //timer to be used for tracking play progress
        private void Timer_Tick(object sender, EventArgs e)
        {
            if ((myMedia.Source != null) && (myMedia.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                sliProgress.Minimum = 0;
                sliProgress.Maximum = myMedia.NaturalDuration.TimeSpan.TotalSeconds;
                sliProgress.Value = myMedia.Position.TotalSeconds;
            }
        }
        //event handler for handling sliderdrag
        private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }
        //event handler for handling sliderdrag and changing actual play time
        private void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            myMedia.Position = TimeSpan.FromSeconds(sliProgress.Value);
        }
        //visualizing play progress
        private void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblProgressStatus.Text = TimeSpan.FromSeconds(sliProgress.Value).ToString(@"hh\:mm\:ss");
        }
        private void closeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btResize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized) { this.WindowState = WindowState.Maximized; }
            else { this.WindowState = WindowState.Normal; }

        }

        private void taskBar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
