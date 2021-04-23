using System;
using System.Linq;

namespace CA_conteroDaniel
{
    class Assessment01Program
    {
        
        double miles, gallons, mpg, price;
        string gasType, unitType, detailLv;
        static void thMain(string[] args)
        {
            var calc = new Assessment01Program();

            calc.detailLv = InputCheck.DetailSelector(Console.ReadLine());

            Console.WriteLine("Welcome to the Miles per Galon calculator!");
            Console.WriteLine("Please, introduce the amount of Miles");
            calc.miles = InputCheck.TryParseDouble(Console.ReadLine());

            Console.WriteLine("Please, Introduce now the amount of Gallons");
            calc.gallons = InputCheck.TryParseDouble(Console.ReadLine());

            Console.WriteLine($"Are this {calc.gallons} gallons" +
                $" Uk or US Gallons?");
            calc.unitType = InputCheck.LocGallons(Console.ReadLine());

            Console.WriteLine("Is the vehicle Gasoline or Diesel?");
            calc.gasType = InputCheck.FuelType(Console.ReadLine());

            Console.WriteLine("Would you like to get an extended conversion " +
                "with more details? Please answer with \"Yes\" or \"No\"");
            calc.detailLv = InputCheck.DetailSelector(Console.ReadLine());
            Console.WriteLine(calc.detailLv);
            
        }
    }
    public class InputCheck
    {

        public static double TryParseDouble(string input)
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

        public static string LocGallons(string input)
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

        public static string FuelType(string input)
        {
            Console.Clear();
            string[] gasList = { "gas", "gasoline" };
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

        public static string DetailSelector(string input)
        {
            Console.Clear();
            input = input.ToLower();
            string[] yesList = { "y", "yes" };
            string[] noList = { "n", "no" };
            string result = null;

            while (Object.ReferenceEquals(result, null))
            {
                try
                {
                    if (yesList.Contains(input))
                    {
                        result = "yes";
                    }
                    else if (noList.Contains(input))
                    {
                        result = "no";
                    }
                    else
                    {
                        throw new Exception("Not the expected input.");
                    }

                }
                catch (Exception nullE)
                {
                    Console.WriteLine(nullE.Message + " Please insert \"Yes\" or \"No\"");
                }
            }
            return result;

        }
    }   
    public class Calculator
    {
        public double MPGCalculator(double mile, double gallon)
        {
            return mile / gallon;   
        }

        public double KmPerLitre(double km, double litre) 
        {
            return km / litre;
        }

        public double LitresConverter(double gallon, string loc) 
        {
            double usGall = 3.785, ukGall = 4.546, result;
            if (loc == "us")
            {
                result = gallon / usGall;
            }
            else 
            {
                result = gallon / ukGall;
            }
            return result;
        }

        public double KmConverter(double mile) 
        {
            return mile / 1.609;
        }

        public double CostPerGallon(double apiPrice, string loc) 
        {
            double usGall = 3.785, ukGall = 4.546, result;
            if (loc == "us")
            {
                result = 1 / usGall * apiPrice;
            }
            else
            {
                result = 1 / ukGall * apiPrice;
            }
            return result;
        }
    }

}
