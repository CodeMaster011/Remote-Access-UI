using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RemoteAccessUI_Client
{
    public partial class ProgEx : UserControl
    {
        public int Maximum { get; set; }
        public int Minimum { get; set; }

        private int v = 0;
        public int Value { get { return v; } set { v = value; paintBar(); } }
        public ProgEx()
        {
            Maximum = 100;
            InitializeComponent();
        }

        private void ProgEx_Load(object sender, EventArgs e)
        {

        }
        private Rectangle fullRect = new Rectangle();
        private Rectangle drawingRect = new Rectangle();
        private void paintBar()
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            fullRect.X = 0; fullRect.Y = 0;
            fullRect.Width = Width; fullRect.Height = Height;
            paintBar(g,fullRect);

            g.Dispose();
        }
        private void paintBar(Graphics g, Rectangle clipRect)
        {            
            Brush b = Brushes.Green;
            int pWidth = (Width / Maximum) * Value;

            drawingRect.X = 0; drawingRect.Y = 0;
            drawingRect.Width = pWidth; drawingRect.Height = Height;

            g.Clear(BackColor);
            g.FillRectangle(b, drawingRect);

            g.DrawRectangle(new Pen(Brushes.Red), clipRect);

        }

        private void ProgEx_Paint(object sender, PaintEventArgs e)
        {
            paintBar(e.Graphics,e.ClipRectangle);
            
        }

        private void ProgEx_BackgroundColorChanged(object sender, EventArgs e)
        {
            paintBar();
        }
    }
}
