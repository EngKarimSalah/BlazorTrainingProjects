using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Services
{
    public interface IProductImagesService
    {
        int AddImages(List<ProductImages> images);
        ProductImages GetFirstImages(int prid);
        IEnumerable<ProductImages> GetImages(int prid);
    }
}