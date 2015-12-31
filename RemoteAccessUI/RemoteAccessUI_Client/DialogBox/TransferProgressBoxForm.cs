using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RemoteAccessUI_Client.DialogBox
{
    public partial class TransferProgressBoxForm : Form
    {
        public TransferProgressBoxForm()
        {
            InitializeComponent();
        }

        private void TransferProgressBoxForm_Load(object sender, EventArgs e)
        {
            detailsListView.Visible = false;
            this.Size = new Size(513, 161);
            label2.Text = $"Copying {TotalNumberOfItems} items from {MyGlobal.ipToNickName(senderIP)}[{senderIP}] to {MyGlobal.ipToNickName(receiverIP)}[{receiverIP}]";
            detailsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        public int TotalNumberOfItems = 0;
        public string senderIP = "";
        public string receiverIP = "";
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (label4.Text == "More details") {
                label4.Text = "Fewer details";
                //Size = new Size(513, 307);
                animateSizeChange(this, Size, new Size(513, 307), 10, new OnAnimationOver(() => {
                    detailsListView.Visible = true;
                }));                
            }

            else if (label4.Text == "Fewer details")
            {
                label4.Text = "More details";
                //Size = new Size(513, 161);
                animateSizeChange(this, Size, new Size(513, 161), 10,new OnAnimationOver(()=> {
                    detailsListView.Visible = false;
                }));

            }
        }
        private delegate void OnAnimationOver();
        private void animateSizeChange(Control control, Size initialSize, Size eventualSize, int animationDuration, OnAnimationOver onAnimationOverCallback)
        {
            //WIDTH
            int incrementWidth = eventualSize.Width - initialSize.Width;
            int rateOfWidthIncrementPms = (int)(incrementWidth / animationDuration);
            //HEIGHT
            int incrementHeight = eventualSize.Height - initialSize.Height;            
            int rateOfHeightIncrementPms = (int)(incrementHeight / animationDuration);
            

            Timer t = new Timer();
            t.Interval = 1;
            t.Tick += new EventHandler((object sender,EventArgs e)=> {
                control.Height += rateOfHeightIncrementPms;
                control.Width += rateOfWidthIncrementPms;
                //ANIMATION DONE
                if (rateOfHeightIncrementPms >= 0)
                    if (control.Width >= eventualSize.Width && control.Height >= eventualSize.Height)
                    {
                        control.Size = eventualSize;
                        t.Stop();
                        try
                        {
                            onAnimationOverCallback();
                        }
                        catch (Exception) { }
                    } 
                if (rateOfHeightIncrementPms < 0)
                    if (eventualSize.Width >= control.Width && eventualSize.Height >= control.Height)
                    {
                        control.Size = eventualSize;
                        t.Stop();
                        try
                        {
                            onAnimationOverCallback();
                        }
                        catch (Exception) { }
                    }
            });
            t.Start();
        }

        public void addListViewItems(ListViewItem liv)
        {
            detailsListView.Items.Add(liv);
        }

        public void progressNotification(int progressValue)
        {
            label3.Text = $"{progressValue.ToString("00")}% completed";
            Text = label3.Text;
            progressBar1.Value = progressValue;
        }
        public void singleItemCompletion(ListViewItem item)
        {
            if (item.ImageKey != "done")
                 item.ImageKey = "done";
        }
        public void singleItemStarting(ListViewItem item)
        {               
            if(item.ImageKey!= "working")
                item.ImageKey = "working";
        }
    }
}
