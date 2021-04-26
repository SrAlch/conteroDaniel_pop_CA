using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Linq;
using unirest_net.http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text.Json;

namespace CA_conteroDaniel 
{
    class TestAPI
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
            //List<Gas> results = new List<Gas>();
            public List<Gas> results { get; set; }
        }

        static void HttpRequest()
        {
            var client = Unirest.get("https://gas-price.p.rapidapi.com/europeanCountries");

            HttpResponse<string> response = Unirest.get("https://gas-price.p.rapidapi.com/europeanCountries")
                    .header("x-rapidapi-key", "b5db5ea616msh83542bd61fdd82cp10c4dejsn9d37827493ee")
                    .header("x-rapidapi-host", "gas-price.p.rapidapi.com")
                    //.header("Accept", "application/json")
                    .asJson<string>();

            using JsonDocument doc = JsonDocument.Parse(response.Body);
            JsonElement root = doc.RootElement;
        }

        static void JsonMain()
        {
            string path = @"D:\json\test.json";

            string jsonFromFile;
            using (var reader = new StreamReader(path))
            {
                jsonFromFile = reader.ReadToEnd();
            }

            Result gasListing = JsonConvert.DeserializeObject<Result>(jsonFromFile);
            Console.WriteLine(gasListing.results[0].country);

            List<Gas> objList = gasListing.results;

            foreach (Gas gas in objList)
            {
                Console.WriteLine(gas.country);
                Console.WriteLine(gas.diesel);
            }
            Console.WriteLine(CountryList(objList));


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
            string path = @"D:\json\test.json";
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

       // public static double 


    }   
        
}