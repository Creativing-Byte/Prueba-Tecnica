using RedSocial.Core.Services;

namespace RedSocial.Application.UseCases
{
    public class CreatePostUseCase
    {
        private readonly PostService _postService;

        public CreatePostUseCase(PostService postService)
        {
            _postService = postService;
        }

        public void Execute(string username, string content, DateTime timestamp)
        {
            _postService.CreatePost(username, content, timestamp);
        }
    }
}
