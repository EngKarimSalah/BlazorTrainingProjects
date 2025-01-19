
namespace MiniAmazonSimulation.Services
{
    public interface ICountriesService
    {
        Task<List<string>> GetCountriesAsync();
    }
}