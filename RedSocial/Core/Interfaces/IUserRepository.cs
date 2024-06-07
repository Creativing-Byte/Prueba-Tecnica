using RedSocial.Core.Entities;

namespace RedSocial.Core.Interfaces
{
    public interface IUserRepository
    {
        User GetByUsername(string username);
        void Add(User user);
    }
}
