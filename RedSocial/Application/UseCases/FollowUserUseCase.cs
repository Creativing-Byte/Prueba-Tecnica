using RedSocial.Core.Services;

namespace RedSocial.Application.UseCases
{
    public class FollowUserUseCase
    {
        private readonly UserService _userService;

        public FollowUserUseCase(UserService userService)
        {
            _userService = userService;
        }

        public void Execute(string followerUsername, string followeeUsername)
        {
            _userService.FollowUser(followerUsername, followeeUsername);
        }
    }
}
