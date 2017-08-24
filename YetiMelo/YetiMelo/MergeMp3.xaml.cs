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

namespace YetiMelo
{
    /// <summary>
    /// Interaction logic for MergeMp3.xaml
    /// </summary>
    public partial class MergeMp3 : Window
    {
        private static MergeMp3 instance;

        private MergeMp3()
        {
            InitializeComponent();
        }

        public static MergeMp3 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MergeMp3();
                }
                return instance;
            }
        }

        private void ResetWindow()
        {
            this.Close();
            instance = null;
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            ResetWindow();
        }

        private void btSelectDesitnation_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd2 = new FolderBrowserDialog() { Description = "Select your path." };

            fbd2.ShowDialog();
            tbDestinationPath.Text = fbd2.SelectedPath;

        }

        private void btSelectMp3_Click(object sender, RoutedEventArgs e)
        {

            tbMp3Path.Text = SelectFilePath();

        }

        private void btSelectMp32_Click(object sender, RoutedEventArgs e)
        {

            tbMp3Path2.Text = SelectFilePath();

        }

        private void btMerge_Click(object sender, RoutedEventArgs e)
        {
            if (InputCheck.Mergable(tbMp3Path.Text, tbMp3Path2.Text, tbNewFileName.Text, tbDestinationPath.Text))
            {
                string[] Mps3Paths = new string[] { tbMp3Path.Text, tbMp3Path2.Text };
                string NewMp3 = tbDestinationPath.Text + "\\" + InputCheck.CreateMp3Format(tbNewFileName.Text);
                Mp3Editor.Mp3Concat(Mps3Paths, NewMp3);
                System.Windows.MessageBox.Show("The merging was successfull.");
                ResetWindow();
            }
            else
            {
                System.Windows.MessageBox.Show("Please fill in everything.");
            }
        }

        private void tbNewFileName_GotFocus(object sender, RoutedEventArgs e)
        {
            tbNewFileName.Text = "";
        }

        private string SelectFilePath()
        {
            OpenFileDialog fbd2 = new OpenFileDialog();
            fbd2.ShowDialog();
            while (!InputCheck.Mp3Format(fbd2.FileName))
            {
                System.Windows.MessageBox.Show("Please choose an mp3 file.");
                fbd2.ShowDialog();
            }
            return fbd2.FileName;
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }
    }
}
