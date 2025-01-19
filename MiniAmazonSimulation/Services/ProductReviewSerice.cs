using MiniAmazonSimulation.Data.Model;
using MiniAmazonSimulation.Data.Repositories;

namespace MiniAmazonSimulation.Services
{
    public class ProductReviewSerice : IProductReviewSerice
    {
        private readonly IProductReviewRepo _repo;
        public ProductReviewSerice(IProductReviewRepo repo)
        {
            _repo = repo;
        }

        public int AddReview(ProductReview pr)
        {
            return _repo.AddReview(pr);
        }
        public List<ProductReview> GetReviewsById(int PId)
        {
            return _repo.GetReviewsById(PId).ToList();
        }
    }
}
