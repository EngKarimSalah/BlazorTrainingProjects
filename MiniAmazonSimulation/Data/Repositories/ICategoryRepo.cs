using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Data.Repositories
{
    public interface ICategoryRepo
    {
        IEnumerable<Category> GetAll();
    }
}