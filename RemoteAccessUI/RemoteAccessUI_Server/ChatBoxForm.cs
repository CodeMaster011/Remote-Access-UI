using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RAT.Communicate;
namespace RemoteAccessUI_Server
{
    public partial class ChatBoxForm : Form
    {
        public ChatBoxForm()
        {
            InitializeComponent();
        }
        public RServer client = null;
        public string connectedIp = null;
        private string nickName = null;
        private void ChatBoxForm_Load(object sender, EventArgs e)
        {
            nickName = MyGlobal.ipToNickName(connectedIp);
            Text = $"Chat Box - Chatting with {nickName}-[{connectedIp}]";
        }
        public void newMessage(string msg)
        {
            ListViewItem liv = new ListViewItem($"{nickName} [{connectedIp}]");
            liv.SubItems.Add(msg);
            listView1.Items.Add(liv);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.Stream.WriteString("CHAT_MESSAGE:"+textBox1.Text);

            ListViewItem liv = new ListViewItem($"{MyGlobal.ipToNickName(MyGlobal.fileManagement.fileData.myIpAddress)} [{MyGlobal.fileManagement.fileData.myIpAddress}]");
            liv.SubItems.Add(textBox1.Text);
            listView1.Items.Add(liv);

            textBox1.Text = "";
            textBox1.Focus();
        }

        private void ChatBoxForm_FormClossing(object sender, FormClosingEventArgs e)
        {
            try
            {
                client.Stream.WriteString("CHAT_STOP");
            }
            catch (Exception ex)
            {
            }
            
        }
    }
}
