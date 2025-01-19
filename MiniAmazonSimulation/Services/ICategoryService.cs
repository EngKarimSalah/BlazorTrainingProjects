using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
    }
}