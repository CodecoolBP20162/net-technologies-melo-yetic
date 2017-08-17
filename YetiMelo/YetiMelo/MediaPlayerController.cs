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
        private List<string> FileList;
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
            IsPlaying = true;

            InitPlayer();
            Media.Volume = 100;

        }

        void InitPlayer()
        {
            HideOrShowButtons(FileList[PlayPosition]);
        }

        private void UpdatePlayList(List<string> list)
        {
            FileList = list;
        }

        internal void PlayCurrent()
        {
            try
            {
                Media.Source = new Uri(FileList[PlayPosition], UriKind.Relative);

                HideOrShowButtons(FileList[PlayPosition]);

            }
            catch (Exception ex)
            {
                if (!ex.GetType().Equals(typeof(ArgumentOutOfRangeException)))
                    MessageBox.Show(ex.Message);
            }
        }

        internal void PlayNext()
        {
            try
            {
                PlayPosition++;
                Media.Source = new Uri(FileList[PlayPosition], UriKind.Relative);

                HideOrShowButtons(FileList[PlayPosition]);

            }
            catch (Exception ex)
            {
                if (!ex.GetType().Equals(typeof(ArgumentOutOfRangeException)))
                    MessageBox.Show(ex.Message);
            }
        }

        internal void PlayPrevious()
        {
            try
            {
                PlayPosition--;
                Media.Source = new Uri(FileList[PlayPosition], UriKind.Relative);

                HideOrShowButtons(FileList[PlayPosition]);

            }
            catch (Exception ex)
            {
                if (!ex.GetType().Equals(typeof(ArgumentOutOfRangeException)))
                    MessageBox.Show(ex.Message);
            }
        }

        private void TurnOnSoundAndVideoOptions()
        {
            if (Player != null)
            {
                Media.Pause();
                IsPlaying = false;
                Player.PlayButton.Visibility = Visibility.Visible;
                Player.PauseButton.Visibility = Visibility.Collapsed;
                Player.statusBar.Visibility = Visibility.Visible;
            }
        }

        private void TurnOffSoundAndVideoOptions()
        {
            if (Player != null)
            {
                Media.Play();
                IsPlaying = true;
                Player.PlayButton.Visibility = Visibility.Collapsed;
                Player.PauseButton.Visibility = Visibility.Collapsed;
                Player.statusBar.Visibility = Visibility.Collapsed;
            }
        }

        internal bool IsItVideo()
        {
            if (Media.HasAudio && Media.HasVideo)
                return true;
            return false;
        }

        internal bool IsItMusic()
        {
            if (Media.HasAudio && !Media.HasVideo)
                return true;
            return false;
        }

        internal bool IsItPicture(string path)
        {
            List<string> pictext = new List<string> { ".jpg", ".bmp" };
            if (pictext.Contains(System.IO.Path.GetExtension(path).ToLower()))
                return true;
            return false;
        }

        internal void HideOrShowButtons(string path)
        {
            if (IsItPicture(path))
            {
                TurnOffSoundAndVideoOptions();
            }
            else
            {
                TurnOnSoundAndVideoOptions();
            }
        }
    }
}
