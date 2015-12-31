using RAT.Communicate;
using System;
using System.Collections.Generic;
using System.Text;
using RAT.Core;
using System.Windows.Forms;
using System.Diagnostics;
namespace RemoteAccessUI_Client
{
    public class TransferDetails
    {
        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }
        public long FileLength { get; set; }
        public double progressRatio { get; set; }
        public List<object> Tag = new List<object>();
        public TransferDetails(string SourcePath, string DestinationPath)
        {
            this.SourcePath = SourcePath;
            this.DestinationPath = DestinationPath;
        }
        public TransferDetails() { }
    }
    class FileTransferManagement
    {        
        public List<TransferDetails> fileDetails = new List<TransferDetails>();
        public FileTransferingStarted FileTransferingStartedCallback { get; set; }
        public FileTransferingProgress TransferProgressCallback { get; set; }
        public FileTransferingCompleted TransferCompletedCallback { get; set; }
        public ConnectionEstablishError ConnectionEstablishErrorCallback { get; set; }
        public AllFileTransferingCompleted AllFileTransferingCompletedCallback { get; set; }
        public string DestinationIp { get; set; }
        public TimeSpan TotalTimeElapsed { get { return totalTimeElapsed; } }
        public string SourceIp { get { return MyGlobal.fileManagement.fileData.myIpAddress; } }
        public double TotalSizeForTransfer;
        public double ActualSizeTransfered = 0;
        private int skeepCalls = 1;
        private TimeSpan totalTimeElapsed;
        public void StartTransfering()
        {
            NetworkServer.requestNewConnectionToOpenPort(DestinationIp,
                new NetworkServer.NewConnectionEstablished(newConnectionEstablishedCallback),
                new NetworkServer.ErrorEncounted((RServer sender, CommunicationNetworkStream stream, String data)=>{
                    //ERROR CALLBACK
                    //NO CONNECTION
                    try
                    {
                        ConnectionEstablishErrorCallback(this, sender, data);
                    }
                    catch (Exception) { }
                })
                );
        }
        private void newConnectionEstablishedCallback(NetworkServer serverObj, CommunicationNetworkStream stream) {
            RServer connection = serverObj.serverPort;
            double _readOut = 0;
            //SET UP TIMER
            Stopwatch totalTimer = new Stopwatch(); //TOTAL TIME
            totalTimer.Start(); //START TIMER
            Stopwatch fileTimer = new Stopwatch();//FILE TIMER
            fileTimer.Start();  //START TIMER
            foreach (TransferDetails info in fileDetails)
            {
                double calling = 1;
                fileTimer.Restart();  //START TIMER
                FileTransfer ft = new FileTransfer(info.SourcePath, info.DestinationPath, connection.Stream,
                    new FileTransfer.FileTransferingProgress((string fileName, double progressRatio) =>
                    {
                        try
                        {
                            info.progressRatio = progressRatio;
                            ActualSizeTransfered = _readOut + info.FileLength * progressRatio;
                            totalTimeElapsed = totalTimer.Elapsed;  //UPDATE PUBLIC
                            if ((calling % skeepCalls) == 0)
                                TransferProgressCallback(this, info, progressRatio, fileTimer);    //PASS THE CALLBACK
                            calling++;                            
                        }
                        catch (Exception) { }
                    }),
                    new FileTransfer.FileTransferingCompleted((string fileName) =>
                    {
                        try
                        {
                            _readOut += info.FileLength;
                            ActualSizeTransfered = _readOut;
                            fileTimer.Stop();   //STOP TIMER
                            totalTimeElapsed = totalTimer.Elapsed;  //UPDATE PUBLIC
                            TransferProgressCallback(this, info, 1.0d, fileTimer);    //FORCED CALLBACK
                            TransferCompletedCallback(this, info, fileTimer);    //PASS THE CALLBACK
                        }
                        catch (Exception) { }
                    }))
                    .Initialize();
                FileTransferingStartedCallback(this, info);       //TRANSFER STARTED CALLBACK
                ft.StartTransfering(true, MyGlobal.BUFFER_SIZE);
            }
            totalTimer.Stop();      //STOP TIMER
            totalTimeElapsed = totalTimer.Elapsed;  //UPDATE PUBLIC
            AllFileTransferingCompletedCallback(this, connection);      //ALL FILES TRANSFERED
            NetworkServer.closeConnection(connection);  //CLOSE CONNECTION
        }
        public void skeepCallback(int skeepCalls) =>
                this.skeepCalls = skeepCalls;

        public delegate void FileTransferingStarted(FileTransferManagement sender, TransferDetails objectDetails);
        public delegate void FileTransferingProgress(FileTransferManagement sender, TransferDetails objectDetails, double progressRatio, Stopwatch Timer);
        public delegate void FileTransferingCompleted(FileTransferManagement sender, TransferDetails objectDetails, Stopwatch Timer);
        public delegate void ConnectionEstablishError(FileTransferManagement sender, RServer server, string message);
        public delegate void AllFileTransferingCompleted(FileTransferManagement sender, RServer server);
    }
}
