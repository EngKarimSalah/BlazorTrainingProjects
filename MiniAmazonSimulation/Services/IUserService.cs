using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Services
{
    public interface IUserService
    {
        int AddUser(User user);
        User GetUser(int id);
    }
}