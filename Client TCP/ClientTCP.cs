using System.Net;
using System.Net.Sockets;
using System.Text;
namespace ClientTCP
{
    class ClientTCP
    {
        static void Main(string[] args)
        {
            #region TCP Client
            //тут задаються ті ж ip та port
            const string ip = "127.0.0.1";
            const int port = 8080;

            //той же ендпойнт та сокет
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("enter your message");
            var message = Console.ReadLine();

            //закодовуємо повідомлення:
            var data = Encoding.UTF8.GetBytes(message);

            //відкриваємо сокет (робимо підключення до нього через команду Connect)
            tcpSocket.Connect(tcpEndPoint);

            //відправляємо повідомлення:
            tcpSocket.Send(data);

            //тобто відправка запроса відбувається так само як і отримання відповіді

            var buffer = new byte[256];
            var size = 0;
            var answer = new StringBuilder(); //наша відповідь із сервера

            //отримуємо відповідь:
            do
            {
                size = tcpSocket.Receive(buffer);

                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));

            } while (tcpSocket.Available > 0);

            Console.WriteLine(answer.ToString());

            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();
            #endregion

            #region UDP Client
            const string ip2 = "127.0.0.1";
            const int port2 = 8082;

            var udpEndPoint = new IPEndPoint(IPAddress.Parse(ip2), port2);
            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            udpSocket.Bind(udpEndPoint);

            while (true)
            {
                Console.WriteLine("Write your message:");
                var message2 = Console.ReadLine();

                var udpServerEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8081);
                udpSocket.SendTo(Encoding.UTF8.GetBytes(message2), udpServerEndPoint);

                var buffer2 = new byte[256];
                var size2 = 0;
                var data2 = new StringBuilder();

                EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);

                do
                {
                    size2 = udpSocket.ReceiveFrom(buffer2, ref senderEndPoint);
                    data2.Append(Encoding.UTF8.GetString(buffer2));
                } while (udpSocket.Available > 0);

                Console.WriteLine(data.ToString());
                Console.ReadLine();

                udpSocket.Shutdown(SocketShutdown.Both);
                udpSocket.Close();
            }



            #endregion


        }
    }
}