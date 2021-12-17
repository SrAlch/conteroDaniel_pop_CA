using System;

namespace CA_conteroDaniel_Assessment02
{
    class Program
    {
        static void Main(string[] args)
        {
            IntroMsg();
        }
        public static void IntroMsg()
        {
            Console.WriteLine("Welcome to Guess Game: The adventure of the guess");
            Console.WriteLine("Please press any key to start...");
            Console.ReadKey();
            Console.Clear();
            MenuSelect();
        }

        public static int MainMenu()
        {
            int result = 0;
            bool check = false;

            while (check == false)
            {
                Console.Clear();
                Console.WriteLine("Guess Game: The adventure of the guess\n\n");
                Console.WriteLine("     Main Menu - (Enter the number to select)\n");
                Console.WriteLine("1. New Game");
                Console.WriteLine("2. Credits");
                Console.WriteLine("0. Exit");

                check = int.TryParse(Console.ReadLine(), out result);
                if (!(result >= 0 && result <= 3))
                {
                    check = false;
                }
            }

            return result;
        }

        public static void MenuSelect()
        {
            int selection = MainMenu();

            switch (selection)
            {
                case (0):
                    ExitGame();
                    break;
                case (1):
                    StartGame();
                    break;
                case (2):
                    ShowCredits();
                    break;
                default:
                    break;
            }
        }

        public static void StartGame()
        {
            int scrtNum;
            string player01 = "Player 01", player02 = "Player 02";
            player01 = GetPlayerName(player01);
            player02 = GetPlayerName(player02);
            scrtNum = GetSecretNumber(player01);
            GessGame(player01, player02, scrtNum);
        }


        public static void ShowCredits()
        {
            Console.Clear();
            Console.WriteLine("             The Great Game Company\n\n");
            Console.WriteLine("Executive producer          Amber(My Cat)\n" +
                              "Main Software Engineer      Le Me (Im still learning)\n" +
                              "Level Designer              I guess the lecture :D\n" +
                              "Marketing                   Was fired, wanted to add images to the console(Duuh)\n\n" +
                              "             All the rights reserved ©\n\n");
            Console.WriteLine("Please press any key to come back to the menu ...");
            Console.ReadKey();
            MenuSelect();
        }
        public static void ExitGame()
        {
            Console.Clear();
            Console.WriteLine("I hope you had a good time. See you soon!");
        }

        public static string GetPlayerName(string user)
        {
            string result = null;
            Console.Clear();
            while (String.IsNullOrWhiteSpace(result) == true)
            {
                Console.WriteLine($"{user}, please introduce your name.");
                result = Console.ReadLine();
            }
            return result;
        }

        public static int GetSecretNumber(string name)
        {
            int result = -1;
            bool check = false;

            while (check == false)
            {
                Console.WriteLine($"{name}, choose a number between 0 and 20" +
                    $" (Press enter once is typed)");
                var pass = string.Empty;
                ConsoleKey key;
                do
                {
                    var keyInfo = Console.ReadKey(intercept: true);
                    key = keyInfo.Key;

                    if (key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        Console.Write("\b \b");
                        pass = pass[0..^1];
                    }
                    else if (!char.IsControl(keyInfo.KeyChar))
                    {
                        Console.Write("*");
                        pass += keyInfo.KeyChar;
                    }
                } while (key != ConsoleKey.Enter);

                check = int.TryParse(pass, out result);

                if (check == false)
                {
                    Console.Clear();
                    Console.WriteLine($"It needs to be a number");
                }
                if (!(result >= 0 && result <= 20))
                {
                    Console.Clear();
                    Console.WriteLine($"The number it's outside the range");
                    check = false;
                }
            }
            return result;
        }

        public static void GessGame(string name01, string name02, int secretNumber)
        {
            int attempts = 3, input = 0;
            bool check = false;
            Console.Clear();

            for (int n = 0; n < 3; n++)
            {
                
                Console.WriteLine($"{name02} what number do you think it is");
                while (check == false)
                {
                   
                    check = int.TryParse(Console.ReadLine(), out input);
                    Console.Clear();
                    if (check == false)
                    {
                        
                        Console.WriteLine($"It needs to be a number");
                    }
                    if (!(input >= 0 && input <= 20))
                    {
                       
                        Console.WriteLine($"The number it's outside the range");
                        check = false;
                    }
                }


                if (input == secretNumber)
                {
                    Console.WriteLine("Congratulations");
                    n = 3;
                }
                else
                {
                    Console.Write("That was wrong.");
                    attempts--;
                    if (input < secretNumber)
                    {
                        Console.Write(" The guess is too low.");
                    }
                    else
                    {
                        Console.Write(" The guess is too high.");
                    }
                    Console.WriteLine($"\nYou have {attempts} attempts left");
                    check = false;
                    
                }
            }

            if (input != secretNumber)
            {
                Console.WriteLine($"Hard luck the number was {secretNumber}");
            }
            else
            {
                Console.WriteLine($"{name02}, you won the game");
            }

        }

    }
}
