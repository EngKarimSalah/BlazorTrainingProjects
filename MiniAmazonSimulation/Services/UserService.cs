using MiniAmazonSimulation.Data.Model;
using MiniAmazonSimulation.Data.Repositories;

namespace MiniAmazonSimulation.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public int AddUser(User user)
        {

            return _userRepo.AddUser(user);
        }
        public User GetUser(int id)
        {

            return _userRepo.GetUser(id);
        }

        public User Login(string email, string password)
        {
            return _userRepo.Login(email, password);
        }
    }
}
