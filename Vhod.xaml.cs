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

namespace Messenjer
{
    /// <summary>
    /// Логика взаимодействия для Vhod.xaml
    /// </summary>
    public partial class Vhod : Window
    {
        
        public Vhod()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(NameZ.Text))
                {
                    MessageBox.Show("Введите имя");
                }
                else
                {
                    Global.NameUseR = NameZ.Text;

                    if (String.IsNullOrEmpty(IPshnik.Text))
                    {
                        MessageBox.Show("Вы не ввели IP");
                    }
                    else
                    {
                        Global.IPsh = Convert.ToString(IPshnik.Text);
                        Prilozenie pril = new Prilozenie();
                        pril.Show();
                        Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Так делать нельзя");
            }
        }
    }
}
