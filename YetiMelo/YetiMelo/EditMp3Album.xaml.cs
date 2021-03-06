﻿using System;
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
        public TagLib.File f;
        private MainWindow mainForm;
        private static EditMp3Album instance;

        private EditMp3Album(string path, MainWindow MainForm)
        {
            InitializeComponent();
            this.filePath = path;
            this.mainForm = MainForm;
            f = TagLib.File.Create(filePath);
            InitLabels();
        }

        public static EditMp3Album getInstance(string path, MainWindow MainForm)
        {
            if (instance == null)
            {
                instance = new EditMp3Album(path, MainForm);
            }
            return instance;
            
        }

        private void ResetWindow()
        {
            this.Close();
            instance = null;
        }

        public void InitLabels()
        {
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            ResetWindow();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                f.Tag.Album = lbAlbumName.Text;
                f.Save();
                mainForm.myMedia.Source = new Uri(filePath, UriKind.Relative);
                MessageBox.Show("Album renamed!");
                ResetWindow();
            }
            catch (Exception ex)
            {
                ResetWindow();
                Console.WriteLine(ex.Message);
        }

    }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }
    }
}
