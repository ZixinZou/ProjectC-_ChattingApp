using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Communication
{
    
    public interface Message
    {

        string ToString();
        int getType();//0 chat message, 1 access message,2 authentication message
    }



   [Serializable]
    public class Chat_message: Message
    {
       
         private  String continent;
        private String sender;
        private String str_datetime;

        public Chat_message()
        {
            continent = "";
            sender = "";
            str_datetime = "";
        }
        public Chat_message(String continent, string sender)
            {
                this.continent = continent;
                this.sender = sender;
                DateTime datetime = System.DateTime.Now;
            str_datetime = datetime.ToString();
        }

            public override string ToString()
            {
                return sender + " - " + str_datetime + ":\r\n" + continent + "\r\n";
            }

        public int getType()
        {
            return 0;
        }

  


    }

    [Serializable]
    public class Access_message : Message
    {
        private string alias;
        private string password;
        public Access_message(string alias, string password)
        {
            this.alias = alias;
            this.password = password;
        }

        public int getType()
        {
            return 1;
        }

        public override string ToString()
        {
            return "Alias :\""+alias+"\" Password:\""+password+"\" \n";
        }

    }
    [Serializable]
    public class Authentication_message : Message
    {
        public Boolean authentication=false;

        public Authentication_message(Boolean authen)
        {
            authentication = authen;
        }
        public bool getResult()
        {
            return authentication;
        }

        public int getType()
        {
            return 2;
        }

        public override string ToString()
        {
            if (authentication == true)
            { return "GOOD\n"; }
            else
                return "NO GOOD\n";
        }
    }
    [Serializable]
    public class Skip_login__message : Message
    {
        public Boolean skip=true;
        public Skip_login__message(Boolean s)
        {
            skip = s;
        }

        public int getType()
        {
            return 3;
        }
        public override string ToString()
        {
            return null;
        }
    }
    /*
    [Serializable]
    public class Expr : Message
    {
        private double op1, op2;
        private char op;

        public Expr(double op1, double op2, char op)
        {
            this.op1 = op1;
            this.op2 = op2;
            this.op = op;
        }


        public double Op1
        {
            get { return op1; }
        }

        public double Op2
        {
            get { return op2; }
        }

        public char Op
        {
            get { return op; }
        }

        public override string ToString()
        {
            return op1 + " " + op + " " + op2;
        }

    }

    [Serializable]
    public class Result : Message
    {
        private double val;
        private bool error;

        public Result(double val, bool err)
        {
            this.val = val;
            error = err;
        }

        public double Val
        {
            get { return val; }
        }

        public bool Error
        {
            get { return error; }
        }

        public override string ToString()
        {
            return val + " ";
        }

    }*/
}
