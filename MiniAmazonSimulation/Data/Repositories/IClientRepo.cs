using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Data.Repositories
{
    public interface IClientRepo
    {
        int AddClient(Client client);
        Client GetUser(int id);
        int UpdateClient(Client c);
    }
}