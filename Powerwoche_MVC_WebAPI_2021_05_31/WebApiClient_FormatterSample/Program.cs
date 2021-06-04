using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebApiClient_FormatterSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string _baseURL = "https://localhost:44305/WeatherForecast/";

            HttpClient client = new();
            //client.DefaultRequestHeaders.Accept.Clear();
            
            //Client fordert das Ergebnis in XML an
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            
            
            
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, _baseURL);
            HttpResponseMessage response = await client.SendAsync(message);
            string xmlText = await response.Content.ReadAsStringAsync();
            Console.WriteLine(xmlText);

            Console.ReadKey();
        }
    }
}
