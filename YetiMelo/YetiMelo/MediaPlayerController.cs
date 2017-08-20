using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
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
            this.MainForm = Form;
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
                Media.Play();
                IsPlaying = false;
                Player.PlayButton.Visibility = Visibility.Visible;
                Player.PauseButton.Visibility = Visibility.Collapsed;
                Player.statusBar.Visibility = Visibility.Visible;
                Player.PlayerBorder.Visibility = Visibility.Visible;
                Player.ImageBorder.Visibility = Visibility.Collapsed;
                if (IsItMusic())
                {
                    Player.PlayerBorder.Visibility = Visibility.Collapsed;
                    Player.ImageBorder.Visibility = Visibility.Visible;
                    ChangePictureForCoverArt();
                }
            }
            else
            {
                Media.Pause();
                IsPlaying = false;
                MainForm.PlayButton.Visibility = Visibility.Visible;
                MainForm.PauseButton.Visibility = Visibility.Collapsed;
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
                Player.PlayerBorder.Visibility = Visibility.Visible;
                Player.ImageBorder.Visibility = Visibility.Collapsed;
            }
            else
            {
                Media.Play();
                IsPlaying = true;
                MainForm.PlayButton.Visibility = Visibility.Collapsed;
                MainForm.PauseButton.Visibility = Visibility.Collapsed;
            }
        }

        internal bool IsItVideo()
        {

            List<string> vidext = new List<string> { ".avi", ".mkv", ".mp4" };

            if (vidext.Contains(System.IO.Path.GetExtension(FileList[PlayPosition]).ToLower()))
                return true;
            return false;
        }

        internal bool IsItMusic()
        {
            List<string> music = new List<string> { ".mp3", ".wav", ".mid" };
            if (music.Contains(System.IO.Path.GetExtension(FileList[PlayPosition]).ToLower()))
                return true;
            return false;
        }

        internal bool IsItPicture()
        {
            List<string> pictext = new List<string> { ".jpg", ".bmp", ".png" };
            if (pictext.Contains(System.IO.Path.GetExtension(FileList[PlayPosition]).ToLower()))
                return true;
            return false;
        }

        internal void HideOrShowButtons(string path)
        {
            if (IsItPicture())
            {
                TurnOffSoundAndVideoOptions();
            }
            else
            {
                TurnOnSoundAndVideoOptions();
            }
        }

        internal void ChangePictureForCoverArt()
        {
            try
            { 
                TagLib.File file = TagLib.File.Create(FileList[PlayPosition]);

                // Load you image data in MemoryStream
                TagLib.IPicture pic = file.Tag.Pictures[0];
                MemoryStream ms = new MemoryStream(pic.Data.Data);
                ms.Seek(0, SeekOrigin.Begin);

                // ImageSource for System.Windows.Controls.Image
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = ms;
                bitmap.EndInit();

                // Create a System.Windows.Controls.Image control
                System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                img.Source = bitmap;
                if(MainForm != null)
                {
                    MainForm.PictureForMusic.Source = img.Source;
                }
                else
                {
                    Player.PictureForMusic.Source = img.Source;
                }

            }
            catch (Exception e)
            {
                if (MainForm != null)
                {
                    MainForm.PictureForMusic.Source = MainForm.logo.Source;
                }
                else
                {
                    Player.PictureForMusic.Source = Player.logo.Source;
                }

            }
        }
    }
}
