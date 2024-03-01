using UserWebAPI.Models;

namespace UserWebAPI.Data.Repository
{
    public interface IUserRepository
    {
        void Insert(User user);
        void Remove(long ID);
        void Update(User user);
        User Get(long ID);
        IList<User> GetAll();
        User GetByMobile(string mobile);
    }
}
