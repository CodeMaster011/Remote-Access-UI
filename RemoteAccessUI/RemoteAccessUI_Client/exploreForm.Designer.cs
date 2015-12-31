namespace RemoteAccessUI_Client
{
    partial class exploreForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(exploreForm));
            this.contentView = new System.Windows.Forms.ListView();
            this.contentViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInOtherDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWithNewConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.viewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.sentToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driveImageList = new System.Windows.Forms.ImageList(this.components);
            this.addressBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cleanCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exchangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sentFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sentDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.explorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.transferProgressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.processViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dirFileImageList = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.explorerPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.transferPanel = new System.Windows.Forms.Panel();
            this.transferContentView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.chatBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentViewContextMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.explorerPanel.SuspendLayout();
            this.transferPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentView
            // 
            this.contentView.AllowDrop = true;
            this.contentView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentView.ContextMenuStrip = this.contentViewContextMenu;
            this.contentView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.contentView.LargeImageList = this.driveImageList;
            this.contentView.Location = new System.Drawing.Point(12, 69);
            this.contentView.Name = "contentView";
            this.contentView.Size = new System.Drawing.Size(239, 9);
            this.contentView.TabIndex = 0;
            this.contentView.UseCompatibleStateImageBehavior = false;
            this.contentView.View = System.Windows.Forms.View.Tile;
            this.contentView.DragDrop += new System.Windows.Forms.DragEventHandler(this.contentView_DragDrop);
            this.contentView.DragEnter += new System.Windows.Forms.DragEventHandler(this.contentView_DragEnter);
            this.contentView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.contentView_MouseDoubleClick);
            // 
            // contentViewContextMenu
            // 
            this.contentViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openInOtherDeviceToolStripMenuItem,
            this.openWithNewConnectionToolStripMenuItem,
            this.toolStripSeparator10,
            this.viewToolStripMenuItem1,
            this.refreshToolStripMenuItem,
            this.toolStripSeparator5,
            this.downloadToolStripMenuItem,
            this.toolStripSeparator7,
            this.sentToToolStripMenuItem,
            this.toolStripSeparator6,
            this.newToolStripMenuItem,
            this.toolStripSeparator9,
            this.deleteToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.toolStripSeparator8,
            this.propertiesToolStripMenuItem});
            this.contentViewContextMenu.Name = "contentViewContextMenu";
            this.contentViewContextMenu.Size = new System.Drawing.Size(222, 282);
            this.contentViewContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contentViewContextMenu_Opening);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openInOtherDeviceToolStripMenuItem
            // 
            this.openInOtherDeviceToolStripMenuItem.Name = "openInOtherDeviceToolStripMenuItem";
            this.openInOtherDeviceToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.openInOtherDeviceToolStripMenuItem.Text = "Open in Other Device";
            this.openInOtherDeviceToolStripMenuItem.Click += new System.EventHandler(this.openInOtherDeviceToolStripMenuItem_Click);
            // 
            // openWithNewConnectionToolStripMenuItem
            // 
            this.openWithNewConnectionToolStripMenuItem.Name = "openWithNewConnectionToolStripMenuItem";
            this.openWithNewConnectionToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.openWithNewConnectionToolStripMenuItem.Text = "Open with New Connection";
            this.openWithNewConnectionToolStripMenuItem.Click += new System.EventHandler(this.openWithNewConnectionToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(218, 6);
            // 
            // viewToolStripMenuItem1
            // 
            this.viewToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeIconToolStripMenuItem,
            this.tileToolStripMenuItem,
            this.detailsToolStripMenuItem,
            this.smallIconToolStripMenuItem});
            this.viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
            this.viewToolStripMenuItem1.Size = new System.Drawing.Size(221, 22);
            this.viewToolStripMenuItem1.Text = "View";
            // 
            // largeIconToolStripMenuItem
            // 
            this.largeIconToolStripMenuItem.Name = "largeIconToolStripMenuItem";
            this.largeIconToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.largeIconToolStripMenuItem.Text = "Large Icon";
            this.largeIconToolStripMenuItem.Click += new System.EventHandler(this.largeIconToolStripMenuItem_Click);
            // 
            // tileToolStripMenuItem
            // 
            this.tileToolStripMenuItem.Name = "tileToolStripMenuItem";
            this.tileToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.tileToolStripMenuItem.Text = "Tile";
            this.tileToolStripMenuItem.Click += new System.EventHandler(this.tileToolStripMenuItem_Click);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.detailsToolStripMenuItem.Text = "Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // smallIconToolStripMenuItem
            // 
            this.smallIconToolStripMenuItem.Name = "smallIconToolStripMenuItem";
            this.smallIconToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.smallIconToolStripMenuItem.Text = "Small Icon";
            this.smallIconToolStripMenuItem.Click += new System.EventHandler(this.smallIconToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(218, 6);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(218, 6);
            // 
            // sentToToolStripMenuItem
            // 
            this.sentToToolStripMenuItem.Name = "sentToToolStripMenuItem";
            this.sentToToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.sentToToolStripMenuItem.Text = "Sent to";
            this.sentToToolStripMenuItem.Click += new System.EventHandler(this.sentToToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(218, 6);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.folderToolStripMenuItem.Text = "Folder";
            this.folderToolStripMenuItem.Click += new System.EventHandler(this.folderToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(218, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(218, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // driveImageList
            // 
            this.driveImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("driveImageList.ImageStream")));
            this.driveImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.driveImageList.Images.SetKeyName(0, "drive_internal.png");
            this.driveImageList.Images.SetKeyName(1, "drive_cd.png");
            this.driveImageList.Images.SetKeyName(2, "drive_usb.png");
            this.driveImageList.Images.SetKeyName(3, "drive_unknown.png");
            // 
            // addressBox
            // 
            this.addressBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressBox.Location = new System.Drawing.Point(136, 22);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(60, 31);
            this.addressBox.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exchangeToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(952, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newConnectionToolStripMenuItem,
            this.closeConnectionToolStripMenuItem,
            this.toolStripSeparator1,
            this.cleanCacheToolStripMenuItem,
            this.toolStripSeparator11,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newConnectionToolStripMenuItem
            // 
            this.newConnectionToolStripMenuItem.Image = global::RemoteAccessUI_Client.Properties.Resources.Plus_icon__1_;
            this.newConnectionToolStripMenuItem.Name = "newConnectionToolStripMenuItem";
            this.newConnectionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.newConnectionToolStripMenuItem.Text = "New Connection";
            this.newConnectionToolStripMenuItem.Click += new System.EventHandler(this.newConnectionToolStripMenuItem_Click);
            // 
            // closeConnectionToolStripMenuItem
            // 
            this.closeConnectionToolStripMenuItem.Name = "closeConnectionToolStripMenuItem";
            this.closeConnectionToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.closeConnectionToolStripMenuItem.Text = "Close Connection";
            this.closeConnectionToolStripMenuItem.Click += new System.EventHandler(this.closeConnectionToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // cleanCacheToolStripMenuItem
            // 
            this.cleanCacheToolStripMenuItem.Name = "cleanCacheToolStripMenuItem";
            this.cleanCacheToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.cleanCacheToolStripMenuItem.Text = "Clean Cache";
            this.cleanCacheToolStripMenuItem.Click += new System.EventHandler(this.cleanCacheToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(165, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // exchangeToolStripMenuItem
            // 
            this.exchangeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sentFileToolStripMenuItem,
            this.downloadFileToolStripMenuItem,
            this.toolStripSeparator2,
            this.sentDirectoryToolStripMenuItem,
            this.downloadDirectoryToolStripMenuItem});
            this.exchangeToolStripMenuItem.Name = "exchangeToolStripMenuItem";
            this.exchangeToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.exchangeToolStripMenuItem.Text = "Exchange";
            // 
            // sentFileToolStripMenuItem
            // 
            this.sentFileToolStripMenuItem.Name = "sentFileToolStripMenuItem";
            this.sentFileToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.sentFileToolStripMenuItem.Text = "Sent File";
            this.sentFileToolStripMenuItem.Click += new System.EventHandler(this.sentFileToolStripMenuItem_Click);
            // 
            // downloadFileToolStripMenuItem
            // 
            this.downloadFileToolStripMenuItem.Name = "downloadFileToolStripMenuItem";
            this.downloadFileToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.downloadFileToolStripMenuItem.Text = "Download File";
            this.downloadFileToolStripMenuItem.Click += new System.EventHandler(this.downloadFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(176, 6);
            // 
            // sentDirectoryToolStripMenuItem
            // 
            this.sentDirectoryToolStripMenuItem.Name = "sentDirectoryToolStripMenuItem";
            this.sentDirectoryToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.sentDirectoryToolStripMenuItem.Text = "Sent Directory";
            this.sentDirectoryToolStripMenuItem.Click += new System.EventHandler(this.sentDirectoryToolStripMenuItem_Click);
            // 
            // downloadDirectoryToolStripMenuItem
            // 
            this.downloadDirectoryToolStripMenuItem.Name = "downloadDirectoryToolStripMenuItem";
            this.downloadDirectoryToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.downloadDirectoryToolStripMenuItem.Text = "Download Directory";
            this.downloadDirectoryToolStripMenuItem.Click += new System.EventHandler(this.downloadDirectoryToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.explorerToolStripMenuItem,
            this.toolStripSeparator3,
            this.transferProgressToolStripMenuItem,
            this.toolStripSeparator4,
            this.processViewToolStripMenuItem,
            this.toolStripSeparator12,
            this.chatBoxToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // explorerToolStripMenuItem
            // 
            this.explorerToolStripMenuItem.Checked = true;
            this.explorerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.explorerToolStripMenuItem.Name = "explorerToolStripMenuItem";
            this.explorerToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.explorerToolStripMenuItem.Text = "Explorer";
            this.explorerToolStripMenuItem.Click += new System.EventHandler(this.explorerToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(161, 6);
            // 
            // transferProgressToolStripMenuItem
            // 
            this.transferProgressToolStripMenuItem.Name = "transferProgressToolStripMenuItem";
            this.transferProgressToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.transferProgressToolStripMenuItem.Text = "Transfer Progress";
            this.transferProgressToolStripMenuItem.Click += new System.EventHandler(this.transferProgressToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(161, 6);
            // 
            // processViewToolStripMenuItem
            // 
            this.processViewToolStripMenuItem.Name = "processViewToolStripMenuItem";
            this.processViewToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.processViewToolStripMenuItem.Text = "Process View";
            this.processViewToolStripMenuItem.Click += new System.EventHandler(this.processViewToolStripMenuItem_Click);
            // 
            // dirFileImageList
            // 
            this.dirFileImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("dirFileImageList.ImageStream")));
            this.dirFileImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.dirFileImageList.Images.SetKeyName(0, "|max.folder");
            this.dirFileImageList.Images.SetKeyName(1, "|system volume information");
            this.dirFileImageList.Images.SetKeyName(2, "|$recycle.bin");
            this.dirFileImageList.Images.SetKeyName(3, "|windows");
            this.dirFileImageList.Images.SetKeyName(4, ">max.file.unknown");
            this.dirFileImageList.Images.SetKeyName(5, ">.torrent");
            this.dirFileImageList.Images.SetKeyName(6, ">.txt");
            this.dirFileImageList.Images.SetKeyName(7, ">.doc");
            this.dirFileImageList.Images.SetKeyName(8, ">.docx");
            this.dirFileImageList.Images.SetKeyName(9, ">.mp3");
            this.dirFileImageList.Images.SetKeyName(10, ">.pdf");
            this.dirFileImageList.Images.SetKeyName(11, ">.ppt");
            this.dirFileImageList.Images.SetKeyName(12, ">.rtf");
            this.dirFileImageList.Images.SetKeyName(13, ">.xls");
            this.dirFileImageList.Images.SetKeyName(14, ">.xlsx");
            this.dirFileImageList.Images.SetKeyName(15, ">.avi");
            this.dirFileImageList.Images.SetKeyName(16, ">.swf");
            this.dirFileImageList.Images.SetKeyName(17, ">.mkv");
            this.dirFileImageList.Images.SetKeyName(18, ">.mp4");
            this.dirFileImageList.Images.SetKeyName(19, ">.mov");
            this.dirFileImageList.Images.SetKeyName(20, ">.mpg");
            this.dirFileImageList.Images.SetKeyName(21, ">.flv");
            this.dirFileImageList.Images.SetKeyName(22, ">.mpeg");
            this.dirFileImageList.Images.SetKeyName(23, ">.svg");
            this.dirFileImageList.Images.SetKeyName(24, ">.gif");
            this.dirFileImageList.Images.SetKeyName(25, ">.bmp");
            this.dirFileImageList.Images.SetKeyName(26, ">.png");
            this.dirFileImageList.Images.SetKeyName(27, ">.jpg");
            this.dirFileImageList.Images.SetKeyName(28, ">.jpeg");
            this.dirFileImageList.Images.SetKeyName(29, ">.indd");
            this.dirFileImageList.Images.SetKeyName(30, ">.ppj");
            this.dirFileImageList.Images.SetKeyName(31, ">.psd");
            this.dirFileImageList.Images.SetKeyName(32, ">.xml");
            this.dirFileImageList.Images.SetKeyName(33, ">.php");
            this.dirFileImageList.Images.SetKeyName(34, ">.html");
            this.dirFileImageList.Images.SetKeyName(35, ">.css");
            this.dirFileImageList.Images.SetKeyName(36, ">.asp");
            this.dirFileImageList.Images.SetKeyName(37, ">.cs");
            this.dirFileImageList.Images.SetKeyName(38, ">.sql");
            this.dirFileImageList.Images.SetKeyName(39, ">.accdb");
            this.dirFileImageList.Images.SetKeyName(40, ">.xhtml");
            this.dirFileImageList.Images.SetKeyName(41, ">.h");
            this.dirFileImageList.Images.SetKeyName(42, ">.cpl");
            this.dirFileImageList.Images.SetKeyName(43, ">.cpp");
            this.dirFileImageList.Images.SetKeyName(44, ">.crx");
            this.dirFileImageList.Images.SetKeyName(45, ">.crdownload");
            this.dirFileImageList.Images.SetKeyName(46, ">.obj");
            this.dirFileImageList.Images.SetKeyName(47, ">.m4v");
            this.dirFileImageList.Images.SetKeyName(48, ">.bak");
            this.dirFileImageList.Images.SetKeyName(49, ">.dat");
            this.dirFileImageList.Images.SetKeyName(50, ">.tmp");
            this.dirFileImageList.Images.SetKeyName(51, ">.class");
            this.dirFileImageList.Images.SetKeyName(52, ">.prf");
            this.dirFileImageList.Images.SetKeyName(53, ">.mdb");
            this.dirFileImageList.Images.SetKeyName(54, ">.pdb");
            this.dirFileImageList.Images.SetKeyName(55, ">.vcxproj");
            this.dirFileImageList.Images.SetKeyName(56, ">.java");
            this.dirFileImageList.Images.SetKeyName(57, ">.tga");
            this.dirFileImageList.Images.SetKeyName(58, ">.gz");
            this.dirFileImageList.Images.SetKeyName(59, ">.cue");
            this.dirFileImageList.Images.SetKeyName(60, ">.thm");
            this.dirFileImageList.Images.SetKeyName(61, ">.3dm");
            this.dirFileImageList.Images.SetKeyName(62, ">.gpx");
            this.dirFileImageList.Images.SetKeyName(63, ">.key");
            this.dirFileImageList.Images.SetKeyName(64, ">.cur");
            this.dirFileImageList.Images.SetKeyName(65, ">.odt");
            this.dirFileImageList.Images.SetKeyName(66, ">.c");
            this.dirFileImageList.Images.SetKeyName(67, ">.pages");
            this.dirFileImageList.Images.SetKeyName(68, ">.vb");
            this.dirFileImageList.Images.SetKeyName(69, ">.xcodeproj");
            this.dirFileImageList.Images.SetKeyName(70, ">.gadget");
            this.dirFileImageList.Images.SetKeyName(71, ">.jsp");
            this.dirFileImageList.Images.SetKeyName(72, ">.ico");
            this.dirFileImageList.Images.SetKeyName(73, ">.js");
            this.dirFileImageList.Images.SetKeyName(74, ">.db");
            this.dirFileImageList.Images.SetKeyName(75, ">.sys");
            this.dirFileImageList.Images.SetKeyName(76, ">.dll");
            this.dirFileImageList.Images.SetKeyName(77, ">.apk");
            this.dirFileImageList.Images.SetKeyName(78, ">.exe");
            this.dirFileImageList.Images.SetKeyName(79, ">.jar");
            this.dirFileImageList.Images.SetKeyName(80, ">.iso");
            this.dirFileImageList.Images.SetKeyName(81, ">.ini");
            this.dirFileImageList.Images.SetKeyName(82, ">.dat");
            this.dirFileImageList.Images.SetKeyName(83, ">.rar");
            this.dirFileImageList.Images.SetKeyName(84, ">.zip");
            this.dirFileImageList.Images.SetKeyName(85, ">.zipx");
            this.dirFileImageList.Images.SetKeyName(86, ">.7z");
            this.dirFileImageList.Images.SetKeyName(87, ">.cab");
            this.dirFileImageList.Images.SetKeyName(88, "|users");
            this.dirFileImageList.Images.SetKeyName(89, "|program files");
            this.dirFileImageList.Images.SetKeyName(90, "|program files (x86)");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // explorerPanel
            // 
            this.explorerPanel.AllowDrop = true;
            this.explorerPanel.Controls.Add(this.button1);
            this.explorerPanel.Controls.Add(this.contentView);
            this.explorerPanel.Controls.Add(this.refreshButton);
            this.explorerPanel.Controls.Add(this.backButton);
            this.explorerPanel.Controls.Add(this.addressBox);
            this.explorerPanel.Location = new System.Drawing.Point(26, 260);
            this.explorerPanel.Name = "explorerPanel";
            this.explorerPanel.Size = new System.Drawing.Size(263, 90);
            this.explorerPanel.TabIndex = 5;
            this.explorerPanel.Visible = false;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::RemoteAccessUI_Client.Properties.Resources.free_31_48;
            this.button1.Location = new System.Drawing.Point(82, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 48);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.FlatAppearance.BorderSize = 0;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Image = global::RemoteAccessUI_Client.Properties.Resources.refresh_48;
            this.refreshButton.Location = new System.Drawing.Point(202, 11);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(48, 48);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "R";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // backButton
            // 
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Image = global::RemoteAccessUI_Client.Properties.Resources.free_31_64;
            this.backButton.Location = new System.Drawing.Point(12, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(64, 64);
            this.backButton.TabIndex = 4;
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // transferPanel
            // 
            this.transferPanel.Controls.Add(this.transferContentView);
            this.transferPanel.Location = new System.Drawing.Point(43, 135);
            this.transferPanel.Name = "transferPanel";
            this.transferPanel.Size = new System.Drawing.Size(550, 55);
            this.transferPanel.TabIndex = 6;
            this.transferPanel.Visible = false;
            // 
            // transferContentView
            // 
            this.transferContentView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader4});
            this.transferContentView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transferContentView.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transferContentView.FullRowSelect = true;
            this.transferContentView.GridLines = true;
            this.transferContentView.Location = new System.Drawing.Point(0, 0);
            this.transferContentView.Name = "transferContentView";
            this.transferContentView.Size = new System.Drawing.Size(550, 55);
            this.transferContentView.TabIndex = 0;
            this.transferContentView.UseCompatibleStateImageBehavior = false;
            this.transferContentView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Destination Device";
            this.columnHeader3.Width = 158;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Progress Info";
            this.columnHeader2.Width = 137;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Time Elasped";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Source File Name";
            this.columnHeader1.Width = 170;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Destination File Name";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(161, 6);
            // 
            // chatBoxToolStripMenuItem
            // 
            this.chatBoxToolStripMenuItem.Name = "chatBoxToolStripMenuItem";
            this.chatBoxToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.chatBoxToolStripMenuItem.Text = "Chat Box";
            this.chatBoxToolStripMenuItem.Click += new System.EventHandler(this.chatBoxToolStripMenuItem_Click);
            // 
            // exploreForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 493);
            this.Controls.Add(this.explorerPanel);
            this.Controls.Add(this.transferPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "exploreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "exploreForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.exploreForm_Closing);
            this.Load += new System.EventHandler(this.exploreForm_Load);
            this.Shown += new System.EventHandler(this.explorerForm_Shown);
            this.contentViewContextMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.explorerPanel.ResumeLayout(false);
            this.explorerPanel.PerformLayout();
            this.transferPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView contentView;
        private System.Windows.Forms.TextBox addressBox;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ImageList driveImageList;
        private System.Windows.Forms.ImageList dirFileImageList;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ToolStripMenuItem exchangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sentFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem sentDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadDirectoryToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferProgressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem explorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem processViewToolStripMenuItem;
        private System.Windows.Forms.Panel explorerPanel;
        private System.Windows.Forms.Panel transferPanel;
        private System.Windows.Forms.ListView transferContentView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip contentViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openWithNewConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem sentToToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem largeIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem smallIconToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem cleanCacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ToolStripMenuItem openInOtherDeviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem chatBoxToolStripMenuItem;
    }
}