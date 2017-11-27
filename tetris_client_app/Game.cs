using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace tetrisCient
{
    class Game
    {
        private TcpClient tcpClient = new TcpClient();
        private ArrayPrinter printer = new ArrayPrinter();
        private NetworkStream stream;
        private PlayerActionSender actionSender;
        private string host;
        private int port;

        public Game(string host, int port)
        {
            this.host = host;
            this.port = port;
        }

        public void Start()
        {
            tcpClient.Connect(host, port);
            stream = tcpClient.GetStream();
            actionSender = new PlayerActionSender(stream);

            Thread senderThread = new Thread(new ThreadStart(actionSender.Run));
            senderThread.Start();

            byte[] data;
            do
            {
                if (stream.DataAvailable) {
                    Console.Clear();
                    data = new byte[1024];
                    int bytes = stream.Read(data, 0, data.Length);
                    string input = Encoding.UTF8.GetString(data);

                    if (input.Contains("666"))
                    {
                        senderThread.Abort();
                        tcpClient.Close();
                        stream.Close();
                        break;
                    }
                    else
                    {

                        //Состояние полотна (массив представляющий фигуры с блоками) приходит в виде такой длинной строки |*|| |.. и в конце я к нему 
                        //прикрепляю строку Total scores: "ОЧКИ" 
                        //Так вот здесь я отделяю полотно от очков которые заработал игрок
                        int index = input.IndexOf("Total");
                        string totalScores = input.Substring(index);
                        input = input.Substring(0, index);

                        string[,] state = StringTo2DArrayDecoder.Decode(input);

                        Console.WriteLine("Game has started");
                        printer.Print(state);
                        Console.WriteLine("------------------------------");
                        Console.WriteLine(totalScores);
                    }
                }
            } while (true);  
        }
    }
}
