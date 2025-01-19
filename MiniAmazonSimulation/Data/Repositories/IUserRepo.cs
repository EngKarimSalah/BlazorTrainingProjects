using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Data.Repositories
{
    public interface IUserRepo
    {
        int AddUser(User user);
        User GetUser(int id);
    }
}