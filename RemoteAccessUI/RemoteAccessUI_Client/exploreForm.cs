using RAT.Communicate;
using RAT.Core;
using RemoteAccessUI_Client.DialogBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using r = RAT.Respone;

namespace RemoteAccessUI_Client
{
    public partial class exploreForm : Form
    {
        public NetworkServer server { get; set; }
        public string ImmidiatePath = null;

        private delegate void UpdateData();

        public exploreForm()
        {
            InitializeComponent();
        }

        private void exploreForm_Load(object sender, EventArgs e)
        {
            Thread temp = new Thread(connectToServer);
            temp.Start();

            explorerPanel.Visible = true;
            explorerPanel.Dock = DockStyle.Fill;
        }

        private void connectToServer()
        {
            server.serverPort.setOnDataReceivedCallback(
                new RServer.DataReceived(
                    (RServer sender, CommunicationNetworkStream stream, String data) =>
                    {
                        switch (CommandRecognization.Recognize(data))
                        {
                            case ExchangeType.FS_LIST_DRIVE_RESPONSE:

                                #region "DRIVE RESPONSE"

                                r.DrivesInformationResponse divResponse = FileSystem.ReadDriveList(stream);
                                Invoke(new UpdateData(() =>
                                {
                                    addressBox.Text = server.nickName;  //CHENGE THE ADDRESS BAR TO NICK NAME
                                    contentView.LargeImageList = driveImageList;    //SET THE IMAGE LIST AS DRIVE-FILE
                                    contentView.SmallImageList = driveImageList;    //SET THE IMAGE LIST AS DRIVE-FILE
                                    contentView.BeginUpdate();
                                }));    //FREZZE UI UPDATE

                                ListViewGroup internalGroup = new ListViewGroup("Internal Drives");
                                ListViewGroup removeableUSBGroup = new ListViewGroup("USB Drives");
                                ListViewGroup removeableCDGroup = new ListViewGroup("CD Drives");
                                try
                                {
                                    foreach (r.DrivesInformationResponse.DriveInfo div in divResponse.Drives)
                                    {
                                        ListViewItem liv = new ListViewItem($"{div.VolumeLabel} ({div.Name})");
                                        liv.Tag = div;      //TAG DRIVE
                                        switch (div.DriveType)
                                        {
                                            case System.IO.DriveType.CDRom:
                                                liv.Group = removeableCDGroup;
                                                liv.ImageIndex = 1;
                                                break;

                                            case System.IO.DriveType.Fixed:
                                                liv.Group = internalGroup;
                                                liv.ImageIndex = 0;
                                                break;

                                            case System.IO.DriveType.Removable:
                                                liv.Group = removeableUSBGroup;
                                                liv.ImageIndex = 2;
                                                break;

                                            case System.IO.DriveType.Unknown:
                                                liv.ImageIndex = 3;
                                                break;
                                        }
                                        if (div.isReady)
                                        {
                                            double fill = (double)div.AvailableFreeSpace / div.TotalSize;
                                            liv.Text += $" [{(fill * 100).ToString("00.00")}%]";
                                        }
                                        else
                                        {
                                            liv.Text += $"  [NOT READY]";
                                        }
                                        Invoke(new UpdateData(() => { contentView.Items.Add(liv); }));    //UPDATE CONTENTS
                                    }
                                }
                                catch (Exception) { }
                                Invoke(new UpdateData(() =>
                                {
                                    contentView.Groups.AddRange(new ListViewGroup[] { internalGroup, removeableUSBGroup, removeableCDGroup });
                                    contentView.EndUpdate();
                                }));    //RESUME UI UPDATE

                                #endregion "DRIVE RESPONSE"

                                break;

                            case ExchangeType.FS_LIST_DIRECTORY_RESPONSE:

                                #region "DIRECTORY RESPONSE"

                                r.DirectoryInformationResponse dirResponse = FileSystem.ReadDirectoryList(stream);
                                Invoke(new UpdateData(() =>
                                {
                                    contentView.LargeImageList = dirFileImageList;    //SET THE IMAGE LIST AS DIRECTORY-FILE
                                    contentView.SmallImageList = dirFileImageList;    //SET THE IMAGE LIST AS DIRECTORY-FILE
                                    contentView.BeginUpdate();
                                }));    //FREEZE UI UPDATE
                                try
                                {
                                    foreach (r.DirectoryInformationResponse.DirectoryInfo dir in dirResponse.DirectoryList)
                                    {
                                        ListViewItem liv = new ListViewItem($"{dir.Name}");
                                        liv.Tag = dir;      //TAG DIRECTORY
                                                            //ICON
                                        if (dirFileImageList.Images.ContainsKey($"|{dir.Name.ToLower()}"))
                                            liv.ImageKey = $"|{dir.Name}";
                                        else
                                            liv.ImageKey = "|max.folder";        //UNKNOW FILE FORMAT
                                        Invoke(new UpdateData(() => { contentView.Items.Add(liv); }));    //UPDATE UI UPDATE
                                    }
                                }
                                catch (Exception) { }
                                Invoke(new UpdateData(() => { contentView.EndUpdate(); }));    //RESUME CONTENTS

                                #endregion "DIRECTORY RESPONSE"

                                break;

                            case ExchangeType.FS_LIST_FILE_RESPONSE:

                                #region "FILE RESPONSE"

                                r.FileInformationResponse fileResponse = FileSystem.ReadFileList(stream);
                                Invoke(new UpdateData(() =>
                                {
                                    contentView.LargeImageList = dirFileImageList;    //SET THE IMAGE LIST AS DIRECTORY-FILE
                                    contentView.SmallImageList = dirFileImageList;    //SET THE IMAGE LIST AS DIRECTORY-FILE
                                    contentView.BeginUpdate();
                                }));    //FREZZE UI UPDATE
                                try
                                {
                                    foreach (r.FileInformationResponse.FileInfo f in fileResponse.FileList)
                                    {
                                        ListViewItem liv = new ListViewItem($"{f.Name}");
                                        liv.Tag = f;      //TAG DIRECTORY
                                                          //ICON
                                        if (dirFileImageList.Images.ContainsKey($">{f.Extention.ToLower()}"))
                                            liv.ImageKey = $">{f.Extention}";
                                        else
                                            liv.ImageKey = ">max.file.unknown";        //UNKNOW FILE FORMAT

                                        Invoke(new UpdateData(() => { contentView.Items.Add(liv); }));    //UPDATE UI UPDATE
                                    }
                                }
                                catch (Exception) { }
                                Invoke(new UpdateData(() => { contentView.EndUpdate(); }));    //RESUME CONTENTS

                                #endregion "FILE RESPONSE"

                                break;

                            case ExchangeType.FS_DELETE_RESPONSE:

                                #region "DELETE RESPONSE"

                                string dJs = stream.ReadString();
                                r.DeleteResponse delResponse = r.DeleteResponse.FillFromJson(dJs);
                                if (delResponse.ErrorMessage.Length > 0)
                                    MessageBox.Show($"{delResponse.ErrorMessage}", "Error");

                                #endregion "DELETE RESPONSE"

                                break;

                            case ExchangeType.FS_RENAME_RESPONSE:

                                #region "RENAME RESPONSE"

                                string rJs = stream.ReadString();
                                r.DeleteResponse renResponse = r.DeleteResponse.FillFromJson(rJs);
                                if (renResponse.ErrorMessage.Length > 0)
                                    MessageBox.Show($"{renResponse.ErrorMessage}", "Error");

                                #endregion "RENAME RESPONSE"

                                break;
                        }
                    }
                    ));
            if (ImmidiatePath == null)
                Invoke(new UpdateData(() =>
                {
                    addressBox.Text = server.nickName;
                    refreshContent();
                }));
            else
                Invoke(new UpdateData(() =>
                {
                    addressBox.Text = ImmidiatePath;
                    refreshContent();
                }));
        }

        private void exploreForm_Closing(object sender, FormClosingEventArgs e)
        {
            NetworkServer.closeConnection(server.serverPort);//CLOSE CONNECTION
            if (Application.OpenForms.Count == 1)
                Application.Exit();
        }

        private void explorerForm_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Text = $"Connection Window=> {server.nickName} - ({server.serverPort.ServerIP}:{server.serverPort.ServerPort})";
            }
            catch (Exception) { }
        }

        private void contentView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void contentView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                transferFiles((string[])e.Data.GetData(DataFormats.FileDrop));
            }
        }

        private void contentView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            openSelectedItem();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (addressBox.Text.Length > 3 && addressBox.Text != server.nickName)
            {
                //DIRECTORY UPDATE
                string[] pp = addressBox.Text.Split('\\');
                string path = "";
                for (int i = 0; i < pp.Length - 1; i++) { path += $"{pp[i]}\\"; }
                path = path.Substring(0, path.Length - 1);
                if (path.Length < 3) path += "\\";
                addressBox.Text = path;
            }
            else { addressBox.Text = server.nickName; }
            refreshContent();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refreshContent();
        }

        #region "FUNCTION"

        private int recognizeSelectedItem(ListViewItem selectedItem)
        {
            string st = selectedItem.Tag.GetType().ToString();
            if (st.Contains("DriveInfo")) { return 1; }
            else if (st.Contains("DirectoryInfo")) { return 2; }
            else if (st.Contains("FileInfo")) { return 3; }
            else return 0;
        }

        private void refreshContent()
        {
            try
            {
                //CLEAN UP
                contentView.Groups.Clear();
                contentView.Items.Clear();
            }
            catch (Exception) { }
            //DETERMINE THE REQUEST AS DRIVE OR FILE-DIRECTORY
            if (addressBox.Text == server.nickName)
            {
                backButton.Enabled = false;     //NO MORE BACK
                //REQUEST FOR DRIVES
                FileSystem.RequestDriveList(server.serverPort.Stream);     //REQUEST DRIVE LIST
            }
            else
            {
                backButton.Enabled = true;     //TURN IT ON
                //REQUEST FOR FILES & DIRECTORY
                FileSystem.RequestDirectoryList(server.serverPort.Stream, addressBox.Text);     //REQUEST DIRECTORY LIST
                FileSystem.RequestFileList(server.serverPort.Stream, addressBox.Text);     //REQUEST FILE LIST
            }
        }

        private void transferFiles(string[] path)
        {
            FileTransferManagement transfer = new FileTransferManagement();
            //IP
            transfer.DestinationIp = server.serverPort.ServerIP;
            //PROGRESS FORM
            TransferProgressBoxForm pBox = new TransferProgressBoxForm();
            //FILES
            string[] files = path;
            foreach (string sourcePath in files)
            {
                TransferDetails details = new TransferDetails();
                //SOURCE PATH
                details.SourcePath = sourcePath;
                //DESTINATION PATH
                System.IO.FileInfo f = new System.IO.FileInfo(sourcePath);
                if (addressBox.Text.EndsWith("\\")) details.DestinationPath = addressBox.Text + f.Name;
                else details.DestinationPath = $"{addressBox.Text}\\{f.Name}";
                //LENGTH
                details.FileLength = f.Length;
                transfer.TotalSizeForTransfer += details.FileLength;
                //UI ATTACHMENT
                //FIRST TAG
                ListViewItem liv = new ListViewItem($"{server.nickName} - [{transfer.DestinationIp}]");
                liv.SubItems.Add("Waiting...");
                liv.SubItems.Add("00:00:00");
                liv.SubItems.Add(details.SourcePath);
                liv.SubItems.Add(details.DestinationPath);
                transferContentView.Items.Add(liv);
                details.Tag.Add(liv);   //TAG
                //SECOND TAG
                ListViewItem l = new ListViewItem(details.DestinationPath);
                pBox.addListViewItems(l);
                details.Tag.Add(l);  //TAG
                //ADD TO MASTER
                transfer.fileDetails.Add(details);
            }
            transferContentView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //STARTED CALLBACK
            transfer.FileTransferingStartedCallback = new FileTransferManagement.FileTransferingStarted(
                                    (FileTransferManagement sender, TransferDetails objectDetails) =>
                                    {
                                        Invoke(new UpdateData(() =>
                                        {
                                            try
                                            {
                                                pBox.singleItemStarting((ListViewItem)objectDetails.Tag[1]);
                                            }
                                            catch (Exception) { }
                                        }));
                                    });
            //PROGRESS CALLBACK
            transfer.TransferProgressCallback = new FileTransferManagement.FileTransferingProgress(
                                    (FileTransferManagement sender, TransferDetails objectDetails, double progressRatio, Stopwatch Timer) =>
                                    {
                                        Invoke(new UpdateData(() =>
                                        {
                                            ListViewItem liv = (ListViewItem)objectDetails.Tag[0];
                                            liv.SubItems[1].Text = $"{(progressRatio * 100).ToString("00.00")}%";
                                            liv.SubItems[2].Text = $"{Timer.Elapsed.ToString("hh\\:mm\\:ss")}";
                                            try
                                            {
                                                pBox.progressNotification((int)(sender.ActualSizeTransfered / sender.TotalSizeForTransfer * 100));
                                            }
                                            catch (Exception) { }
                                        }));
                                    });
            //COMPLETION CALLBACK
            transfer.TransferCompletedCallback = new FileTransferManagement.FileTransferingCompleted(
                                    (FileTransferManagement sender, TransferDetails objectDetails, Stopwatch Timer) =>
                                    {
                                        ListViewItem liv = (ListViewItem)objectDetails.Tag[0];
                                        Invoke(new UpdateData(() =>
                                        {
                                            liv.ForeColor = Color.Green;
                                            liv.SubItems[2].Text = $"{Timer.Elapsed.ToString("hh\\:mm\\:ss")}";
                                            try
                                            {
                                                pBox.singleItemCompletion((ListViewItem)objectDetails.Tag[1]);
                                            }
                                            catch (Exception) { }
                                        }));
                                    });
            //ALL TRANSFER COMPLETED CALLBACK
            transfer.AllFileTransferingCompletedCallback = new FileTransferManagement.AllFileTransferingCompleted(
                                    (FileTransferManagement sender, RServer server) =>
                                    {
                                        Invoke(new UpdateData(() =>
                                        {
                                            try { pBox.Close(); }
                                            catch (Exception) { }
                                            try { pBox.Dispose(); }
                                            catch (Exception) { }
                                        }));
                                    }
                                    );
            //ERROR CALLBACK
            transfer.ConnectionEstablishErrorCallback = new FileTransferManagement.ConnectionEstablishError(
                                    (FileTransferManagement sender, RServer server, string message) =>
                                    {
                                        foreach (TransferDetails item in sender.fileDetails)
                                        {
                                            ListViewItem liv = (ListViewItem)item.Tag[0];
                                            Invoke(new UpdateData(() =>
                                            {
                                                liv.SubItems[1].Text = message;
                                                liv.ForeColor = Color.Red;
                                            }));
                                        }
                                    }
                                    );
            transfer.skeepCallback(100);        //REDUCE CALLBACKS
            //SHOW FORM
            pBox.TotalNumberOfItems = files.Length;
            pBox.senderIP = server.serverPort.ServerIP;
            pBox.receiverIP = transfer.DestinationIp;
            pBox.progressNotification(0);
            pBox.Show();
            //START TRANSFERRING
            transfer.StartTransfering();
        }

        private void downloadFiles(List<r.FileInformationResponse.FileInfo> files, string destinationPath)
        {
            FileDownloadManagement download = new FileDownloadManagement();
            //IP
            download.SourceIp = server.serverPort.ServerIP;
            //PROGRESS FORM
            TransferProgressBoxForm pBox = new TransferProgressBoxForm();
            //FILES
            foreach (r.FileInformationResponse.FileInfo sourceFile in files)
            {
                TransferDetails details = new TransferDetails();
                //SOURCE PATH
                details.SourcePath = sourceFile.FullName;
                //DESTINATION PATH
                if (destinationPath.EndsWith("\\")) details.DestinationPath = destinationPath + sourceFile.Name;
                else details.DestinationPath = $"{destinationPath}\\{sourceFile.Name}";
                //LENGTH
                details.FileLength = sourceFile.Length;
                download.TotalSizeForTransfer += details.FileLength;
                //UI ATTACHMENT
                //FIRST TAG
                ListViewItem liv = new ListViewItem($"{server.nickName} - [{download.SourceIp}]");
                liv.SubItems.Add("Waiting...");
                liv.SubItems.Add("00:00:00");
                liv.SubItems.Add(details.SourcePath);
                liv.SubItems.Add(details.DestinationPath);
                transferContentView.Items.Add(liv);
                details.Tag.Add(liv);   //TAG
                //SECOND TAG
                ListViewItem l = new ListViewItem(details.DestinationPath);
                pBox.addListViewItems(l);
                details.Tag.Add(l);  //TAG
                //ADD TO MASTER
                download.fileDetails.Add(details);
            }
            transferContentView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //STARTED CALLBACK
            download.FileDownloadingStartedCallback = new FileDownloadManagement.FileDownloadingStarted(
                                    (FileDownloadManagement sender, TransferDetails objectDetails) =>
                                    {
                                        Invoke(new UpdateData(() =>
                                        {
                                            try
                                            {
                                                pBox.singleItemStarting((ListViewItem)objectDetails.Tag[1]);
                                            }
                                            catch (Exception) { }
                                        }));
                                    });
            //PROGRESS CALLBACK
            download.DownloadingProgressCallback = new FileDownloadManagement.FileDownloadingProgress(
                                    (FileDownloadManagement sender, TransferDetails objectDetails, double progressRatio, Stopwatch Timer) =>
                                    {
                                        Invoke(new UpdateData(() =>
                                        {
                                            ListViewItem liv = (ListViewItem)objectDetails.Tag[0];
                                            liv.SubItems[1].Text = $"{(progressRatio * 100).ToString("00.00")}%";
                                            liv.SubItems[2].Text = $"{Timer.Elapsed.ToString("hh\\:mm\\:ss")}";
                                            try
                                            {
                                                pBox.progressNotification((int)(sender.ActualSizeTransfered / sender.TotalSizeForTransfer * 100));
                                            }
                                            catch (Exception) { }
                                        }));
                                    });
            //COMPLETION CALLBACK
            download.DownloadingCompletedCallback = new FileDownloadManagement.FileDownloadingCompleted(
                                    (FileDownloadManagement sender, TransferDetails objectDetails, Stopwatch Timer) =>
                                    {
                                        ListViewItem liv = (ListViewItem)objectDetails.Tag[0];
                                        Invoke(new UpdateData(() =>
                                        {
                                            liv.ForeColor = Color.Green;
                                            liv.SubItems[2].Text = $"{Timer.Elapsed.ToString("hh\\:mm\\:ss")}";
                                            try
                                            {
                                                pBox.singleItemCompletion((ListViewItem)objectDetails.Tag[1]);
                                            }
                                            catch (Exception) { }
                                        }));
                                    });
            //ALL TRANSFER COMPLETED CALLBACK
            download.AllFileDownloadingCompletedCallback = new FileDownloadManagement.AllFileDownloadingCompleted(
                                    (FileDownloadManagement sender, RServer server) =>
                                    {
                                        Invoke(new UpdateData(() =>
                                        {
                                            try { pBox.Close(); }
                                            catch (Exception) { }
                                            try { pBox.Dispose(); }
                                            catch (Exception) { }
                                        }));
                                    }
                                    );
            //ERROR CALLBACK
            download.ConnectionEstablishErrorCallback = new FileDownloadManagement.ConnectionEstablishError(
                                    (FileDownloadManagement sender, RServer server, string message) =>
                                    {
                                        foreach (TransferDetails item in sender.fileDetails)
                                        {
                                            ListViewItem liv = (ListViewItem)item.Tag[0];
                                            Invoke(new UpdateData(() =>
                                            {
                                                liv.SubItems[1].Text = message;
                                                liv.ForeColor = Color.Red;
                                            }));
                                        }
                                    }
                                    );
            download.skeepCallback(100);        //REDUCE CALLBACKS
            //SHOW FORM
            pBox.TotalNumberOfItems = files.Count;
            pBox.senderIP = server.serverPort.ServerIP;
            pBox.receiverIP = download.DestinationIp;
            pBox.progressNotification(0);
            pBox.Show();
            //START DOWNLOADING
            download.StartDownloading();
        }

        private async void openSelectedItem()
        {
            ListViewItem sItem = contentView.SelectedItems[0];  //GET THE SELECTED OBJECT
            switch (recognizeSelectedItem(sItem))
            {
                case 1: //DRIVE
                    r.DrivesInformationResponse.DriveInfo div = (r.DrivesInformationResponse.DriveInfo)sItem.Tag;
                    addressBox.Text = div.RootDirectoryPath;
                    break;

                case 2: //DIRECTORY
                    r.DirectoryInformationResponse.DirectoryInfo dir = (r.DirectoryInformationResponse.DirectoryInfo)sItem.Tag;
                    addressBox.Text = dir.FullName;
                    break;

                case 3: //FILE
                    r.FileInformationResponse.FileInfo fil = (r.FileInformationResponse.FileInfo)sItem.Tag;
                    if (fil.Length > 4194304d)
                        if (MessageBox.Show("Selected file is too long.\nWant to continue...", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                            return;
                    string fPath = await MyGlobal.DB.LocalStorage.GetLocalFile(server.serverPort.ServerIP, fil);
                    if (MyGlobal.DB.LocalStorage.isUpdated)
                        await MyGlobal.DB.saveDatabase();
                    Process.Start(fPath);
                    return;
                    break;

                case 0:
                    MessageBox.Show("UnKnown Item found", "Error");
                    break;
            }
            refreshContent();       //REQUEST FOR NEW CONTENTS
        }

        #endregion "FUNCTION"

        #region "MENU"

        #region "FILE"

        private void newConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog(this);
        }

        private void closeConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private async void cleanCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await MyGlobal.DB.clearDatabase();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion "FILE"

        #region "VIEW"

        private void explorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!explorerToolStripMenuItem.Checked)
            {
                explorerToolStripMenuItem.Checked = true;   //UPDATE UI
                explorerToolStripMenuItem.CheckState = CheckState.Checked;   //UPDATE UI
                explorerPanel.Visible = true;
                explorerPanel.Dock = DockStyle.Fill;

                //HIDE OTHER
                transferPanel.Visible = false;
                transferProgressToolStripMenuItem.Checked = false;
            }
        }

        private void transferProgressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!transferProgressToolStripMenuItem.Checked)
            {
                transferProgressToolStripMenuItem.Checked = true;   //UPDATE UI
                transferPanel.Visible = true;
                transferPanel.Dock = DockStyle.Fill;
                //HIDE OTHER
                explorerPanel.Visible = false;
                explorerToolStripMenuItem.Checked = false;
            }
        }

        private void processViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        #endregion "VIEW"

        #region "EXCHANGE"

        private void sentFileToolStripMenuItem_Click(object Sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.CheckFileExists = true;
            DialogResult d = openFileDialog1.ShowDialog(this);
            if (d == DialogResult.OK || d == DialogResult.Yes)
                transferFiles(openFileDialog1.FileNames);
        }

        private void downloadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contentView.SelectedItems.Count <= 0) { MessageBox.Show("Please select the files to download", "Error"); return; }

            folderBrowserDialog1.SelectedPath = "";
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.ShowDialog(this);
            if (System.IO.Directory.Exists(folderBrowserDialog1.SelectedPath))
            {
                List<r.FileInformationResponse.FileInfo> list = new List<r.FileInformationResponse.FileInfo>();
                foreach (ListViewItem item in contentView.SelectedItems)
                    list.Add((r.FileInformationResponse.FileInfo)item.Tag);
                downloadFiles(list, folderBrowserDialog1.SelectedPath);
            }
        }

        private void sentDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void downloadDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        #endregion "EXCHANGE"

        #endregion "MENU"

        #region "CONTEXT MENU - EXPLORER"

        private void contentViewContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (contentView.SelectedItems.Count > 0)
            {
                openToolStripMenuItem.Enabled = true;
                openWithNewConnectionToolStripMenuItem.Enabled = true;

                newToolStripMenuItem.Enabled = false;
                openInOtherDeviceToolStripMenuItem.Enabled = false;

                ListViewItem sItem = contentView.SelectedItems[0];
                switch (recognizeSelectedItem(sItem))
                {
                    case 1: //DRIVE
                        downloadToolStripMenuItem.Enabled = false;
                        sentToToolStripMenuItem.Enabled = false;
                        deleteToolStripMenuItem.Enabled = false;
                        renameToolStripMenuItem.Enabled = false;
                        break;

                    case 2: //DIRECTORY
                        downloadToolStripMenuItem.Enabled = true;
                        sentToToolStripMenuItem.Enabled = true;
                        deleteToolStripMenuItem.Enabled = true;
                        renameToolStripMenuItem.Enabled = true;
                        break;

                    case 3: //FILE
                        openWithNewConnectionToolStripMenuItem.Enabled = false;
                        openInOtherDeviceToolStripMenuItem.Enabled = true;
                        downloadToolStripMenuItem.Enabled = true;
                        sentToToolStripMenuItem.Enabled = true;
                        deleteToolStripMenuItem.Enabled = true;
                        renameToolStripMenuItem.Enabled = true;
                        break;

                    case 0:
                        MessageBox.Show("UnKnown Item found", "Error");
                        break;
                }
            }
            else
            {
                //NO ITEM SELECTED
                openToolStripMenuItem.Enabled = false;
                openWithNewConnectionToolStripMenuItem.Enabled = false;
                downloadToolStripMenuItem.Enabled = false;
                sentToToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                renameToolStripMenuItem.Enabled = false;
                openInOtherDeviceToolStripMenuItem.Enabled = false;
                newToolStripMenuItem.Enabled = true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openSelectedItem();
        }

        private void openInOtherDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem sItem = contentView.SelectedItems[0];  //GET THE SELECTED OBJECT
            switch (recognizeSelectedItem(sItem))
            {
                case 1: //DRIVE

                    break;

                case 2: //DIRECTORY

                    break;

                case 3: //FILE
                    r.FileInformationResponse.FileInfo fill = (r.FileInformationResponse.FileInfo)sItem.Tag;
                    ProcessSystem.RequestExecuteProcess(server.serverPort.Stream, fill.FullName);
                    break;

                case 0:
                    MessageBox.Show("UnKnown Item found", "Error");
                    return;
            }
        }

        private void openWithNewConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string imm = "";
            ListViewItem sItem = contentView.SelectedItems[0];  //GET THE SELECTED OBJECT
            switch (recognizeSelectedItem(sItem))
            {
                case 1: //DRIVE
                    r.DrivesInformationResponse.DriveInfo div = (r.DrivesInformationResponse.DriveInfo)sItem.Tag;
                    imm = div.RootDirectoryPath;
                    break;

                case 2: //DIRECTORY
                    r.DirectoryInformationResponse.DirectoryInfo dir = (r.DirectoryInformationResponse.DirectoryInfo)sItem.Tag;
                    imm = dir.FullName;
                    break;

                case 3: //FILE
                    break;

                case 0:
                    MessageBox.Show("UnKnown Item found", "Error");
                    return;
            }
            NetworkServer.requestNewConnectionToOpenPort(server.serverPort.ServerIP,
                    new NetworkServer.NewConnectionEstablished(
                        (NetworkServer newServer, CommunicationNetworkStream stream) =>
                        {
                            exploreForm f = new exploreForm();
                            f.server = newServer;
                            f.ImmidiatePath = imm;
                            f.StartPosition = FormStartPosition.CenterScreen;
                            Invoke(new UpdateData(() => { f.Show(); }));
                        }
                        ),
                    new NetworkServer.ErrorEncounted(
                        (RServer newServer, CommunicationNetworkStream stream, string data) =>
                        {
                            MessageBox.Show("Server is flooded with connection. Try again later.", "Error");
                        }
                        )
                    );
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshContent();
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contentView.SelectedItems.Count <= 0) { MessageBox.Show("Please select the files to download", "Error"); return; }

            folderBrowserDialog1.SelectedPath = "";
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.ShowDialog(this);
            if (System.IO.Directory.Exists(folderBrowserDialog1.SelectedPath))
            {
                List<r.FileInformationResponse.FileInfo> list = new List<r.FileInformationResponse.FileInfo>();
                foreach (ListViewItem item in contentView.SelectedItems)
                    list.Add((r.FileInformationResponse.FileInfo)item.Tag);
                downloadFiles(list, folderBrowserDialog1.SelectedPath);
            }
        }

        private void sentToToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MyGlobal.createNewDirectory(server.serverPort.Stream,)
            InputBoxForm di = new InputBoxForm();
            di.Response = "New Folder";
            di.initiateText("Enter the name of folder", "Add New Folder");
            if (di.ShowDialog(this) == DialogResult.OK)
            {
                string des = "";
                if (addressBox.Text.EndsWith("\\")) des = addressBox.Text + di.Response;
                else des = $"{addressBox.Text}\\{di.Response}";

                MyGlobal.createNewDirectory(server.serverPort.Stream, des);

                refreshContent();
            }
            di.Dispose();
        }

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contentView.View = View.LargeIcon;
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contentView.View = View.Tile;
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contentView.View = View.Details;
        }

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contentView.View = View.SmallIcon;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in contentView.SelectedItems)
            {
                switch (recognizeSelectedItem(item))
                {
                    case 1:     //DRIVE
                        break;

                    case 2:     //DIRECTORY
                        r.DirectoryInformationResponse.DirectoryInfo dir = (r.DirectoryInformationResponse.DirectoryInfo)item.Tag;
                        if (MessageBox.Show("Are you sure you want to permanently delete this folder", "Delete Folder", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            FileSystem.RequestDelete(server.serverPort.Stream, dir.FullName);
                        }
                        break;

                    case 3:     //FILE
                        r.FileInformationResponse.FileInfo fil = (r.FileInformationResponse.FileInfo)item.Tag;
                        if (MessageBox.Show("Are you sure you want to permanently delete this file", "Delete File", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            FileSystem.RequestDelete(server.serverPort.Stream, fil.FullName);
                        }
                        break;
                }
            }
            refreshContent();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem sItem = contentView.SelectedItems[0];  //GET THE SELECTED OBJECT
            switch (recognizeSelectedItem(sItem))
            {
                case 1: //DRIVE
                    break;

                case 2: //DIRECTORY
                    r.DirectoryInformationResponse.DirectoryInfo dir = (r.DirectoryInformationResponse.DirectoryInfo)sItem.Tag;
                    InputBoxForm di = new InputBoxForm();
                    di.Response = dir.Name;
                    di.initiateText("Enter the new name of folder", "Rename Folder");
                    if (di.ShowDialog(this) == DialogResult.OK)
                    {
                        string des = dir.FullName.Substring(0, dir.FullName.Length - dir.Name.Length) + di.Response;
                        if (des != dir.FullName)
                            FileSystem.RequestRename(server.serverPort.Stream, dir.FullName, des);
                    }
                    di.Dispose();
                    break;

                case 3: //FILE
                    r.FileInformationResponse.FileInfo fil = (r.FileInformationResponse.FileInfo)sItem.Tag;
                    InputBoxForm diF = new InputBoxForm();
                    diF.Response = fil.Name;
                    diF.initiateText("Enter the new name of file", "Rename File");
                    if (diF.ShowDialog(this) == DialogResult.OK)
                    {
                        string des = fil.FullName.Substring(0, fil.FullName.Length - fil.Name.Length) + diF.Response;
                        if (des != fil.FullName)
                            FileSystem.RequestRename(server.serverPort.Stream, fil.FullName, des);
                    }
                    diF.Dispose();
                    break;

                case 0:
                    MessageBox.Show("UnKnown Item found", "Error");
                    break;
            }
            refreshContent();       //REQUEST FOR NEW CONTENTS
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem sItem = contentView.SelectedItems[0];  //GET THE SELECTED OBJECT
            PropertiesBoxForm pro = new PropertiesBoxForm();
            if (recognizeSelectedItem(sItem) != 1)
                pro.objectIcon = dirFileImageList.Images[sItem.ImageKey];
            else
                pro.objectIcon = driveImageList.Images[sItem.ImageIndex];
            pro.Tag = sItem.Tag;
            pro.ShowDialog(this);
            pro.Dispose();
        }

        #endregion "CONTEXT MENU - EXPLORER"

        private async void chatBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChatBoxForm ct = new ChatBoxForm();
            ct.server = await NetworkServer.requestNewConnectionToOpenPortAsync(server.serverPort.ServerIP);
            ct.Show();
        }
    }
}