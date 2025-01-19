using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Data.Repositories
{
    public interface IProductRepo
    {
        int AddProduct(Product product);
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
    }
}