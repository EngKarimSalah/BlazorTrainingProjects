using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Data.Repositories
{
    public interface ISellerRepo
    {
        int AddSeller(Seller seller);
        Seller GetSeller(int id);
    }
}