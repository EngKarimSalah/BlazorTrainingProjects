using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Services
{
    public interface IProductService
    {
        int AddProduct(Product product);
        Product GetProductById(int id);
        IEnumerable<Product> GetProducts();
    }
}