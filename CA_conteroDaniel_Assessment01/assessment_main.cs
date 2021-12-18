using System;
using System.Linq;
using ConsoleTables;

namespace CA_conteroDaniel
{
    class assessment_main
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Miles per Galon calculator!");
            Console.WriteLine("Please press any key to start...");
            Console.ReadKey();
            Console.Clear();
            if (GetInfo.GetDetailLevel() == "yes")
            {
                TableFront.TableGenExtent();
            }
            else 
            {
                TableFront.TableGenMin();
            }
        }
    }

    public class TableFront
    {
        public static string[] HeadFormat()
        {
            string[] headersTable = {"Distance",
                                    "Amount Fuel",
                                    "Total Price",
                                    "Fuel Performance",
                                    "Price per Unit" };
            return headersTable;
        }
        public static void TableGenExtent() 
        {
            var headersTable = HeadFormat();
            var mpgTable = InfoAssemble.MPGAssemble();
            var kmlTable = InfoAssemble.KMLAssemble(mpgTable);
            Console.WriteLine($"{mpgTable[0]}        " +
                $"{mpgTable[2].First().ToString().ToUpper()}{mpgTable[2][1..]}");
            var table = new ConsoleTable(headersTable);
            table.AddRow(mpgTable[4] + " Miles",
                         mpgTable[5] + " " + mpgTable[1].ToUpper() + " Gal.",
                         mpgTable[6] + " EUR",
                         mpgTable[7] + " Miles/Gal.",
                         mpgTable[8] + " EUR/Gal.")
                .AddRow(kmlTable[4] + " Km",
                        kmlTable[5] + " Ltr.",
                        kmlTable[6] + " EUR",
                        kmlTable[7] + " Km/L",
                        kmlTable[8] + " EUR/L")
                .Write(Format.Alternative);   
        }
        public static void TableGenMin() 
        {
            var headersTable = HeadFormat();
            var mpgTable = InfoAssemble.MPGAssemble();
            Console.WriteLine($"{mpgTable[0]}        {mpgTable[2]}");
            var table = new ConsoleTable(headersTable);
            table.AddRow(mpgTable[4] + " Miles",
                         mpgTable[5] + mpgTable[1] + " Gal.",
                         mpgTable[6] + " EUR",
                         mpgTable[7] + " Miles/Gal.",
                         mpgTable[8] + " EUR/Gal.")
                .Write(Format.Alternative);
        }
    }

    public class InfoAssemble 
    {
        public static string[] MPGAssemble() 
        {
            string[] info = new string[9];
            info[0] = GetInfo.GetCountry();
            info[4] = GetInfo.GetMiles().ToString();
            info[5] = GetInfo.GetGallons().ToString();
            info[1] = GetInfo.GetGallLoc(double.Parse(info[5]));
            info[2] = GetInfo.GetFuelType();
            info[3] = APIGathering.ApiPrice(info[0], info[2]).ToString();
            info[6] = GetInfo.GetPriceTotalGallon(double.Parse(info[5]),
                                                  double.Parse(info[3]),
                                                  info[1]).ToString();
            info[7] = Calculator.MPGCalculator(double.Parse(info[4]),
                                               double.Parse(info[5])).ToString();
            info[8] = Calculator.CostPerGallon(double.Parse(info[3]), 
                                               info[1]).ToString();
            
            return info;
        }

        public static string[] KMLAssemble(string[] origing) 
        {
            string[] info = new string[9];
            info[0] = origing[0];
            info[1] = origing[1];
            info[2] = origing[2];
            info[3] = origing[3];
            info[4] = Calculator.KmConverter(double.Parse(origing[4])).ToString();
            info[5] = Calculator.LitresConverter(double.Parse(origing[5]),
                                                    origing[1]).ToString();
            info[6] = Calculator.CostTotalLitre(double.Parse(info[3]),
                                                double.Parse(info[5])).ToString();
            info[7] = Calculator.KmPerLitre(double.Parse(info[4]),
                                            double.Parse(info[5])).ToString();
            info[8] = origing[3];

            return info;
        }
    }

    public class GetInfo 
    {
        public static double GetMiles() 
        {
            Console.WriteLine("Please, introduce the amount of Miles");
            return InputCheck.TryParseDouble(Console.ReadLine());
        }
        public static double GetGallons() 
        {
            Console.WriteLine("Please, Introduce now the amount of Gallons");
            return InputCheck.TryParseDouble(Console.ReadLine());
        }
        public static string GetGallLoc(double gallon) 
        {
            Console.WriteLine($"Are this {gallon} gallons" +
                $" Uk or US Gallons?");
            return InputCheck.LocGallons(Console.ReadLine());
        }
        public static string GetFuelType() 
        {
            Console.WriteLine("Is the vehicle Gasoline or Diesel?");
            return InputCheck.FuelType(Console.ReadLine());
        }
        public static string GetDetailLevel() 
        {
            Console.WriteLine("Would you like to get an extended conversion " +
                    "with more details? Please answer with \"Yes\" or \"No\"");
            return InputCheck.DetailSelector(Console.ReadLine());
        }
        public static string GetCountry() 
        {
            int result=0;
            Console.WriteLine("Please select the country where you purchased" +
                " the fuel. Use a number, not the name.");
            string[] cntryList = APIGathering.APICountry();
            while (!(result >= 0 && result <= cntryList.Length))
            {
                for (int n = 0; n < cntryList.Length; n++)
                {
                    Console.WriteLine($"{n}. {cntryList[n]}");
                }
                result = InputCheck.TryParseInt(Console.ReadLine(), cntryList.Length);
            }
            return cntryList[result];
        }
        public static double GetPriceTotalGallon(double gallon, 
                                                 double literPrice, string loc)
        {
            double price = Calculator.CostPerGallon(literPrice, loc);
            return gallon*price;
        }
    }


    public class InputCheck
    {
        public static int TryParseInt(string input, int lenght)
        {
            Console.Clear();
            int result = 0;
            while (result == 0)
            {
                try
                {
                    if (int.Parse(input) >= 0 && int.Parse(input) < lenght)
                    {
                        result = int.Parse(input);
                    }
                    else
                    {
                        throw new Exception("Invalid Input");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + $" The value need to be " +
                        $"between 0 and {lenght-1}. Please insert a valid number.");
                    GetInfo.GetCountry();
                }
            }
            return result;
        }

        public static double TryParseDouble(string input)
        {
            Console.Clear();
            double result = 0;
            while (result == 0)
            {
                try
                {
                    if (double.Parse(input) > 0)
                    {
                        result = double.Parse(input);
                    }
                    else
                    {
                        throw new Exception("Invalid Input");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + " The value need to be " +
                        "greater than 0. Please insert a valid number.");
                    result = TryParseDouble(Console.ReadLine());
                }
            }
            return result;
        }

        public static string LocGallons(string input)
        {
            Console.Clear();
            string result = null;
            while (Object.ReferenceEquals(result, null))
            {
                try
                {
                    if (input.ToLower() == "uk" || input.ToLower() == "us")
                    {
                        result = input.ToLower();
                    }
                    else
                    {
                        throw new Exception("Wrong input!");
                    }
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e.Message + " Please introduce a valid " +
                        "value, the options are \"Uk\" or \"Us\"");
                    result = LocGallons(Console.ReadLine());
                }
            }
            return result;
        }

        public static string FuelType(string input)
        {
            Console.Clear();
            string[] gasList = { "gas", "gasoline" };
            string[] oilList = { "diesel", "gasoil", "gas oil" };
            string result = null;
            input = input.ToLower();

            while (Object.ReferenceEquals(result, null))
            {
                try
                {
                    if (gasList.Contains(input))
                    {
                        result = "gasoline";
                    }
                    else if (oilList.Contains(input))
                    {
                        result = "diesel";
                    }
                    else
                    {
                        throw new Exception("Invalid input!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + " Please introduce a " +
                        "correct value for \"Gasoline\" or \"Diesel\" fuel");
                    result = FuelType(Console.ReadLine());
                }
            }
            return result;

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
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + 
                        " Please insert \"Yes\" or \"No\"");
                    result = DetailSelector(Console.ReadLine());
                }
            }
            return result;

        }
    }   
    public class Calculator
    {
        public static double MPGCalculator(double mile, double gallon)
        {
            return Math.Round(mile / gallon, 2, MidpointRounding.ToEven);
        }

        public static double KmPerLitre(double km, double litre) 
        {
            return Math.Round(km / litre, 2, MidpointRounding.ToEven);
        }

        public static double LitresConverter(double gallon, string loc) 
        {
            double usGall = 3.785, ukGall = 4.546, result;
            if (loc == "us")
            {
                result = gallon * usGall;
            }
            else 
            {
                result = gallon * ukGall;
            }
            return Math.Round(result, 2, MidpointRounding.ToEven);
        }

        public static double KmConverter(double mile) 
        {
            return Math.Round(mile * 1.60934, 2, MidpointRounding.ToEven);
        }

        public static double CostPerGallon(double apiPrice, string loc) 
        {
            double usGall = 3.785, ukGall = 4.546, result;
            if (loc == "us")
            {
                result = usGall * apiPrice;
            }
            else
            {
                result = ukGall * apiPrice;
            }
            return Math.Round(result, 2, MidpointRounding.ToEven);
        }

        public static double CostTotalLitre(double apiPrice, double liters) 
        {
            return Math.Round(apiPrice * liters, 2, MidpointRounding.ToEven);
        }
    }
    public class APIGathering
    {
        public static double ApiPrice(string country, string gasType) 
        {
            double price = JsonCall.RetrieveApiPrice(JsonCall.GasOBJ(),
                                                    country,
                                                    gasType);
            return price;
        }

        public static string[] APICountry()
        {
            string[] result = JsonCall.CountryList(JsonCall.GasOBJ());

            return result;
        }
    }

}
