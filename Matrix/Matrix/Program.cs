using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string[] code = { "01", "10", "0001", "1100" };
            int[] chCode = { 47, 92, 124, 46, 43, 45, 40, 41, 0, 1 };

            Random rnd = new Random();
            ConsoleColor[] colors = { ConsoleColor.DarkRed, ConsoleColor.White, ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.DarkBlue, ConsoleColor.Blue, ConsoleColor.Gray, ConsoleColor.Magenta, ConsoleColor.Black };

            while (true)
            {
                if (Console.BackgroundColor == ConsoleColor.Black)
                {
                    Console.BackgroundColor = colors[rnd.Next(0, 8)];
                    Console.ForegroundColor = colors[rnd.Next(0, 8)];
                }
                else if (Console.BackgroundColor == ConsoleColor.Red)
                {
                    Console.BackgroundColor = colors[rnd.Next(0, 8)];
                    Console.ForegroundColor = colors[rnd.Next(0, 8)];
                }
                else
                {
                    Console.ResetColor();
                }

                Console.ForegroundColor = colors[rnd.Next(0, 8)];
                Console.Write($"{(char)chCode[rnd.Next(0, 10)]}{ (char)chCode[rnd.Next(0, 10)]}{ (char)chCode[rnd.Next(0, 10)]}");
            }
        }
    }
}
