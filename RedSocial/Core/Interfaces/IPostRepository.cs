using RedSocial.Core.Entities;

namespace RedSocial.Core.Interfaces
{
    public interface IPostRepository
    {
        void Add(Post post);
        List<Post> GetByUser(User user);
    }
}
