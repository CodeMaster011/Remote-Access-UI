namespace RemoteAccessUI_Client
{
    partial class ProgEx
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ProgEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ProgEx";
            this.Load += new System.EventHandler(this.ProgEx_Load);
            this.BackColorChanged += new System.EventHandler(this.ProgEx_BackgroundColorChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ProgEx_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
