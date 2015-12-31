using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace RemoteAccessUI_Client
{
    public partial class ProgressBarEx : ProgressBar
    {
        private bool animation = false;
        public bool Animation
        {
            get { return animation; }
            set { animation = value; manageAnimation(); }
        }        
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, uint wPar, uint lPar);
        private const int WM_USER = 0x400;
        private const int PBM_SETSTATE = 16;

        private const int PBST_NORMAL = 0x0001;
        private const int PBST_ERROR = 0x0002;
        private const int PBST_PAUSED = 0x0003;        
        public void manageAnimation()
        {
            if (animation)
            {
                //STRAT ANIMATION
            }
            else
            {
                //STOP ANIMATION
                SendMessage(Handle, WM_USER + PBM_SETSTATE, PBST_PAUSED, 0);
                //SendMessage(Handle, WM_USER + PBM_SETSTATE, PBST_ERROR, 0);
            }
        }

        public ProgressBarEx()
        {
            InitializeComponent();
        }

        public ProgressBarEx(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
