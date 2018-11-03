using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Communication;
namespace Sample_of_the_chat_windows
{
    public partial class Log_in : Form
    {
        public Log_in()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str_username = textBox1.Text;
            String str_password = textBox2.Text;

            bool check = false;
            while (check)
            {
                Net.sendMsg(Program.myself.comm.GetStream(), new Access_message(str_username, str_password));
               

                Authentication_message aumsg = (Authentication_message)Net.rcvMsg(Program.myself.comm.GetStream());
               if (check== aumsg.authentication)
                {
                    Chatter.chatter_myself = new Chatter(Program.myself, str_username, str_password);
                    Topic_selection topicselection = new Topic_selection();
                    this.Close();
                    topicselection.Show();
                }
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
                Net.sendMsg(Program.myself.comm.GetStream(), new Skip_login__message(true));
                this.Hide();
                Sign_up signup = new Sign_up();
                signup.Show();
        }

        private void Log_in_Load(object sender, EventArgs e)
        {
            Program.myself = new Client("127.0.0.66", 8999);
            Program.myself.connect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Net.sendMsg(Program.myself.comm.GetStream(), new Chat_message("HAHAHA", "HAHAHA"));
        }
    }
}
