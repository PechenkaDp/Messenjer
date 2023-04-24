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
    /// Логика взаимодействия для Sozd.xaml
    /// </summary>
    public partial class Sozd : Window
    {
        public Sozd()
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
                    Global.NameStr = NameZ.Text;
                    string ip;
                    int pr1 = Convert.ToInt32(IPshnik1.Text);
                    int pr2 = Convert.ToInt32(IPshnik2.Text);
                    int pr3 = Convert.ToInt32(IPshnik3.Text);
                    int pr4 = Convert.ToInt32(IPshnik4.Text);
                    if (pr1 > 255 || pr2 > 255 || pr3 > 255 || pr4 > 255 || pr1 < 0 || pr2 < 0 || pr3 < 0 || pr4 < 0)
                    {
                        MessageBox.Show("Недопустимый адрес");
                    }
                    else
                    {
                        ip = IPshnik1.Text + '.' + IPshnik2.Text + '.' + IPshnik3.Text + '.' + IPshnik4.Text;
                        Global.IP = ip;
                        int mem = Convert.ToInt32(Members.Text);
                        if (String.IsNullOrEmpty(Members.Text) || mem < 2)
                        {
                            MessageBox.Show("Ошибка в присвоении количества участников");
                        }
                        else
                        {

                            Global.Kolich = Convert.ToInt32(Members.Text);
                            int kol = Global.IP.Count(c => c == '.');
                            if (kol == 3)
                            {
                                Server pril = new Server();
                                pril.Show();
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Неправильный формат IP");
                            }
                        }
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
