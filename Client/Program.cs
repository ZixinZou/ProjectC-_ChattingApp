using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c1 = new Client("127.0.0.1", 8999);
            c1.start();
        }
    }
}
