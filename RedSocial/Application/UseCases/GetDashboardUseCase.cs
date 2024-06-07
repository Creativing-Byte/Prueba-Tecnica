using RedSocial.Core.Entities;
using RedSocial.Core.Interfaces;

namespace RedSocial.Application.UseCases
{
    public class GetDashboardUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetDashboardUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<Post> Execute(string username)
        {
            var user = _userRepository.GetByUsername(username);
            if (user == null) return new List<Post>();

            var posts = new List<Post>();
            foreach (var followee in user.Following)
            {
                posts.AddRange(followee.Posts);
            }
            return posts.OrderBy(p => p.Timestamp).ToList();
        }
    }
}
