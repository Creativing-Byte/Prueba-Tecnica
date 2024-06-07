using RedSocial.Core.Entities;
using RedSocial.Core.Interfaces;

namespace RedSocial.Core.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User GetUserByUsername(string username)
        {
            return _userRepository.GetByUsername(username);
        }

        public void FollowUser(string followerUsername, string followeeUsername)
        {
            var follower = _userRepository.GetByUsername(followerUsername);
            var followee = _userRepository.GetByUsername(followeeUsername);

            if (follower != null && followee != null)
            {
                follower.Follow(followee);
            }
        }
    }
}
