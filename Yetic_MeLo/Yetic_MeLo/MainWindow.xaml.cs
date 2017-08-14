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
            EntityManager db = new EntityManager();
            db.TruncateTable("FoldersSet");
            db.AddToFolders("thisisapath", true, false, true);
            db.AddToFolders("thisisananotherpath", false, true, true);
            db.DeleteFromFolders(2);
            db.UpdateFromFolders(1, "banana", false, false, false);
            Console.WriteLine(db.SelectFromFolders(1));
        }
    }
}
