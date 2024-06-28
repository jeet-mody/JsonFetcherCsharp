using System;
using System.Threading.Tasks;

namespace JsonFetcher
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string url = "https://jsonplaceholder.typicode.com/todos/1"; // Replace with your JSON URL

            var jsonParser = new JsonParser();

            try
            {
                string json = await HttpClientService.FetchJsonAsync(url);
                string formattedJson = jsonParser.FormatJson(json);
                Console.WriteLine(formattedJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
