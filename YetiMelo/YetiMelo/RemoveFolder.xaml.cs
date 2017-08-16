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
    /// Interaction logic for RemoveFolder.xaml
    /// </summary>
    public partial class RemoveFolder : Window
    {
        public RemoveFolder()
        {
            InitializeComponent();
            FillFolders();
        }

        private void FillFolders()
        {
            ///please insert here to loader query
        }

        private void btRemoveFolder_Click(object sender, RoutedEventArgs e)
        {
            ///please insert here the removing logic
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
