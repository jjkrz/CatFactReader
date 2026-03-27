using CatFactReader.Models;
using System.Text.Json;

namespace CatFactReader.Services
{
    public class CatFactService
    {
        private readonly HttpClient _httpClient;

        public CatFactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CatFact> GetCatFactAsync()
        {
            var response = await _httpClient.GetAsync("https://catfact.ninja/fact");

            var fact = JsonSerializer.Deserialize<CatFact>(response.Content.ReadAsStream(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (fact == null)
            {
                throw new Exception("Failed to deserialize cat fact.");
            }

            Console.WriteLine($"Fact: {fact.Fact}, {fact.Length}");

            return fact;
        }
    }
}
