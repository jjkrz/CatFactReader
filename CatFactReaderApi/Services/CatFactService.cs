using CatFactReaderApi.Exceptions;
using CatFactReaderApi.Interfaces;
using CatFactReaderApi.Models;
using System.Text.Json;

namespace CatFactReaderApi.Services
{
    public class CatFactService : ICatFactService
    {
        private readonly HttpClient _httpClient;

        public CatFactService(HttpClient httpClient, ILogger<CatFactService> logger)
        {
            _httpClient = httpClient;
        }

        public async Task<CatFact> GetCatFactAsync()
        {
            var response = await _httpClient.GetAsync("fact");

            if (response == null)
                throw new ExternalApiEmptyResponseException("No cat fact received");

            var fact = JsonSerializer.Deserialize<CatFact>(response.Content.ReadAsStream(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return fact ?? throw new Exception("Deserialization failed");
        }
    }
}
