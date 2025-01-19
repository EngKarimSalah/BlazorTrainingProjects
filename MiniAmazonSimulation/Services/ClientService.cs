using Microsoft.AspNetCore.Razor.TagHelpers;
using MiniAmazonSimulation.Data.Model;
using MiniAmazonSimulation.Data.Repositories;

namespace MiniAmazonSimulation.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepo _clientRepo;
        public ClientService(IClientRepo clientRepo)
        {
            _clientRepo = clientRepo;
        }


        public int AddClient(Client client)
        {
            return _clientRepo.AddClient(client);
        }

        public Client GetClient(int id)
        {
            return _clientRepo.GetClient(id);
        }
        public int UpdateClient(Client c)
        {
            return _clientRepo.UpdateClient(c);
        }
    }
}
