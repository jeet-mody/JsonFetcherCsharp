//using System;
//using System.Threading.Tasks;

//namespace JsonFetcher
//{
//    class Program
//    {
//        static async Task Main(string[] args)
//        {
//            const string url = "https://jsonplaceholder.typicode.com/todos/1"; // Replace with your JSON URL

//            var jsonParser = new JsonParser();

//            try
//            {
//                string json = await HttpClientService.FetchJsonAsync(url);
//                string formattedJson = jsonParser.FormatJson(json);
//                Console.WriteLine(formattedJson);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"An error occurred: {ex.Message}");
//            }
//        }
//    }
//}

using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace JsonFetcher
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string baseUrl = "https://pokeapi.co/api/v2/pokemon";
            const int limit = 10;
            int offset = 0;

            var jsonParser = new JsonParser();

            try
            {
                while (true)
                {
                    string url = $"{baseUrl}?limit={limit}&offset={offset}";
                    string json = await HttpClientService.FetchJsonAsync(url);
                    var token = JToken.Parse(json);

                    if (token["results"] is JArray pokemonArray)
                    {
                        if (pokemonArray.Count == 0)
                        {
                            break;
                        }

                        foreach (var pokemon in pokemonArray)
                        {
                            string formattedJson = jsonParser.FormatJson(pokemon.ToString());
                            Console.WriteLine(formattedJson);
                        }
                    }

                    offset += limit;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}


