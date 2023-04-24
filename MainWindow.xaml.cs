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

namespace Messenjer
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


        private void Sozd_Click(object sender, RoutedEventArgs e)
        {
            Sozd soz = new Sozd();
            soz.Show();
            Close();

        }

        private void Podkl_Click(object sender, RoutedEventArgs e)
        {
            Vhod vh = new Vhod();
            vh.Show();
            Close();

        }
    }
}
