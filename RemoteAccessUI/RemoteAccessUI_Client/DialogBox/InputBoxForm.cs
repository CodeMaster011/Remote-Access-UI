using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RemoteAccessUI_Client.DialogBox
{
    public partial class InputBoxForm : Form
    {
        public string Response { get; set; }
        private string text, title;
        public InputBoxForm()
        {
            InitializeComponent();
        }

        private void InputBoxForm_Load(object sender, EventArgs e)
        {
            
        }

        private void InputBoxForm_Shown(object sender, EventArgs e)
        {
            textBox1.Text = Response;
            label1.Text = text;
            Text = title;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Response = textBox1.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public void initiateText(string text, string title) { this.text = text; this.title = title; }
    }
}
