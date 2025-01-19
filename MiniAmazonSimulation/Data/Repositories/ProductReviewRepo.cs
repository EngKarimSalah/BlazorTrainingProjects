using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Data.Repositories
{
    public class ProductReviewRepo : IProductReviewRepo
    {
        private readonly ApplicationDbContext _context;
        public ProductReviewRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddReview(ProductReview pr)
        {
            try
            {
                _context.ProductReviews.Add(pr);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public IQueryable<ProductReview> GetReviewsById(int PId)
        {
            return _context.ProductReviews.Where(r => r.ProductId == PId);

        }

    }
}
