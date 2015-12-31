using RAT.Communicate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RemoteAccessUI_Client
{
    static class MyGlobal
    {
        public const int COMMUNICATION_PORT = 5660;
        public static FileManagement fileManagement;
        public static int BUFFER_SIZE = 65536;
        public static Hashtable serverList = new Hashtable();

        //LOCAL MANAGEMENT
        public const string LOCAL_DATABASE_STORAGE_PATH = "local\\";
        public const string LOCAL_DATABASE_PATH = "local\\databace.txt";
        public static LocalStorageControl DB = new LocalStorageControl();

        public static string ipToNickName(string ip)
        {
            foreach (string item in fileManagement.fileData.availableIp)
            {
                string[] pp = item.Split('=');
                if (pp[1].Contains(ip))
                    return pp[0];       //NICK NAME
            }
            return null;
        }
        public static string MonthOfYear(int month)
        {
            string[] mon = new string[] { "January", "February", "March","", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
            return mon[month - 1];
        }
        public static void createNewDirectory(CommunicationNetworkStream stream, string dir)
        {
            stream.WriteString($"CREATE_DIR:{dir}");
        }
    }
}
