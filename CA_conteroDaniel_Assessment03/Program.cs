using System;

namespace CA_conteroDaniel_Assessment03
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] gradesArray = { 34.7, 56.9, 75, 52, 92.2 };
            double toFind = 56.9;
            string userName;
            int userAge;

            Console.WriteLine("Please press any key to start");
            Console.ReadLine();

            Console.WriteLine($"The lenght of the array is " +
                              $"{GetLenght(gradesArray)}.");
            nextStep();

            LinePrint();
            Console.WriteLine($"The value selected, " +
                $"{getValue(toFind, gradesArray)}, is in the array in the " +
                $"{getIndex(toFind, gradesArray)} position.");
            nextStep();

            LinePrint();
            Console.WriteLine("The following are the values hold in the array.");
            PrintAllValues(gradesArray);
            nextStep();

            userName = GetUsersName();
            userAge = GetUsersAge();

            LinePrint();
            Console.WriteLine($"Your name is {userName} and your are " +
                              $"{userAge} old.");
            nextStep();

            GetUserBirthdate(userName, userAge);

            Console.WriteLine("The program is completed. Please press any key" +
                              " to finish the program");
            Console.ReadKey();
        }

        public static void LinePrint() 
        {
            Console.WriteLine(new string('-', 10));
        }

        public static void nextStep() 
        {
            Console.WriteLine("Please press any key to advance to " +
                              "the next statement.");
            Console.ReadKey();
            Console.Clear();
        }

        public static int GetLenght (double[] array) 
        {
            int lenght = array.Length;
            return lenght;
        }

        public static double getValue(double valueToFind, double[] array) 
        {
            double result;
            result = Array.Find(array, x => x.Equals(valueToFind));
            if (result == valueToFind)
            {
                Console.WriteLine("Number found.");
            }
            else 
            {
                Console.WriteLine("The number doesn't exist in the array.");
            }
            return result;
        }

        public static int getIndex(double valueToFind, double[] array)
        {
            int result;
            result = Array.FindIndex(array, x => x.Equals(valueToFind));

            if (result >= 0)
            {
                Console.WriteLine("Number found.");
            }
            else 
            {
                Console.WriteLine("The number doesn't exist in the array.");
            }
            return result;
        }

        public static void PrintAllValues(double[] array) 
        {
            for (int n = 0; n < array.Length; n++) 
            {
                Console.WriteLine($"The {n} position in the array has a " +
                                  $"value of {array[n]}.");
            }
        }

        public static string GetUsersName() 
        {
            Console.Clear();

            string result = "";
            int count = 0;

            while (count <= 0) 
            {
                Console.WriteLine("Please Introduce your name.");
                result = Console.ReadLine();
                count = result.Length;
                if (count == 0) 
                {
                    Console.WriteLine("You didn't introduce anything.\n");
                }
            }
            return result;
        }

        public static int GetUsersAge() 
        {
            Console.Clear();
            int result = 0;
            bool check = false;
            Console.WriteLine("The programer that develop this program is " +
                              "forcing me to ask you your age.");
            while (check == false) 
            { 
                Console.WriteLine("Please introduce your age with numeric " +
                                  "characters.");
                check = int.TryParse(Console.ReadLine(), out result);
                if (check == false)
                {
                    Console.WriteLine("That's not a number.\n");
                }
                else if (result <= 0)
                {
                    Console.WriteLine("You are not old enough to be using this" +
                                      " software.\n");
                    check = false;
                }
                else if (result >= DateTime.Now.Year) 
                {
                    Console.WriteLine("With due respect, how are you alive?," +
                        " Tell me the secret. C# can't handle your age," +
                        " maybe try someone elses?\n");
                    check = false;
                }
            }
            return result;
        }

        public static void GetUserBirthdate(string name, int age) 
        {
            DateTime result;
            result = DateTime.Now.AddYears(age * -1);
            Console.WriteLine($"{name}, you where born in the year " +
                              $"{result.Year}.\n");
        }
    }
}
