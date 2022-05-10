using static Quiz.Classes.Work;

class Program
{
    public static void Main()
    {
        MainAsync().GetAwaiter().GetResult();
    }

    private static async Task MainAsync()
    {
        await Start();
    }
}