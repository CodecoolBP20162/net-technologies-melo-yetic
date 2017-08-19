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
            //insert logic here
            //if (CheckNumber() && InputCheck.Trimmable(tbMp3Path.Text, tbNewFileName.Text, tbDestinationPath.Text, Convert.ToInt32(tbCutFrom.Text), Convert.ToInt32(tbCutTo.Text)))
            if (InputCheck.Trimmable(tbMp3Path.Text, tbNewFileName.Text, tbDestinationPath.Text, Convert.ToInt32(tbCutFrom.Text), Convert.ToInt32(tbCutTo.Text)))
                {
                string NewMp3 = tbDestinationPath.Text + "\\" + InputCheck.CreateMp3Format(tbNewFileName.Text);
                Mp3Editor.Mp3Trim(tbMp3Path.Text, NewMp3, TimeSpan.FromMinutes(Convert.ToInt32(tbCutFrom.Text)), TimeSpan.FromMinutes(Convert.ToInt32(tbCutTo.Text)));
                System.Windows.MessageBox.Show("The trim was successful.");
                this.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Please fill in everything.");
            }
        }

        private Boolean CheckNumber()
        {
            if (!InputCheck.IsNumber(tbCutFrom.Text))
            {
                System.Windows.MessageBox.Show("Please use a number");
                return false;
            }
            if (!InputCheck.IsNumber(tbCutTo.Text))
            {
                System.Windows.MessageBox.Show("Please use a number");
                return false;
            }
            return true;
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btSelectMp3_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fbd = new OpenFileDialog();
            fbd.ShowDialog();
            while (!InputCheck.Mp3Format(fbd.FileName))
            {
                System.Windows.MessageBox.Show("Please choose an mp3 file.");
                fbd.ShowDialog();
            }
            tbMp3Path.Text = fbd.FileName;
        }

        private void btSelectDesitnation_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            while (fbd.SelectedPath=="")
            {
                System.Windows.MessageBox.Show("Please choose a folder.");
                fbd.ShowDialog();
            }
            tbDestinationPath.Text = fbd.SelectedPath;
        }

        private void tbCutFrom_GotFocus(object sender, RoutedEventArgs e)
        {
            tbCutFrom.Text = "";
        }

        private void tbCutTo_GotFocus(object sender, RoutedEventArgs e)
        {
            tbCutTo.Text = "";
        }

        private void tbNewFileName_GotFocus(object sender, RoutedEventArgs e)
        {
            tbNewFileName.Text = "";
        }
    }
}
