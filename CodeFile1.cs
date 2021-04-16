using System;
using System.Xml;
using unirest_net.http;

namespace CA_conteroDaniel 
{
    class TestAPI
    {
        static void Main()
        {
            // The idea of implementing this as well as the min steps comes from
            // https://rapidapi.com/blog/how-to-use-an-api-with-c-sharp/
            //var client = Unirest.get("https://gas-price.p.rapidapi.com/europeanCountries");

            HttpResponse<string> response = Unirest.get("https://gas-price.p.rapidapi.com/europeanCountries")
                    .header("x-rapidapi-key", "b5db5ea616msh83542bd61fdd82cp10c4dejsn9d37827493ee")
                    .header("x-rapidapi-host", "gas-price.p.rapidapi.com")
                    //.header("Accept", "application/json")
                    .asJson<string>();

            
            
            
            
            XmlDocument xmlDoc = new XmlDocument(response.());

            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes) 
            {
                Console.WriteLine(node.InnerText);
            }
        }
    }
}