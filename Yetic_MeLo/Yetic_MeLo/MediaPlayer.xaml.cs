using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Yetic_MeLo
{
    /// <summary>
    /// Interaction logic for MediaPlayer.xaml
    /// </summary>
    public partial class MediaPlayer : Window
    {
        public MediaPlayer()
        {
            InitializeComponent();
            myMedia.Volume = 100;
        }
        //event handler for play button
        void mediaPlay(Object sender, EventArgs e)
        {
            myMedia.Play();
        }
        //event hadler to changig the source of the media element such as next previous etc
        //need to implement logic to grab the files we want from the folders and generate uri-s for them
        void ChangeMediaSource(Object sender, EventArgs e)
        {
            myMedia.Source = new Uri("E:\\SampleVideo_1280x720_2mb.mp4", UriKind.Relative);
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
                muteButt.Content = "Listen";
            }
            else
            {
                myMedia.Volume = 100;
                muteButt.Content = "Mute";
            }
        }
    }
}
