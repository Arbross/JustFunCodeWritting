using static Quiz.Classes.Data;
using static Quiz.Classes.Methods;
using static Quiz.Classes.Quiz;

namespace Quiz.Classes.Logic
{
    internal class Reroll
    {
        public static void Get()
        {
            int i = GetRandom(List);
            Answer = GetQuestion(i);

            Questions.Add(GetAnswer(i, 1));
            Questions.Add(GetAnswer(i, 2));
            Questions.Add(GetAnswer(i, 3));
            Questions.Add(GetAnswer(i, 4));

            if (Questions[0].StartsWith("*"))
            {
                Answer = Questions[0].Substring(1, Questions[0].Length - 1);
                Questions[0] = Questions[0].Substring(1, Questions[0].Length - 1);
            }
            else
            {
                if (Questions[1].StartsWith("*"))
                {
                    Answer = Questions[1].Substring(1, Questions[1].Length - 1);
                    Questions[1] = Questions[1].Substring(1, Questions[1].Length - 1);
                }
                else
                {
                    if (Questions[1].StartsWith("*"))
                    {
                        Answer = Questions[2].Substring(1, Questions[2].Length - 1);
                        Questions[2] = Questions[2].Substring(1, Questions[2].Length - 1);
                    }
                    else
                    {
                        Answer = Questions[3].Substring(1, Questions[3].Length - 1);
                        Questions[3] = Questions[3].Substring(1, Questions[3].Length - 1);
                    }
                }
            }

            List.Add(i);
        }
    }
}
