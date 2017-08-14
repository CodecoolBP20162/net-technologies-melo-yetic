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

namespace Yetic_MeLo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string testFile = "..\\..\\mp3\\Radiorama - Yeti (album version).mp3";
            string[] trimmedFiles= new string[] { "..\\..\\mp3\\test.mp3", "..\\..\\mp3\\test1.mp3" };
            //if (Mp3Editor.TrimMp3(testFile, "..\\..\\mp3\\test1.mp3",TimeSpan.FromMinutes(2.5), TimeSpan.FromMinutes(3))) MessageBox.Show("trim done");
            if (Mp3Editor.Mp3Concat(trimmedFiles,"..\\..\\mp3\\testCombined.mp3")) MessageBox.Show("concat done");
        }
    }
}
