using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Services
{
    public interface IProductReviewSerice
    {
        int AddReview(ProductReview pr);
        List<ProductReview> GetReviewsById(int PId);
    }
}