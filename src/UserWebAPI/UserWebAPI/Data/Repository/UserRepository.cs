using UserWebAPI.Models;

namespace UserWebAPI.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDBContext _context;

        public UserRepository(UserDBContext context)
        {
            _context = context;
        }

        public User Get(long ID)
        {
            return _context.User.Find(ID);
        }

        public IList<User> GetAll()
        {
            return _context.User.ToList();
        }

        public User GetByMobile(string mobile)
        {
            return _context.User.FirstOrDefault(x => x.Mobile == mobile);
        }

        public void Insert(User user)
        {
            user.CreationDate = DateTime.Now;
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Remove(long ID)
        {
            var user = Get(ID);
            if (user != null)
            {
                _context.Remove(user);
            }
        }

        public void Update(User user)
        {
            user.LastUpdateDate = DateTime.Now;
            _context.Update(user);
        }
    }
}
