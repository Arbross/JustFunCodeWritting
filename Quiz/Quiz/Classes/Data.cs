namespace Quiz.Classes
{
    internal static class Data
    {
        public static Quiz Quiz { get; set; }
        public static string Answer { get; set; }
        public static int Score { get; set; } = 0;
        public static int Number { get; set; } = 1;

        public static List<int> List { get; set; } = new List<int>();
        public static List<string> Questions { get; set; } = new List<string>();

        public static void Refresh()
        {
            Score = 0;
            Number = 1;
        }
    }
}
