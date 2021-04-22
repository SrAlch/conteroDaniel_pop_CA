using System;
using System.Linq;

namespace CA_conteroDaniel
{
    class Assessment01Program
    {
        double miles, gallons, mpg, price;
        string gasType, unitType, detailLv;
        string apikey = "3d6Mms9i06IQ2Hrcvb3lht:4D99ebw6IAeZEaLuBuKicL";
        static void Main(string[] args)
        {
            var calc = new Assessment01Program();

            Console.WriteLine("Welcome to the Miles per Galon calculator!");
            Console.WriteLine("Please, introduce the amount of Miles");
            calc.miles = TryParseDouble(Console.ReadLine());

            Console.WriteLine("Please, Introduce now the amount of Gallons");
            calc.gallons = TryParseDouble(Console.ReadLine());

            Console.WriteLine($"Are this {calc.gallons} gallons" +
                $" Uk or US Gallons?");
            calc.unitType = LocGallons(Console.ReadLine());

            Console.WriteLine("Is the vehicle Gasoline or Diesel?");
            calc.gasType = FuelType(Console.ReadLine());
            Console.WriteLine("Would you like to get an extended conversion " +
                "with more details? Please answer with \"Yes\" or \"No\"");
            calc.detailLv = DetailSelector(Console.ReadLine());
        }

        static double TryParseDouble(string input) 
        {
            Console.Clear();
            double newVal;
            try
            {
                if (double.Parse(input) > 0)
                {
                    newVal = double.Parse(input);
                }
                else 
                {
                    Console.WriteLine("The value need to be greater than 0." +
                        " Please insert a valid number.");
                    newVal = TryParseDouble(Console.ReadLine());
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message + " Please insert a valid value.");
                newVal = TryParseDouble(Console.ReadLine());
            }
            return newVal;
        }

        static string LocGallons(string input) 
        {
            Console.Clear();
            if (input.ToLower() == "uk" || input.ToLower() == "us")
            {
                return input.ToLower();
            }
            else 
            {
                Console.WriteLine("Please introduce a valid value, " +
                    "the options are \"Uk\" or \"Us\"");
                return LocGallons(Console.ReadLine());
            }
        }

        static string FuelType(string input) 
        {
            Console.Clear();
            string[] gasList = {"gas","gasoline"};
            string[] oilList = { "diesel", "gasoil", "gas oil" };
            input = input.ToLower();

            if (gasList.Contains(input))
            {
                return "gas";
            }
            else if (oilList.Contains(input))
            {
                return "oil";
            }
            else 
            {
                Console.WriteLine("Please introduce a correct value for" +
                    " \"Gasoline\" or \"Diesel\" fuel");
                return FuelType(Console.ReadLine());
            }

        }

        static string DetailSelector(string input) 
        {
            Console.Clear();
            input = input.ToLower();
            string[] yesList = { "y", "yes" };
            string[] noList = { "n", "no" };

            try
            {
                if (yesList.Contains(input))
                {
                    return "yes";
                }
                else if (noList.Contains(input))
                {
                    return "no";
                }
                else 
                {
                    return;
                }
            }
            catch (ArgumentNullException nullE) 
            {
                Console.WriteLine(nullE + " Please insert \"Yes\" or \"No\"");
                return DetailSelector(Console.ReadLine());
            }
      
        }
        
        static double MPGCalculator(double mileIN, double gallonIN)
        {
            return mileIN / gallonIN;   
        }

        static double PriceCalculator(double totalMPG, double totalGall, 
                                      string carAnsw) 
        {
            double price = 6.62;
            try
            {
                price = OnlinePriceCatch();
                return price;
            }
            catch 
            {
                return price;
            }
        }

        static double OnlinePriceCatch() 
        {
            
            double onlinePrice;
            onlinePrice = 10 + 1;
            return onlinePrice;
        }
    }

}
