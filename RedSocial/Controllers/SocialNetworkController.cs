using Microsoft.AspNetCore.Mvc;
using RedSocial.Application.UseCases;
using RedSocial.Core.Entities;
using System.Text.Json;

namespace RedSocial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocialNetworkController : ControllerBase
    {
        private readonly CreatePostUseCase _createPostUseCase;
        private readonly FollowUserUseCase _followUserUseCase;
        private readonly GetDashboardUseCase _getDashboardUseCase;

        public SocialNetworkController(
            CreatePostUseCase createPostUseCase,
            FollowUserUseCase followUserUseCase,
            GetDashboardUseCase getDashboardUseCase)
        {
            _createPostUseCase = createPostUseCase;
            _followUserUseCase = followUserUseCase;
            _getDashboardUseCase = getDashboardUseCase;
        }

        [HttpPost("post")]
        public IActionResult PostMessage(string username, string content, DateTime timestamp)
        {
            try
            {
                _createPostUseCase.Execute(username, content, timestamp);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("follow")]
        public IActionResult FollowUser(string followerUsername, string followeeUsername)
        {
            try
            {
                _followUserUseCase.Execute(followerUsername, followeeUsername);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

        [HttpGet("dashboard")]
        public IActionResult GetDashboard(string username)
        {
            try
            {
                var posts = _getDashboardUseCase.Execute(username);
                return Ok(posts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
