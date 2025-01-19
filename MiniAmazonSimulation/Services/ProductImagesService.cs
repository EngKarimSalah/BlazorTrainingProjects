using MiniAmazonSimulation.Data.Model;
using MiniAmazonSimulation.Data.Repositories;

namespace MiniAmazonSimulation.Services
{
    public class ProductImagesService : IProductImagesService
    {
        private readonly IProductImagesRepo _repo;
        public ProductImagesService(IProductImagesRepo repo)
        {
            _repo = repo;
        }

        public int AddImages(List<ProductImages> images)
        {
            return _repo.AddImages(images);
        }
        public ProductImages GetFirstImages(int prid)
        {
            return _repo.GetFirstImages(prid);
        }
        public IEnumerable<ProductImages> GetImages(int prid)
        {
            return GetImages(prid).ToList();
        }
    }
}
