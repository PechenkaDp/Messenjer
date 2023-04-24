using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для Server.xaml
    /// </summary>
    public partial class Server : Window
    {
        private Socket socket;
        private List<Socket> users = new List<Socket>();
        string adress;
        public Server()
        {
            InitializeComponent();
            InitializeComponent();
            AdminN.IsReadOnly = true;
            string ad = Global.NameStr;
            AdminN.Text = ad;
            adress = Global.IP;

            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 8888);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipPoint);
            socket.Listen(Global.Kolich);
            ListenUsers();
        }
        private async Task ListenUsers()
        {
            while(true)
            {
                var UsEr = await socket.AcceptAsync();
                Uchastnik.Items.Add(UsEr);
                users.Add(UsEr);
                Recieved(UsEr);
            }
        }
        private async Task Recieved(Socket UsEr)
        {
            byte[] bytes = new byte[1024];
            await UsEr.ReceiveAsync(bytes, SocketFlags.None);
            string soobsh = Encoding.UTF8.GetString(bytes);

            Soobsheniya.Items.Add($"<{UsEr.RemoteEndPoint}>: {soobsh}");

            foreach (var item in users)
            {
                SendSoobsh(item, soobsh);
            }
        }
        private async Task SendSoobsh(Socket UsEr, string soobsh)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(soobsh);
            await UsEr.SendAsync(bytes, SocketFlags.None);
        }

    }
}
