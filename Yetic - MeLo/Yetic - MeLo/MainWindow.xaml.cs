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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Yetic___MeLo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            bool musicOn = true;
            bool imagesOn = true;
            bool videoOn = true;
            bool currentFileIsPicute = false;
            bool isBigPlayer = false;
        }

        private void btnPinPanel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void closeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void fullScreen_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
            btnFullScreen.Visibility = Visibility.Hidden;
            btnOriginalScreen.Visibility = Visibility.Visible;
        }

        private void originalScreen_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;
            btnFullScreen.Visibility = Visibility.Visible;
            btnOriginalScreen.Visibility = Visibility.Hidden;

        }

        private void taskBar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPrev_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnPlayerFullScreen_Click(object sender, RoutedEventArgs e)
        {
            wpPlayer.
        }
    }
}
