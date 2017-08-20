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

namespace YetiMelo
{
    /// <summary>
    /// Interaction logic for EditMp3Album.xaml
    /// </summary>
    public partial class EditMp3Album : Window
    {
        public string filePath;

        public EditMp3Album(string path)
        {
            InitializeComponent();
            this.filePath = path;
            InitLabels();
        }


        public void InitLabels()
        {
            TagLib.File f = TagLib.File.Create(filePath);
            lbAlbumName.Text = f.Tag.Album;
            MessageBox.Show("Succes, bitches!");
            this.Close();
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            TagLib.File f = TagLib.File.Create(filePath);
            f.Tag.Album = lbAlbumName.Text;
            f.Save();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }
    }
}
