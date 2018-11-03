using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Communication;
using System.Net;

class Client
    {
        private string ip;
         public int port;
        
        public TcpClient comm;
       
        public  string target_ip;
        public Client(string t_ip, int p)
        {
        // this.alias = alias;
            target_ip = t_ip;
             port = p;
             ip = getIPAddress();
        }

         public void connect()
         {
        this.comm = new TcpClient(target_ip, port);
       // Console.WriteLine("Connection established");

       }
        public static string getIPAddress()
        {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if(ip.AddressFamily==AddressFamily.InterNetwork)
            { return ip.ToString(); }

        }
        throw new Exception("Local IP Address Not Found! :'(");
        }
        public void start()
        {

             
               while (true)
               {
                //1.Send message through console 
                Console.WriteLine("Talk:");
                string str_message = Console.ReadLine();

               // Chat_message message = new Chat_message(str_message, hostname);
                 //  Console.WriteLine(message);

                   

                //streaming
                 //  Net.sendMsg(comm.GetStream(), message);
                 //  Console.WriteLine("Result = " + (Result)Net.rcvMsg(comm.GetStream()));


               }
           
        }

    }

