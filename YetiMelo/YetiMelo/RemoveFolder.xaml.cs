using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace YetiMelo
{

    /// <summary>
    /// Interaction logic for RemoveFolder.xaml
    /// </summary>
    public partial class RemoveFolder : Window
    {
        int SelectedItem;
        List<string> folders;
        bool SelectedSomething;
        MainWindow MainForm;

        public RemoveFolder()
        {
            InitializeComponent();
            FillFolders();
        }

        public RemoveFolder(MainWindow MainForm)
        {
            this.MainForm = MainForm;
            InitializeComponent();
            FillFolders();
        }

        private void FillFolders()
        {
            ///please insert here to loader query
            folders = PathManager.ReadFromFile();
            lwFolders.ItemsSource = folders;
        }

        private void btRemoveFolder_Click(object sender, RoutedEventArgs e)
        {
            if (folders.Count > 0 && SelectedSomething)
            {
                folders.RemoveAt(SelectedItem);
                PathManager.SaveToFile(folders);
                this.Close();
                MessageBox.Show("Folder Removed");
            }
            else
            {
                MessageBox.Show("Nothing to Remove");
            }

            MainForm.FileListView.ItemsSource = null;
            MainForm.FileListView.Items.Clear();
            MainForm.GetFilesFromFolders();
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }

        private void lwFolders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedSomething = true;
            SelectedItem = lwFolders.SelectedIndex;
        }
    }
}