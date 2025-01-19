using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Data.Repositories
{
    public interface IProductReviewRepo
    {
        int AddReview(ProductReview pr);
        IQueryable<ProductReview> GetReviewsById(int PId);
    }
}