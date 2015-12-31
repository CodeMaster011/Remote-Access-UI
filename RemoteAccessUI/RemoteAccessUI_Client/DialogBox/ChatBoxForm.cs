using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RAT.Communicate;
namespace RemoteAccessUI_Client
{
    public partial class ChatBoxForm : Form
    {
        public ChatBoxForm()
        {
            InitializeComponent();
        }
        public NetworkServer server;
        public delegate void UpdateData();
        private void ChatBoxForm_Load(object sender, EventArgs e)
        {
            Text = $"Chat Box - Chatting with {server.nickName}-[{server.serverPort.ServerIP}:{server.serverPort.ServerPort}]";
            server.serverPort.Stream.WriteString("CHAT_START:" + MyGlobal.fileManagement.fileData.myIpAddress);
        }

        private void ChatBoxForm_Shown(object _sender, EventArgs e)
        {
            server.serverPort.removeAllDataReceivedCallback();            
            server.serverPort.setOnDataReceivedCallback(new RServer.DataReceived(
                (RServer sender, CommunicationNetworkStream stream, string Data)=> {
                    //EXTENDED MODE
                    int len = Data.IndexOf(':');
                    string command = Data;
                    if (len > 0) command = Data.Substring(0, len);
                    string arg = "";
                    if (len > 0) arg = Data.Substring(len + 1);
                    switch (command)
                    {
                        case "CHAT_STOP":
                            Invoke(new UpdateData(() => {                            
                            try
                            {
                                    NetworkServer.closeConnection(sender);
                            }
                            catch (Exception){ }
                            Close(); Dispose();
                            }));
                            break;
                        case "CHAT_MESSAGE":
                            Invoke(new UpdateData(() => {
                                newMessage(arg);
                            }));
                            break;
                        default:
                            break;
                    }
                }));
        }
        public void newMessage(string msg)
        {
            ListViewItem liv = new ListViewItem($"{server.nickName} [{server.serverPort.ServerIP}]");
            liv.SubItems.Add(msg);
            listView1.Items.Add(liv);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server.serverPort.Stream.WriteString("CHAT_MESSAGE:" + textBox1.Text);

            ListViewItem liv = new ListViewItem($"{MyGlobal.ipToNickName(MyGlobal.fileManagement.fileData.myIpAddress)} [{MyGlobal.fileManagement.fileData.myIpAddress}]");
            liv.SubItems.Add(textBox1.Text);
            listView1.Items.Add(liv);

            textBox1.Text = "";
            textBox1.Focus();
        }

        private void ChatBoxForm_FormClosing(object sender, FormClosingEventArgs e)
        {            
            try
            {
                server.serverPort.Stream.WriteString("CHAT_STOP");
                NetworkServer.closeConnection(server.serverPort);
            }
            catch (Exception) { }
            
        }
    }
}
