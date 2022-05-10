using static Quiz.Classes.Data;
using static Quiz.Classes.Logic.Reroll;

namespace Quiz.Classes
{
    internal static class Work
    {
        private static void Check(string question)
        {
            if (Number < 11)
            {
                Number++;
                if (question == Answer)
                {
                    Score++;
                    Console.WriteLine();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Game is over! Your score is {Score}.");

                if (Score == 11)
                {
                    Console.WriteLine($"Congratulations! You are the winner!");
                }
                else
                {
                    Console.WriteLine("You lose!");
                }

                Console.ReadKey();
            }
        }

        public static async Task Start()
        {
            await Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Console.Clear();

                    Answer = null;
                    List = new List<int>();
                    Questions = new List<string>();

                    Get();

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Question : {Answer}");

                    int index = 1;
                    foreach (string question in Questions)
                    {
                        Console.WriteLine($"{index}. {question}"); index++;
                    }
                    Console.WriteLine("5. Refresh");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            {
                                Check(Questions[0]);
                            }
                            break;
                        case "2":
                            {
                                Check(Questions[1]);
                            }
                            break;
                        case "3":
                            {
                                Check(Questions[2]);
                            }
                            break;
                        case "4":
                            {
                                Check(Questions[3]);
                            }
                            break;
                        case "5":
                            {
                                Refresh();
                            }
                            break;
                        default:
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Bad choice value.");
                            }
                            break;
                    }
                }
            });
        }
    }
}
