using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using r = RAT.Respone;
using RAT.Core;
namespace RemoteAccessUI_Client.DialogBox
{
    public partial class PropertiesBoxForm : Form
    {
        public PropertiesBoxForm()
        {
            InitializeComponent();
        }
        public Image objectIcon = null;
        private void PropertiesBoxForm_Load(object sender, EventArgs e)
        {
            switch (recognizeSelectedItem(Tag))
            {
                case 1:     //DRIVE
                    r.DrivesInformationResponse.DriveInfo div = (r.DrivesInformationResponse.DriveInfo)Tag;
                    Close();
                    break;
                case 2:     //DIRECTORY
                    r.DirectoryInformationResponse.DirectoryInfo dir = (r.DirectoryInformationResponse.DirectoryInfo)Tag;
                    Text = $"{dir.Name} Properties";
                    nameLabel.Text = dir.Name;
                    typeLabel.Text = "Folder";
                    locLabel.Text = dir.FullName.Substring(0, dir.FullName.Length - dir.Name.Length);
                    sizeLabel.Text = "<unknown>";
                    DateTime dt = FileSystem.StringToDate(dir.CreationTime);
                    createdLabel.Text = $"{dt.DayOfWeek.ToString()}, {MyGlobal.MonthOfYear(dt.Month)} {dt.Day.ToString("00")}, {dt.Year}, {dt.Hour.ToString("00")}:{dt.Minute.ToString("00")}:{dt.Second.ToString("00")}";
                    dt = FileSystem.StringToDate(dir.LastWriteTime);
                    modifiedLabel.Text = $"{dt.DayOfWeek.ToString()}, {MyGlobal.MonthOfYear(dt.Month)} {dt.Day.ToString("00")}, {dt.Year}, {dt.Hour.ToString("00")}:{dt.Minute.ToString("00")}:{dt.Second.ToString("00")}";
                    dt = FileSystem.StringToDate(dir.LastAccessTime);
                    accessedLabel.Text = $"{dt.DayOfWeek.ToString()}, {MyGlobal.MonthOfYear(dt.Month)} {dt.Day.ToString("00")}, {dt.Year}, {dt.Hour.ToString("00")}:{dt.Minute.ToString("00")}:{dt.Second.ToString("00")}";
                    break;
                case 3:     //FILE
                    r.FileInformationResponse.FileInfo fil = (r.FileInformationResponse.FileInfo)Tag;
                    Text = $"{fil.Name.Replace(fil.Extention,"")} Properties";
                    nameLabel.Text = fil.Name;
                    typeLabel.Text = $"File ({fil.Extention})";
                    locLabel.Text = fil.FullName.Substring(0, fil.FullName.Length - fil.Name.Length);
                    sizeLabel.Text = $"{fil.Length} bytes";
                    DateTime dtt = FileSystem.StringToDate(fil.CreationTime);
                    createdLabel.Text = $"{dtt.DayOfWeek.ToString()}, {MyGlobal.MonthOfYear(dtt.Month)} {dtt.Day.ToString("00")}, {dtt.Year}, {dtt.Hour.ToString("00")}:{dtt.Minute.ToString("00")}:{dtt.Second.ToString("00")}";
                    dtt = FileSystem.StringToDate(fil.LastWriteTime);
                    modifiedLabel.Text = $"{dtt.DayOfWeek.ToString()}, {MyGlobal.MonthOfYear(dtt.Month)} {dtt.Day.ToString("00")}, {dtt.Year}, {dtt.Hour.ToString("00")}:{dtt.Minute.ToString("00")}:{dtt.Second.ToString("00")}";
                    dtt = FileSystem.StringToDate(fil.LastAccessTime);
                    accessedLabel.Text = $"{dtt.DayOfWeek.ToString()}, {MyGlobal.MonthOfYear(dtt.Month)} {dtt.Day.ToString("00")}, {dtt.Year}, {dtt.Hour.ToString("00")}:{dtt.Minute.ToString("00")}:{dtt.Second.ToString("00")}";
                    break;
            }
            if (objectIcon != null) { pictureBox1.Image = objectIcon; }
                
        }
        
        private int recognizeSelectedItem(object tag)
        {
            string st = tag.GetType().ToString();
            if (st.Contains("DriveInfo")) { return 1; }
            else if (st.Contains("DirectoryInfo")) { return 2; }
            else if (st.Contains("FileInfo")) { return 3; }
            else return 0;
        }
    }
}
