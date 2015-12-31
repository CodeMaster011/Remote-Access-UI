using RAT.Communicate;
using RAT.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static RemoteAccessUI_Client.MyGlobal;

namespace RemoteAccessUI_Client
{
    public class NetworkServer
    {
        public string authId;
        public string nickName;
        public RServer serverPort;

        public delegate void NewConnectionEstablished(NetworkServer sender, CommunicationNetworkStream stream);
        public delegate void ErrorEncounted(RServer sender, CommunicationNetworkStream stream, String data);
        public static void requestNewConnectionToOpenPort(string ipAddress, NewConnectionEstablished NewConnectionEstablishedCallback,
                                                                ErrorEncounted ErrorEncountedCallback)
        {
            RServer tS = new RServer(ipAddress, COMMUNICATION_PORT.ToString());
            tS.setOnNewDeviceConnectedCallback(
                new RServer.NewDeviceConnected(
                    (RServer _sender, CommunicationNetworkStream _stream) => {
                        _stream.WriteString("NEW_CONNECTION");
                    }
                    )
                );
            tS.setOnDataReceivedCallback(
            new RServer.DataReceived(
                (RServer _sender, CommunicationNetworkStream stream, String data) =>
                {
                    if (data.Contains("WAIT_FOR_CONNECTION")) { ErrorEncountedCallback(_sender, stream, data); }      // Error En count Callback}

                        //SPLIT DATA TO GET PORT & AUTH ID
                        string[] pp = data.Split(':');
                    if (pp[0].Contains("MOVE_TO_PORT"))
                    {
                            //INSTRUCT TO MOVE TO NEW PORT
                            string port = pp[1]; string authId = pp[2];

                        NetworkServer server = new NetworkServer();
                        server.authId = authId;
                        server.nickName = ipToNickName(_sender.ServerIP);
                        server.serverPort = new RServer(_sender.ServerIP, port);
                        server.serverPort.setOnNewDeviceConnectedCallback(
                            new RServer.NewDeviceConnected(
                                (RServer __sender, CommunicationNetworkStream _stream) => {
                                    //SENT THE AUTH ID OF THE CLIENT
                                    _stream.WriteString(((NetworkServer)serverList[$"{__sender.ServerIP}:{__sender.ServerPort.ToString()}"]).authId);

                                    NetworkServer serverObj = (NetworkServer)serverList[$"{__sender.ServerIP}:{__sender.ServerPort.ToString()}"];

                                    serverList.Remove($"{__sender.ServerIP}:{__sender.ServerPort.ToString()}");     //REMOVE THE SERVER OBJ FROM LIST

                                    NewConnectionEstablishedCallback(serverObj, _stream);        //GIVE THE CALLBACK                                    
                                }
                                )
                            );
                        serverList.Add($"{_sender.ServerIP}:{port}", server);
                        server.serverPort.Connect(true);                        
                     }
                    _sender.removeAllNewDeviceConnectedCallback();
                    _sender.removeAllDataReceivedCallback();
                    _sender.StopListening();    //CLOSE THE CONNECTION TO OPEN PORT 5660
                }
                ));
            tS.Connect(true);
        }

        public static void closeConnection(RServer connection)
        {
            if (connection.IsRunning)
            {
                connection.Stream.WriteString(ExchangeType.CLOSE_CONNECTION_REQUEST.ToString());
                connection.removeAllNewDeviceConnectedCallback();
                connection.removeAllDataReceivedCallback();
                connection.StopListening();
            }            
        }

        public static Task<NetworkServer> requestNewConnectionToOpenPortAsync(string ipAddress)
        {
            return Task<NetworkServer>.Factory.StartNew(()=> {
                bool isDone = false;
                NetworkServer server = null;
                requestNewConnectionToOpenPort(ipAddress, new NewConnectionEstablished(
                    (NetworkServer sender, CommunicationNetworkStream stream) => {
                        //CONNECTION MADE
                        server = sender;
                        isDone = true;
                }),
                    new ErrorEncounted((RServer sender, CommunicationNetworkStream stream, String data) => {
                        server = null;
                        isDone = true;
                    }));
                while (!isDone)
                    Thread.Sleep(10);
                return server;
            });
        }
    }
}
