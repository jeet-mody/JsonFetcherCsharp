using System.Net.Http;
using System.Threading.Tasks;

namespace JsonFetcher
{
    public static class HttpClientService
    {
        public static async Task<string> FetchJsonAsync(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
