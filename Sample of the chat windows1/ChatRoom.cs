using Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sample_of_the_chat_windows
{
    delegate void AddTextCallback(Chat_message chat_message);
    public partial class ChatRoom : Form
    {
        public ChatRoom()
        {
            InitializeComponent();
        }

        private void ChatRoom_Load(object sender, EventArgs e)
        {
            //user access
            //add user to listbox
            //change the chat room name
            // Client c1 = new Client("127.0.0.1", 8999);

            // c1.start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str_message;

            str_message = textBox3.Text;

            //Message message(who,str_message,when);

            Net.sendMsg(Program.myself.comm.GetStream(), new Chat_message(str_message, Chatter.chatter_myself.alias));
            textBox3.Text = null;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void ChatRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("The chat room is closing do you want to continue?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                //delete user from listbox
                //disconnect from the server
                e.Cancel = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChatRoom_Enter(object sender, EventArgs e)
        {
            textBox1.Text += "Start: \n";

        }

        private void textBox1_Validated(object sender, EventArgs e)
        {

            new Thread(() => 
            { 
            while (true)
                { 
                      this.addText((Chat_message)Net.rcvMsg(Chatter.chatter_myself.myself.comm.GetStream()));
                    Thread.Sleep(2000);
                }
                 }).Start();
        }

        private void addText(Chat_message chat_message)
        {
            if(this.textBox1.InvokeRequired)
            {
                AddTextCallback d = new AddTextCallback(addText);
                this.Invoke(d, new object[] { chat_message });
            }
            else { this.textBox1.Text += chat_message; }
        }

    }
}
