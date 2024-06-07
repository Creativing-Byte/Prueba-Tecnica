using RedSocial.Core.Entities;
using RedSocial.Core.Interfaces;

namespace RedSocial.Infrastructure.Repositories
{
    public class InMemoryPostRepository : IPostRepository
    {
        private readonly List<Post> _posts = new();

        public void Add(Post post)
        {
            _posts.Add(post);
        }

        public List<Post> GetByUser(User user)
        {
            return _posts.Where(p => p.Author == user.Username).ToList();
        }
    }
}
