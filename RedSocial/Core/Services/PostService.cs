using RedSocial.Core.Entities;
using RedSocial.Core.Interfaces;

namespace RedSocial.Core.Services
{
    public class PostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public PostService(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public void CreatePost(string username, string content, DateTime timestamp)
        {
            var user = _userRepository.GetByUsername(username);
            if (user != null)
            {
                var post = new Post(user, content, timestamp);
                _postRepository.Add(post);
                user.AddPost(post);
            }
        }
    }
}
