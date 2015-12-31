using RAT.Communicate;
using RAT.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RemoteAccessUI_Client
{
    class FileDownloadManagement
    {
        #region "Methods"
        public List<TransferDetails> fileDetails = new List<TransferDetails>();
        public FileDownloadingStarted FileDownloadingStartedCallback { get; set; }
        public FileDownloadingProgress DownloadingProgressCallback { get; set; }
        public FileDownloadingCompleted DownloadingCompletedCallback { get; set; }
        public ConnectionEstablishError ConnectionEstablishErrorCallback { get; set; }
        public AllFileDownloadingCompleted AllFileDownloadingCompletedCallback { get; set; }
        public string DestinationIp { get { return MyGlobal.fileManagement.fileData.myIpAddress; } }
        public TimeSpan TotalTimeElapsed { get { return totalTimeElapsed; } }
        private TimeSpan totalTimeElapsed;
        public string SourceIp { get; set; }
        public double TotalSizeForTransfer;
        public double ActualSizeTransfered = 0;
        private int skeepCalls = 1;

        #endregion
        public void skeepCallback(int skeepCalls) =>
                this.skeepCalls = skeepCalls;

        public void StartDownloading()
        {
            NetworkServer.requestNewConnectionToOpenPort(SourceIp,
                new NetworkServer.NewConnectionEstablished(newConnectionEstablishedCallback),
                new NetworkServer.ErrorEncounted((RServer sender, CommunicationNetworkStream stream, string data) =>
                {
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
        private void newConnectionEstablishedCallback(NetworkServer serverObj, CommunicationNetworkStream __stream)
        {
            RServer connection = serverObj.serverPort;
            double _readOut = 0;
            int noOfFilesReceived = 0;
            //lock(_readOut){ }      
            //SET UP TIMER
            Stopwatch totalTimer = new Stopwatch(); //TOTAL TIME  
            totalTimer.Start(); //START TIMER          
            Stopwatch fileTimer = new Stopwatch();//FILE TIMER  
            fileTimer.Start();  //START TIMER          
            //HANDLE THE DATA RECEIVED RESPONSES
            connection.setOnDataReceivedCallback(
            new RServer.DataReceived((RServer sender, CommunicationNetworkStream stream, string data)=> {
                switch (CommandRecognization.Recognize(data))
                {                        
                    case ExchangeType.FILE_TRANSFER:
                        double calling = 1;
                        fileTimer.Restart();  //START TIMER
                        TransferDetails CURRENT_FILE = fileDetails[noOfFilesReceived];  //CURRENT FILE
                                                
                        FileReceiver fR = new FileReceiver(stream).Initialize(); //TRANSFER OBJ
                        //PROGRESS CALLBACK
                        fR.FileReceivingProgressCallback = new FileReceiver.FileReceivingProgress(
                            (string FileName, double progressRatio)=> {
                                try
                                {                                    
                                    CURRENT_FILE.progressRatio = progressRatio;
                                    ActualSizeTransfered = _readOut + CURRENT_FILE.FileLength * progressRatio;
                                    totalTimeElapsed = totalTimer.Elapsed;  //UPDATE PUBLIC
                                    try
                                    {
                                        if ((calling % skeepCalls) == 0)
                                            DownloadingProgressCallback(this, CURRENT_FILE, progressRatio,fileTimer);     //PASS THE CALLBACK
                                    }
                                    catch (Exception) { }                                    
                                    calling++;
                                }
                                catch (Exception) { }
                            });
                        //COMPLETION CALLBACK
                        fR.FileReceivingCompletedCallback = new FileReceiver.FileReceivingCompleted(
                            (string FileName) => {
                                //DOWNLOAD COMPLETED
                                try
                                {
                                    _readOut += CURRENT_FILE.FileLength;
                                    ActualSizeTransfered = _readOut;
                                    noOfFilesReceived++;
                                    fileTimer.Stop();   //STOP TIMER
                                    totalTimeElapsed = totalTimer.Elapsed;  //UPDATE PUBLIC
                                    try
                                    {
                                        DownloadingProgressCallback(this, CURRENT_FILE, 1.0d, fileTimer);     //FORCED CALLBACK
                                    }
                                    catch (Exception) { }
                                    try
                                    {
                                        DownloadingCompletedCallback(this, CURRENT_FILE, fileTimer);    //PASS THE CALLBACK
                                    }
                                    catch (Exception) { }                                    
                                }
                                catch (Exception) { }
                            });

                        try
                        {
                            //NEW RECEIVING IS STARTED
                            FileDownloadingStartedCallback(this, CURRENT_FILE);     //RECEIVING STARTED CALLBACK
                        }
                        catch (Exception) { }                        

                        fR.StartReceiving(true);        //START RECEIVING
                        
                        if (fileDetails.Count<= noOfFilesReceived) {
                            //ALL DOWNLOADS COMPLETED
                            totalTimer.Stop();      //STOP TIMER
                            totalTimeElapsed = totalTimer.Elapsed;  //UPDATE PUBLIC
                            try
                            {
                                AllFileDownloadingCompletedCallback(this, sender);  //ALL FILES RECEIVED
                            }
                            catch (Exception) { }                            
                            NetworkServer.closeConnection(connection);  //CLOSE CONNECTION
                        }
                        break;
                    default:
                        break;
                }
            }));
            //MADE ALL REQUESTS
            foreach (TransferDetails info in fileDetails)            
                new FileReceiverRequest(info.SourcePath, info.DestinationPath, connection.Stream, MyGlobal.BUFFER_SIZE).Request();
        }

        #region "Delegate"

        public delegate void FileDownloadingStarted(FileDownloadManagement sender, TransferDetails objectDetails);
        public delegate void FileDownloadingProgress(FileDownloadManagement sender, TransferDetails objectDetails, double progressRatio, Stopwatch Timer);
        public delegate void FileDownloadingCompleted(FileDownloadManagement sender, TransferDetails objectDetails, Stopwatch Timer);
        public delegate void ConnectionEstablishError(FileDownloadManagement sender, RServer server, string message);
        public delegate void AllFileDownloadingCompleted(FileDownloadManagement sender, RServer server);

        #endregion 
    }
}
