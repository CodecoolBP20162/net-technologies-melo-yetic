using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace YetiMelo
{
    class MediaPlayerController
    {
        private List<string> FileList = new List<string>
        {
            "D:\\Test\\Adele - Rolling In The Deep.mp3"
        };
        private Window Form;
        private MainWindow MainForm { get; set; }
        private MediaPlayer Player { get; set; }
        private MediaElement Media { get; set; }
        internal int PlayPosition { get; set; }
        internal bool IsPlaying { get; set; }

        internal MediaPlayerController(MainWindow Form, MediaElement Media, List<string> Files, int position)
        {
            this.Form = Form;
            this.Media = Media;
            this.FileList = Files;
            this.PlayPosition = position;
            SetDefaultProperties();
            this.Form = MainForm;
        }

        internal MediaPlayerController(MediaPlayer Form, MediaElement Media, List<string> Files, int position)
        {
            this.Player = Form;
            this.Media = Media;
            this.FileList = Files;
            this.PlayPosition = position;
            SetDefaultProperties();
            this.Form = Player;


        }

        private void SetDefaultProperties()
        {
            PlayPosition = 0;
            IsPlaying = false;

            InitPlayer();
            Media.Volume = 100;

        }

        void InitPlayer()
        {
            try
            {
                Media.Source = new Uri(FileList[PlayPosition], UriKind.Relative);
            } catch { }
        }

        private void UpdatePlayList(List<string> list)
        {
            FileList = list;
        }

        internal void PlayNext()
        {
            try
            {
                PlayPosition++;
                Media.Source = new Uri(FileList[PlayPosition], UriKind.Relative);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void PlayPrevious()
        {
            try
            {
                PlayPosition--;
                Media.Source = new Uri(FileList[PlayPosition], UriKind.Relative);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
