using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Communication;

namespace Client
{
    class Client
    {
        private string hostname;
        private int port;

        public Client(string h, int p)
        {
            hostname = h;
            port = p;
        }

        public void start()
        {
            TcpClient comm = new TcpClient(hostname, port);
            Console.WriteLine("Connection established");
             
               while (true)
               {
                //1.Send message through console 
                Console.WriteLine("Talk:");
                string str_message = Console.ReadLine();

                Chat_message message = new Chat_message(str_message, hostname);
                   Console.WriteLine(message);

                   

                //streaming
                   Net.sendMsg(comm.GetStream(), message);
                 //  Console.WriteLine("Result = " + (Result)Net.rcvMsg(comm.GetStream()));


               }
           
        }

    }
}
