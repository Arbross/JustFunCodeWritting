namespace Quiz.Classes
{
    internal static class Methods
    {
        public static int GetRandom(List<int> list)
        {
            if (list == null)
            {
                throw new NullReferenceException();
            }

            Random rnd = new Random();

            int i = rnd.Next(11);
            if (list.Contains(i) && list.Count() < 11)
            {
                while (list.Contains(i))
                {
                    i = rnd.Next(0, 11);
                }
            }

            return i;
        }
    }
}
