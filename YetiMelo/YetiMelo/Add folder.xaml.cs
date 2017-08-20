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
using System.Windows.Forms;
using System.IO;

namespace YetiMelo
{
    /// <summary>
    /// Interaction logic for Add_folder.xaml
    /// </summary>
    public partial class Add_folder : Window
    {
        public bool save;
        public string newPath;
        MainWindow MainForm;

        public Add_folder()
        {
            InitializeComponent();
        }

        public Add_folder(MainWindow MainForm)
        {
            InitializeComponent();
            this.MainForm = MainForm;
        }

        private void btAddFolder_Click(object sender, RoutedEventArgs e)
        {

            this.save = true;

            List<string> folders = PathManager.ReadFromFile();
            if (!folders.Contains(tbPath.Text))
            {
                folders.Add(tbPath.Text);
                PathManager.SaveToFile(folders);
                this.Close();
                MainForm.FileListView.ItemsSource = null;
                MainForm.FileListView.Items.Clear();
                MainForm.GetFilesFromFolders();
            }
            else
            {
                System.Windows.MessageBox.Show("This folder is already watched");
            }
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            if (!(this.save))
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    btAddFolder_Click(sender, e);
                }
                this.Close();
            }
            this.Close();

        }

        private void btSelect_Click(object sender, RoutedEventArgs e)
        {

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    tbPath.Text = fbd.SelectedPath;
                    this.newPath = fbd.SelectedPath;
                }
            }

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }
    }
}
