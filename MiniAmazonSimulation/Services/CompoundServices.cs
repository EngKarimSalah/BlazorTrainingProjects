using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Services
{
    public class CompoundServices : ICompoundServices
    {
        private readonly IUserService _userService;
        private readonly IClientService _clientService;
        private readonly ISellerService _sellerService;

        public CompoundServices(IUserService userService, IClientService clientService, ISellerService sellerService)
        {
            _userService = userService;
            _clientService = clientService;
            _sellerService = sellerService;
        }

        public int AddUser(User user)
        {
            int validRegister = _userService.AddUser(user);
            if (validRegister == 1)
            {
                if (user.Role == "Client")
                {
                    Client client = new Client
                    {
                        UserId = user.UId,
                        PhoneNumber = null,
                        Address = null
                    };
                    int validClientAdded = _clientService.AddClient(client);

                    if (validClientAdded == 1)
                    {
                        return 1;
                    }
                    return -1;
                }
                else
                {
                    Seller seller = new Seller
                    {
                        UserId = user.UId,
                        SellerRating = 0
                    };
                    int validSellerAdded = _sellerService.AddSeller(seller);

                    if (validSellerAdded == 1)
                    {
                        return 1;
                    }
                    return -1;
                }

            }
            return -1;
        }

        public void Login(string email, string password) 
        {
            
        }
    }
}
