using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для Prilozenie.xaml
    /// </summary>
    public partial class Prilozenie : Window
    {
        string ad;
        string ip;
        private Socket server;
        public Prilozenie()
        {
            InitializeComponent();
            AdminN.IsReadOnly= true;
            ad = Global.NameStr;
            AdminN.Text = ad;
            ip = Global.IPsh;

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.ConnectAsync($"{ip}", 8888);
            RecieveSoobsh();
            
        }

        private async Task RecieveSoobsh()
        {
            while (true)
            {
                byte[] bytes = new byte[1024];
                await server.ReceiveAsync(bytes, SocketFlags.None);
                string soobsh = Encoding.UTF8.GetString(bytes);
                Soobsheniya.Items.Add(soobsh);
            }
        }
        private async Task SendSoobsh( string soobsh)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(soobsh);
            await server.SendAsync(bytes, SocketFlags.None);
        }

        private void Otprav_Click(object sender, RoutedEventArgs e)
        {
            SendSoobsh(Soobsheniye.Text);
        }
    }
}
