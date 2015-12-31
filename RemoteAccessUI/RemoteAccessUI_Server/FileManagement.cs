using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace RemoteAccessUI_Server
{    
    class FileManagement
    {
        public String path = "serverInfo.txt";
        public FileDataStucture fileData;
        public void read()
        {
            StreamReader reader = null;
            try
            {
                if (File.Exists(path))
                {
                    reader = new StreamReader(path);
                    String json = reader.ReadToEnd();
                    fileData = FileDataStucture.fillFromJson(json);
                }
                else
                    throw new Exception("File Not Found");                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                reader?.Close();        //close reader if not null                
            }
        }
        public void write()
        {
            StreamWriter writer = null;
            try
            {
                if (File.Exists(path))                //Rename the existing file
                    File.Move(path, path + ".temp");
                try
                {
                    writer = new StreamWriter(path);
                    writer.WriteLine(fileData.toJson());
                    //DELETE THE TEMP FILE
                    if (File.Exists(path + ".temp"))
                        File.Delete(path + ".temp");
                }
                catch (Exception){  throw;  }
                finally { writer?.Close(); }                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    class FileDataStucture
    {
        public String myIpAddress = "";
        public List<String> availableIp = new List<String>();

        public String toJson() =>        
            JsonConvert.SerializeObject(this);
        public static FileDataStucture fillFromJson(String json) =>
            JsonConvert.DeserializeObject<FileDataStucture>(json);
    }
}
