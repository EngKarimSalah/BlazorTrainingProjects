using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Services
{
    public interface ISellerService
    {
        int AddSeller(Seller seller);
        Seller GetSeller(int id);
    }
}