using RAT.Communicate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RemoteAccessUI_Server
{
    static class MyGlobal
    {
        public const int OPEN_COMMUNICATION_PORT = 5660;
        public static FileManagement fileManagement;
        public static int[] ALLOCABLE_PORTS = new int[]{ 5661,5662,5663,5664,5665,5666,5667,5668};
        public static List<int> ACTIVE_PORTS = new List<int>();
        public static Hashtable ConnectedClients = new Hashtable();

        public static int allocateNewPort()
        {
            foreach (int avilPort in ALLOCABLE_PORTS)
            {
                if (!ACTIVE_PORTS.Contains(avilPort)) {
                    ACTIVE_PORTS.Add(avilPort); //REGISTER THE AVAILABLE PORT AS ACTIVE PORT
                    return avilPort;        //RETURN THE ACTIVE PORT
                }                    
            }
            return -1;  //THEIR IS NO FREE PORT. ALLOCATION FAILED
        }
        public static void unRegisterPort(int port)
        {
            if (ACTIVE_PORTS.Contains(port))        //CONFIRM THE PORT IS IN ACTIVE PORT
                ACTIVE_PORTS.Remove(port);          //UNREGISTER THE PORT AS ACTIVE
        }
        public static string getOthIdOfClient(RServer client)
        {
            foreach (DictionaryEntry item in ConnectedClients)
            {
                NetworkClient obj = ((NetworkClient)item.Value);
                if (obj.clientPort.ServerIP == client.ServerIP && obj.clientPort.ServerPort == client.ServerPort)
                    return obj.othId;
            }
            return null;
        }
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
    }
}
