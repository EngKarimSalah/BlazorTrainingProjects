using MiniAmazonSimulation.Data.Model;
using MiniAmazonSimulation.Data.Repositories;

namespace MiniAmazonSimulation.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _repo;
        public ProductService(IProductRepo repo)
        {
            _repo = repo;
        }

        public int AddProduct(Product product)
        {
            return _repo.AddProduct(product);
        }
        public IEnumerable<Product> GetProducts()
        {
            return _repo.GetProducts();
        }
        public Product GetProductById(int id)
        {
            return _repo.GetProductById(id);
        }
    }
}
