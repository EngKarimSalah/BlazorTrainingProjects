using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Data.Repositories
{
    public class ClientRepo : IClientRepo
    {
        private readonly ApplicationDbContext _context;
        public ClientRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddClient(Client client)
        {
            try
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public Client GetUser(int id)
        {
            return _context.Clients.FirstOrDefault(x => x.CId == id);
        }

        public int UpdateClient(Client c)
        {
            try
            {
                Client client = _context.Clients.FirstOrDefault(c => c.CId == c.CId);

                if (client == null)
                {
                    client = c;
                    _context.Clients.Update(client);
                    _context.SaveChanges();

                    return 1;
                }

                return 2;
            }
            catch (Exception ex)
            {
                return -1;

            }
        }
    }
}
