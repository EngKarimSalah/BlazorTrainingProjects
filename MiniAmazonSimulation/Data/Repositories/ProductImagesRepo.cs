using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Data.Repositories
{
    public class ProductImagesRepo : IProductImagesRepo
    {
        private readonly ApplicationDbContext _context;
        public ProductImagesRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddImages(List<ProductImages> images)
        {
            try
            {
                _context.ProductImages.AddRange(images);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public IQueryable<ProductImages> GetImages(int prid)
        {
            return _context.ProductImages.Where(images => images.ProductId == prid);
        }

        public ProductImages GetFirstImages(int prid)
        {
            return _context.ProductImages.FirstOrDefault(images => images.ProductId == prid);
        }
    }
}
