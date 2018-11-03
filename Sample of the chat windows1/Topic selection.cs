using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample_of_the_chat_windows
{
    public partial class Topic_selection : Form
    {
        public Topic_selection()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //select and join topic
            /*
             * for(int i=0;i<checkedListBox1.Items.Count;i++)
             * {
             *  if(checkedListBox1.GetItemChecked(i))
             *  {
             *     // MessageBox.Show(checkedListBox1.GetItemText(checkedListBox1,Items[i]));
             *  }
             * }
             */
            ChatRoom chatroom = new ChatRoom();
            this.Close();
            chatroom.Show();
        }

        private void Topic_selection_Load(object sender, EventArgs e)
        {
            Chatter.chatter_myself = new Chatter(Program.myself, "Klein", "990344");

            //loading the list of chatroom
            //checkedListBox1.Items.add("....")
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //creat and join a topic
            ChatRoom chatroom = new ChatRoom();
            this.Close();
            chatroom.Show();
        }
    }
}
