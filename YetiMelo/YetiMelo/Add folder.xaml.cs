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

        public Add_folder()
        {
            InitializeComponent();
        }

        private void btAddFolder_Click(object sender, RoutedEventArgs e)
        {

            this.save = true;

            //write the Query here!!
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
    }
}
