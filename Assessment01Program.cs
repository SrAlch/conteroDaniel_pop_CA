using System;


namespace CA_conteroDaniel
{
    class Assessment01Program
    {
        double miles, gallons, mpg, price;
        string input, unitType;
        string apikey = "3d6Mms9i06IQ2Hrcvb3lht:4D99ebw6IAeZEaLuBuKicL";
        static void Main(string[] args)
        {
            var calc = new Assessment01Program();

            Console.WriteLine("Welcome to the Miles per Galon calculator!");
            Console.WriteLine("Please, introduce the amount of Miles");
            calc.miles = TryParseDouble(Console.ReadLine());

            Console.WriteLine("Please, Introduce now the amount of Gallons");
            calc.gallons = TryParseDouble(Console.ReadLine());

            Console.WriteLine($"Are this {calc.gallons} Uk or US Gallons?");
            calc.unitType = Console.ReadLine();

            Console.WriteLine("Is the vehicle Gasoline or Diesel?");
            calc.input = Console.ReadLine();

            calc.mpg = MPGCalculator(calc.miles, calc.gallons);
            calc.price = PriceCalculator(calc.mpg, calc.gallons, calc.input);
            Console.WriteLine($"{calc.price}");
        }

        static double TryParseDouble(string input) 
        {
            double newVal;
            try
            {
                if (double.Parse(input) > 0)
                {
                    newVal = double.Parse(input);
                }
                else 
                {
                    Console.WriteLine("The value need to be greater than 0");
                    newVal = TryParseDouble(Console.ReadLine());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Please insert a valid value");
                newVal = TryParseDouble(Console.ReadLine());
            }
            return newVal;
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
