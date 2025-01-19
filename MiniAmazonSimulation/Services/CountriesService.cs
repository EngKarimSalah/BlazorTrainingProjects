using System.Net.Http;
using System.Text.Json;

namespace MiniAmazonSimulation.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly HttpClient _httpClient;

        public CountriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<string>> GetCountriesAsync()
        {
            try
            {
                // Make the API call
                var response = await _httpClient.GetAsync("https://localhost:7007/CountriesNames");
                response.EnsureSuccessStatusCode();

                // Read and parse the JSON response
                var content = await response.Content.ReadAsStringAsync();
                var countries = JsonSerializer.Deserialize<List<string>>(content);

                // Return the list of country names
                return countries;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                return new List<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return new List<string>();
            }
        }

    }
}
