using RedSocial.Core.Entities;
using RedSocial.Core.Services;
using RedSocial.Infrastructure.Repositories;

namespace RedSocial.Tests;

public class UserServiceTests
{
    [Fact]
    public void User_Can_Follow_Other_User()
    {
        // Arrange
        var userRepository = new InMemoryUserRepository();
        var userService = new UserService(userRepository);

        var follower = new User("@Alicia");
        var followee = new User("@Ivan");

        userRepository.Add(follower);
        userRepository.Add(followee);

        // Act
        userService.FollowUser(follower.Username, followee.Username);

        // Assert
        Assert.Contains(followee, follower.Following);
    }
}