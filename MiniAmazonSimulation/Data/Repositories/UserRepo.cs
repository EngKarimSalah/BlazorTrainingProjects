using MiniAmazonSimulation.Data.Model;

namespace MiniAmazonSimulation.Data.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _context;
        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public User GetUser(int id)
        {
            return _context.Users.FirstOrDefault(x => x.UId == id);
        }

        public User Login(string email, string password)
        {

            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

    }
}
