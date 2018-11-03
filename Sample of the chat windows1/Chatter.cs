using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_of_the_chat_windows
{
    [Serializable]
    class Chatter 
    {
        public string alias;
        private string password;
        [NonSerialized]
        static public Chatter chatter_myself;
         public Client myself;
        public Chatter(Client client,string alias,string password) 
        {
            this.alias = alias;
            this.password = password;
            this.myself = client;
        }
    }
}
