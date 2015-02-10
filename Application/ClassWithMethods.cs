using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ClassWithMethods
    {
        public void DirectoryList(String path)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + path + "/");
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Console.WriteLine(reader.ReadToEnd());

            Console.WriteLine("Directory List Complete, status {0}", response.StatusDescription);

            reader.Close();
            response.Close();
        }
        public void DownloadAndSaveAS(String path, String name)
        {
            string[] split = path.Split(new Char[] {'.'});
            name += "." + split[split.Length - 1];
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + path);
            request.Method = WebRequestMethods.Ftp.DownloadFile;


            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            //Console.WriteLine(reader.ReadToEnd());

            using (FileStream fstream = new FileStream(name, FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(reader.ReadToEnd());
                fstream.Write(array, 0, array.Length);
                //Console.WriteLine("File successfully downloaded");
            }
            Console.WriteLine("Download Complete, status {0}", response.StatusDescription);
            reader.Close();
            response.Close(); 
        }
    }
}
