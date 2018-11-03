using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Threading;

namespace Communication
{
    
    public class Net
    {
        static Semaphore sem = new Semaphore(3, 100);
        public static void sendMsg(Stream s, Message msg)//send message
        {

            SoapFormatter soapf = new SoapFormatter();
            soapf.Serialize(s, msg);

        }

        public static Message rcvMsg(Stream s)//receive message
        {

            sem.WaitOne();
             SoapFormatter soapf = new SoapFormatter();

            Message msg= (Message)soapf.Deserialize(s);
            sem.Release();
            return msg;

        }


    }
}
