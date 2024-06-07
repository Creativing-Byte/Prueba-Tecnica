using RedSocial.Core.Entities;
using RedSocial.Core.Services;
using RedSocial.Infrastructure.Repositories;

public class PostServiceTests
{
    [Fact]
    public void User_Can_Create_Post()
    {
        // Arrange
        var userRepository = new InMemoryUserRepository();
        var postRepository = new InMemoryPostRepository();
        var postService = new PostService(postRepository, userRepository);

        var user = new User("@Alfonso");
        userRepository.Add(user);

        var content = "Hola Mundo";
        var timestamp = DateTime.Now;

        // Act
        postService.CreatePost(user.Username, content, timestamp);

        // Assert
        Assert.Single(user.Posts);
        Assert.Equal(content, user.Posts.First().Content);
    }
}