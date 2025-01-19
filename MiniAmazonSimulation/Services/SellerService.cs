using Microsoft.EntityFrameworkCore;
using MiniAmazonSimulation.Data.Model;
using MiniAmazonSimulation.Data.Repositories;

namespace MiniAmazonSimulation.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepo _sellerRepo;
        public SellerService(ISellerRepo sellerRepo)
        {
            _sellerRepo = sellerRepo;
        }

        public int AddSeller(Seller seller)
        {
            return _sellerRepo.AddSeller(seller);
        }


        public Seller GetSeller(int id)
        {
            return _sellerRepo.GetSeller(id);
        }
    }
}
