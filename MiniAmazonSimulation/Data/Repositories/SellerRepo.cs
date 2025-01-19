using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Data.Repositories
{
    public class SellerRepo : ISellerRepo
    {
        private readonly ApplicationDbContext _context;
        public SellerRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddSeller(Seller seller)
        {
            try
            {
                _context.Sellers.Add(seller);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public Seller GetSeller(int id)
        {
            return _context.Sellers.FirstOrDefault(s => s.SId == id);
        }
    }
}
