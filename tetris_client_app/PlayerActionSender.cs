using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace tetrisCient
{
    class PlayerActionSender
    {
        private NetworkStream stream;
        private KeyboardListener listener;

        public PlayerActionSender(NetworkStream stream)
        {
            this.stream = stream;
            listener = new KeyboardListener();
        }

        internal void Run()
        {
            while(true)
            {
                string code = listener.WaitForCertainPress();

                byte[] data = Encoding.UTF8.GetBytes(code);
                stream.Write(data, 0, data.Length);
            }
        }
    }
}
