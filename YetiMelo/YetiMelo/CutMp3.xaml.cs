using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace YetiMelo
{
    /// <summary>
    /// Interaction logic for CutMp3.xaml
    /// </summary>
    public partial class CutMp3 : Window
    {
        public CutMp3()
        {
            InitializeComponent();
        }

        private void btTrimFile_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            //insert logic here
        }

        private void btSelectMp3_Click(object sender, RoutedEventArgs e)
        {
            using (var fbd = new OpenFileDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                {
                    tbMp3Path.Text = fbd.FileName;
                }
            }
        }

        private void btSelectDesitnation_Click(object sender, RoutedEventArgs e)
        {

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    tbDestinationPath.Text = fbd.SelectedPath;
                }
            }

        }
    }
}
