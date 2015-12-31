using RAT.Communicate;
using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using r = RAT.Respone;
using System.IO;
using static RemoteAccessUI_Client.MyGlobal;
using System.Collections.Generic;

namespace RemoteAccessUI_Client
{
    public class LocalServerStorageManagement
    {
        public class LocalServerStorageStucture
        {
            public string localPath;
            public string serverIP;
            public r.FileInformationResponse.FileInfo fileInfo;
            public LocalServerStorageStucture() { }
        }
        public Dictionary<string,LocalServerStorageStucture> fileList = new Dictionary<string, LocalServerStorageStucture>();
        public bool isUpdated = false;
        public async Task<string> GetLocalFile(string serverIP, r.FileInformationResponse.FileInfo fileInfo)
        {            
            string key = $"{serverIP}:{fileInfo.FullName}";
            isUpdated = false;
            if (fileList.ContainsKey(key))
            {
                try
                {
                    //THERE IS A LOCAL COPY
                    LocalServerStorageStucture _localCopy = fileList[key];
                    //VALIDATE THE LOCAL COPY
                    if (fileInfo.CreationTime == _localCopy.fileInfo.CreationTime &&
                        fileInfo.LastWriteTime == _localCopy.fileInfo.LastWriteTime &&
                        fileInfo.Length == _localCopy.fileInfo.Length)
                        //return await Task<string>.Factory.StartNew(() => { return _localCopy.localPath; });
                        return _localCopy.localPath;
                    else
                        fileList.Remove(key);   //REMOVE THE LOCAL COPY AS THE ORIGINAL IS GOT UPDATED
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
            string desPath = LOCAL_DATABASE_STORAGE_PATH  + $"{fileInfo.Name} - " + Guid.NewGuid().ToString() + fileInfo.Extention;
            await downloadFile(serverIP, fileInfo.FullName, desPath);
            //REGISTER THE DOWNLOADED COPY
            LocalServerStorageStucture newLocalCopy = new LocalServerStorageStucture() { serverIP = serverIP, fileInfo = fileInfo, localPath = desPath};
            fileList.Add(key, newLocalCopy);    //REGISTER THE NEW COPY WITH THE KEY
            isUpdated = true;       //NOTIFY THE UPDATE IS MADE
            return desPath;
        }
        private Task downloadFile(string sourceIP, string sourcePath, string destinationPath)
        {
            return Task.Factory.StartNew(()=> {
                bool isDone = false;
                FileDownloadManagement download = new FileDownloadManagement();
                download.SourceIp = sourceIP;
                TransferDetails info = new TransferDetails(sourcePath, destinationPath);
                download.fileDetails.Add(info);
                download.AllFileDownloadingCompletedCallback = 
                        new FileDownloadManagement.AllFileDownloadingCompleted((FileDownloadManagement sender, RServer server)=> {
                            isDone = true;
                        });
                download.StartDownloading();
                while (!isDone)
                    Thread.Sleep(10);
            });
        }

        public string toJson() =>
            JsonConvert.SerializeObject(this);
        public static LocalServerStorageManagement fillFromJson(string json) =>
            JsonConvert.DeserializeObject<LocalServerStorageManagement>(json);
    }
    class LocalStorageControl
    {
        public LocalServerStorageManagement LocalStorage = new LocalServerStorageManagement();
        public bool isLoaded = false;
        public Task saveDatabase()
        {
            return Task.Factory.StartNew(() => {
                StreamWriter writer = null;
                string path = LOCAL_DATABASE_PATH;
                try
                {
                    if (File.Exists(path))                //Rename the existing file
                        File.Move(path, path + ".temp");
                    try
                    {
                        writer = new StreamWriter(path);
                        writer.WriteLine(LocalStorage.toJson());
                        //DELETE THE TEMP FILE
                        if (File.Exists(path + ".temp"))
                            File.Delete(path + ".temp");
                    }
                    catch (Exception) { throw; }
                    finally { writer?.Close(); }
                }
                catch (Exception)
                {
                    throw;
                }
            });
        }
        public Task loadDatabase()
        {
            return Task.Factory.StartNew(() =>
            {
                StreamReader reader = null;
                string path = LOCAL_DATABASE_PATH;
                try
                {
                    if (File.Exists(path))
                    {
                        reader = new StreamReader(path);
                        String json = reader.ReadToEnd();
                        LocalStorage = LocalServerStorageManagement.fillFromJson(json);
                    }
                    else
                        throw new Exception("File Not Found");
                }
                catch (Exception)
                {


                }
                finally
                {
                    reader?.Close();        //close reader if not null                
                }
            });
        }
        public Task clearDatabase()
        {
            return Task.Factory.StartNew(()=> {
                //UN REGISTER
                LocalStorage = new LocalServerStorageManagement();                
                //CLEAR DISK
                try
                {
                    File.Delete(LOCAL_DATABASE_PATH);
                }
                catch (Exception) { }
                isLoaded = false;
                string[] list = Directory.GetFiles(LOCAL_DATABASE_STORAGE_PATH);
                foreach (string item in list)
                {
                    try
                    {
                        File.Delete(item);
                    }
                    catch (Exception) { }
                }
            });
        }
    }
}
