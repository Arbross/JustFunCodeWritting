namespace Quiz.Classes
{
    // Question dictionary array
    internal class Quiz
    {
        private static string[,] Questions { get; set; } = new string[20, 5];
        public static void Fill()
        {
            Questions[0, 0] = "The 2006 World Cup Football Tournament held in";
            Questions[0, 1] = "France";
            Questions[0, 2] = "China";
            Questions[0, 3] = "*Germany";
            Questions[0, 4] = "Brazil";
            //
            Questions[1, 0] = "The 'Black flag' signifies";
            Questions[1, 1] = "revolution/danger";
            Questions[1, 2] = "*protest";
            Questions[1, 3] = "truce";
            Questions[1, 4] = "peace";
            //
            Questions[2, 0] = "Robert Koch worked on";
            Questions[2, 1] = "*tuberculosis";
            Questions[2, 2] = "cholera";
            Questions[2, 3] = "malaria";
            Questions[2, 4] = "diabetes";
            //
            Questions[3, 0] = "The 2002 Commonwealth Games were held in";
            Questions[3, 1] = "*UK";
            Questions[3, 2] = "Canada";
            Questions[3, 3] = "Australia";
            Questions[3, 4] = "Malaysia";
            //
            Questions[4, 0] = "The 2012 Olympics Games were held in";
            Questions[4, 1] = "New York";
            Questions[4, 2] = "Seul";
            Questions[4, 3] = "*London";
            Questions[4, 4] = "Tokyo";
            //
            Questions[5, 0] = "Who is the owner of Marvel Studios";
            Questions[5, 1] = "Warner Bros";
            Questions[5, 2] = "*Walt Disney";
            Questions[5, 3] = "21st Century Fox";
            Questions[5, 4] = "Universal Studios";
            //
            Questions[6, 0] = "Pythagoras was first to ____ the universal validity of geometrical theorem.";
            Questions[6, 1] = "give";
            Questions[6, 2] = "*prove";
            Questions[6, 3] = "both";
            Questions[6, 4] = "None of the above";
            //
            Questions[7, 0] = "Sulphur is not present in";
            Questions[7, 1] = "iron pyrites";
            Questions[7, 2] = "gypsum";
            Questions[7, 3] = "coal";
            Questions[7, 4] = "*chlorapatite";
            //
            Questions[8, 0] = "Oscar Awards were instituted in";
            Questions[8, 1] = "1968";
            Questions[8, 2] = "1901";
            Questions[8, 3] = "1965";
            Questions[8, 4] = "*1929";
            //
            Questions[9, 0] = "Sculpture flourished during";
            Questions[9, 1] = "*Indus valley civilization";
            Questions[9, 2] = "Egyptian civilization";
            Questions[9, 3] = "Chinese civilization";
            Questions[9, 4] = "None of the above";
            //
            Questions[10, 0] = "Penicillin is widely used as";
            Questions[10, 1] = "an insecticide";
            Questions[10, 2] = "an antiseptic";
            Questions[10, 3] = "a disinfectant";
            Questions[10, 4] = "*an antibiotic";
        }

        // Dictionary getter out of array mathods

        public static string GetQuestion(int index)
        {
            if (Questions[1, 0] == null)
            {
                Fill();
            }

            return Questions[index, 0];
        }

        public static string GetAnswer(int indexI, int indexJ)
        {
            if (Questions[1, 0] == null)
            {
                Fill();
            }

            return Questions[indexI, indexJ];
        }
    }
}
