using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

//Write a program that downloads a file from Internet(e.g.Ninja image) and stores it the current directory.
//Find in Google how to download files in C#. Be sure to catch all exceptions and to free any used resources in the finally block.

namespace ex_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter URL of the file: ");
                string url = Console.ReadLine();

                string directory = Directory.GetCurrentDirectory();
                Console.WriteLine($"The image will be downloaded on {directory}");

                WebClient webClient = new WebClient();

                try
                {
                    //webClient.DownloadFile("https://cdn.pixabay.com/photo/2017/01/31/13/49/ninja-2024214__340.png", directory);
                    webClient.DownloadFile(url, directory);
                    Console.WriteLine("Download complete!");
                }
                catch (WebException)
                {
                    Console.WriteLine("Invalid address -or- Empty file -or- The file does not exist.");
                }
                catch (NotSupportedException)
                {
                    Console.WriteLine("The method has been called simultaneously on multiple threads.");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Invalid address. The address can not be null.");
                }
                finally
                {
                    webClient.Dispose();
                }

            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("We don't have access on this directory");
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        
        }
    }
}
