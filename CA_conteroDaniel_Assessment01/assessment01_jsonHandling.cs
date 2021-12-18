using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CA_conteroDaniel 
{
    class JsonCall
    {
        public class Gas
        {
            public string currency { get; set; }
            public string lpg { get; set; }
            public string diesel { get; set; }
            public string gasoline { get; set; }
            public string country { get; set; }

        }

        public class Result
        {
            public List<Gas> results { get; set; }
        }
        public static Result JsonProcess(string path) 
        {
            string jsonFromFile;
            using (var reader = new StreamReader(path))
            {
                jsonFromFile = reader.ReadToEnd();
            }

            Result gasListing = JsonConvert.DeserializeObject<Result>(jsonFromFile);
            return gasListing;
        }

        public static List<Gas> GasOBJ()
        {
            string path = @".\CA_conteroDaniel_Assessment01\conteroDaniel_CA_JSONPrices.json";
            List<Gas> objList = JsonProcess(path).results;
            return objList;
        }
        
        public static string[] CountryList(List<Gas> gasList) 
        {
            List<string> countryList = new List<string>();
            foreach (Gas gas in gasList)
            {
                countryList.Add(gas.country.ToString());
            }
            return countryList.ToArray();
        }

        public static double RetrieveApiPrice(List<Gas> gasList,
                                                string country,
                                                string fuelType)
        {
            double fuelPrice = 0;
            foreach (Gas gas in gasList)
            {
                if (gas.country == country)
                {
                    if (fuelType == "gasoline")
                    {
                        double.TryParse(gas.gasoline.Replace(',', '.'),
                                        out fuelPrice);
                    }
                    else 
                    {
                        double.TryParse(gas.diesel.Replace(',', '.'),
                                        out fuelPrice);
                    }
                }
            }
            return fuelPrice;
        }
    }   
        
}