using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Data.Repositories
{
    public interface IProductImagesRepo
    {
        int AddImages(List<ProductImages> images);
        ProductImages GetFirstImages(int prid);
        IQueryable<ProductImages> GetImages(int prid);
    }
}