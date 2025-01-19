using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Services
{
    public interface IClientService
    {
        int AddClient(Client client);
        Client GetClient(int id);
        int UpdateClient(Client c);
    }
}