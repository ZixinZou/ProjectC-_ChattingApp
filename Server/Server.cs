using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Communication;


namespace Server
{
   // delegate void Delegate_forChat();
     
    public class Server
    {
        static List<Receiver> list_rev = new List<Receiver>();

        static public List<TcpClient> client_list = new List<TcpClient>();
        //static List<TcpClient> chatter_list= new List<TcpClient>();
        static TcpListener l;
        static int cpt = 0;

        static private int port;

        public Server(int p)
        {
            port = p;
            l = new TcpListener(new IPAddress(new byte[] { 127, 0, 0, 66 }), port);
        }

        public void start()
        {

            //int cpt_client = cpt;
            l.Start();

            while (true)
            {

                
                
                ThreadPool.QueueUserWorkItem(new WaitCallback(procedure), l.AcceptTcpClient());
                Console.WriteLine("Connection established @");
                
            }
        }

           // procedure();

        public void procedure(object tcp_client)/////////////////////////////////
        {
            TcpClient client = (TcpClient)tcp_client;

            client_list.Add(client);
            Receiver rev = new Receiver(client);
           // list_rev.Add(rev);
            //authentication
            Thread th_authen = new Thread(rev.authenticate);
            th_authen.Start();
            //sign up
            //check sign_up
            // new Thread(() => { check = sign_up(); }).Start();
            Console.WriteLine("Process 1");

            while (true)
            {
                // Console.WriteLine(check);
               // Console.WriteLine("Wait");
                //  Thread.Sleep(500);
                if (rev.check == true)//authentication passed
                {
                    th_authen.Abort();
                    Console.WriteLine("Authen ended");
                    rev.check = false;//checker reset
                                      //topic selection
                                      //new Thread(() => {(check = topic_selection()};).Start();

                    rev.check = true;//test
                    Console.WriteLine("Process 2");
                    if (rev.check == true)
                    {
                        Console.WriteLine("Process 3");
                        new Thread(rev.doChat).Start();
                        rev.check = false;
                    }


                }
            }
        }

    }



        }


        

        class Receiver
        {
            private TcpClient comm;
             public bool check;
             public Receiver(TcpClient s)
            {
                comm = s;
            }

             public void procedure()/////////////////////////////////
             {
              
                         //authentication
                         Thread th_authen= new Thread(authenticate);
                         th_authen.Start();
                      //sign up
                     //check sign_up
                         // new Thread(() => { check = sign_up(); }).Start();
                         Console.WriteLine("Process 1");
                
                    while (true)
                    {
                       // Console.WriteLine(check);
                      //  Thread.Sleep(500);
                        if (check == true)//authentication passed
                        {
                             th_authen.Abort();
                             Console.WriteLine("Authen ended");
                             check = false;//checker reset
                                          //topic selection
                                          //new Thread(() => {(check = topic_selection()};).Start();

                            check = true;//test
                            Console.WriteLine("Process 2");
                            if (check == true)
                            {
                                Console.WriteLine("Process 3");
                                new Thread(doChat).Start();
                            check = false;
                            }


            }
        }
    }

    public bool sign_up()
    {

        return true;
    }

    public void authenticate()
        {
        Console.WriteLine("Authentication!!!!!!!!!!!!!!!!!!!!!!1");
        while (true)
        {
            Console.WriteLine("Start listening");
            Message msg_temp = (Message)Net.rcvMsg(comm.GetStream());


            Console.WriteLine("Access message received");

            bool checker1 = false;

            Console.WriteLine(msg_temp);
            Thread.Sleep(500);

            if (msg_temp.getType() == 1)
            {
                Access_message msg = (Access_message)msg_temp;
                Console.WriteLine("Access success 01");
                checker1 = true;
            }
            else if (msg_temp.getType() == 3)
            {
                Console.WriteLine("Skip login");
                check = true;
                return;
            }

            while (checker1)
            {

                bool authen = true;//test

                if (authen)//check list of authenticate()==true
                {
                    Net.sendMsg(comm.GetStream(), new Authentication_message(true));
                    check = true;
                    return;
                }
                else
                {
                    Net.sendMsg(comm.GetStream(), new Authentication_message(false));
                }

            }
        }
        }    

            public void doChat()//Chatting
            {
                StreamWriter outs = new StreamWriter(comm.GetStream());
                StreamReader ins = new StreamReader(comm.GetStream());

                //    read Message attributes
               // string str_message = ins.ReadBlock();
               // string chatter = ins.ReadString();
              //  string datetime = ins.ReadString();


                while (true)
                {
            //    read Message


                   Chat_message msg = (Chat_message)Net.rcvMsg(comm.GetStream());
                 
                    Console.WriteLine("Message received");
                    Console.WriteLine(msg);

                  foreach (TcpClient client in Server.Server.client_list) {
                      Net.sendMsg(client.GetStream(), msg);
                    }
                  //  Net.sendMsg(comm.GetStream(), msg);
                }
            }

            //public void doOperation()
            //{

            //    /*
            //    BinaryWriter outs = new BinaryWriter(comm.GetStream());
            //    BinaryReader ins = new BinaryReader(comm.GetStream());


            //    // read operation
            //    double op1 = ins.ReadDouble();
            //    double op2 = ins.ReadDouble();
            //    char op = ins.ReadChar();
            //    */

            //    Console.WriteLine("Computing operation");
            //    while (true)
            //    {
            //        // read expression
            //        Expr msg = (Expr)Net.rcvMsg(comm.GetStream());

            //        Console.WriteLine("expression received");
            //        // send result
            //        switch (msg.Op)
            //        {
            //            case '+':
            //                Net.sendMsg(comm.GetStream(), new Result(msg.Op1 + msg.Op2, false));
            //                break;

            //            case '-':
            //                Net.sendMsg(comm.GetStream(), new Result(msg.Op1 - msg.Op2, false));
            //                break;

            //            case '*':
            //                Net.sendMsg(comm.GetStream(), new Result(msg.Op1 * msg.Op2, false));
            //                break;

            //            case '/':
            //                if (msg.Op2 != 0.0)
            //                    Net.sendMsg(comm.GetStream(), new Result(msg.Op1 / msg.Op2, false));
            //                else
            //                    Net.sendMsg(comm.GetStream(), new Result(0, true));

            //                break;

            //        }

            //    }

            //}
        


    }



