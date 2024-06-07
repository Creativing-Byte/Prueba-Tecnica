using RedSocial.Core.Entities;
using RedSocial.Core.Interfaces;

namespace RedSocial.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public User GetByUsername(string username)
        {
            if (_users.Count < 3)
            {
                _users.Add(new User("@Alicia"));
                _users.Add(new User("@Alfonso"));
                _users.Add(new User("@Ivan"));
            }
            return _users.FirstOrDefault(u => u.Username == username);
        }

        public void Add(User user)
        {
            _users.Add(user);
        }
    }
}
