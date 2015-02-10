using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {

        public static void Main()
        {
            ClassWithMethods classWithMethods = new ClassWithMethods();
            String comand;
            string[] splitComand;
            String lastUrl = "ftp.mozilla.org";
            String url = "ftp.mozilla.org";
            do
            {
                comand = Console.ReadLine();
                splitComand = comand.Split(new Char[] { ' ' });
                switch (splitComand[0])
                {
                    case "start":
                        try
                        {
                            classWithMethods.DirectoryList("ftp.mozilla.org");
                            lastUrl = "ftp.mozilla.org";
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                case "go":
                        try
                        {
                            lastUrl = url;
                            classWithMethods.DirectoryList(url + "/" + splitComand[1]);
                            url += "/" + splitComand[1];
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid input");
                        }
                break;
                case "back":
                        try
                        {
                            classWithMethods.DirectoryList(lastUrl);
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid input");
                        }
                break;
                case "download":
                try
                {
                    classWithMethods.DownloadAndSaveAS(url + "/" + splitComand[1], splitComand[2]);
                }

                catch (Exception e)
                {
                    Console.WriteLine("Invalid input");
                }
                break;
                case "goToNewUrl":
                try
                {
                    lastUrl = url;
                    classWithMethods.DirectoryList(splitComand[1]);
                    url += splitComand[1];
                }

                catch (Exception e)
                {
                    Console.WriteLine("Invalid input");
                }
                break;
                }
                //lastUrl = splitComand[1];
            }
            while (splitComand[0]!="exit");
            //classWithMethods.DirectoryList("ftp.mozilla.org");
            //classWithMethods.DownloadAndSaveAS("ftp.mozilla.org/index.html","default");
            //Console.ReadKey();
        }
    }
}
