using RAT.Communicate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static RemoteAccessUI_Client.MyGlobal;

namespace RemoteAccessUI_Client
{
    public partial class Form1 : Form
    {
        private delegate void UpdateData();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            fileManagement = new FileManagement();
            fileManagement.read();

            if(!DB.isLoaded)
                DB.loadDatabase();      //DATABASE
            DB.isLoaded = true;

            renderListViewItems();
        }
        private void renderListViewItems()
        {
            listView1.Items.Clear();
            foreach (string item in fileManagement.fileData.availableIp)
            {
                string[] pp = item.Split('=');
                ListViewItem lv = new ListViewItem(pp[0]);
                lv.SubItems.Add(pp[1]);
                listView1.Items.Add(lv);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {                
                NetworkServer.requestNewConnectionToOpenPort(listView1.SelectedItems[0].SubItems[1].Text,
                    new NetworkServer.NewConnectionEstablished(
                        (NetworkServer newServer, CommunicationNetworkStream stream) => {
                            exploreForm f = new exploreForm();
                            f.server = newServer;
                            Invoke(new UpdateData(() => { f.Show(); Close(); Dispose(); }));
                        }
                        ),
                    new NetworkServer.ErrorEncounted(
                        (RServer newServer, CommunicationNetworkStream stream,string data) => {
                            MessageBox.Show("Server is flooded with connection. Try again later.", "Error");
                        }
                        )
                    );

            }
            else
                MessageBox.Show("Please select an IP", "Error");
        }

        private void Form1_Clossing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count == 1)
                Application.Exit();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            renderListViewItems();
            listView1.Focus();
        }
    }
}
