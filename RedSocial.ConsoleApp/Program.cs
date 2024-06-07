using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5093/api/SocialNetwork/") };

        while (true)
        {
            Console.Write("> ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;

            var parts = input.Split(' ', 3, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2) continue;

            var command = parts[0].ToLower();
            var username = parts[1];

            switch (command)
            {
                case "post":
                    if (parts.Length < 3) continue;
                    var content = parts[2];
                    var postResponse = await httpClient.PostAsJsonAsync($"post?username={username}&content={content}&timestamp={DateTime.Now}", new { });
                    if (postResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"{username} Posted -> '{content}' a las {DateTime.Now}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {postResponse.StatusCode}");
                        var errorContent = await postResponse.Content.ReadAsStringAsync();
                        Console.WriteLine($"Error details: {errorContent}");
                    }
                    break;

                case "follow":
                    if (parts.Length < 3) continue;
                    var followee = parts[2];
                    var followResponse = await httpClient.PostAsJsonAsync($"follow?followerUsername={username}&followeeUsername={followee}", new { });
                    if (followResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"{username} Empezo a seguir a {followee}");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {followResponse.StatusCode}");
                        var errorContent = await followResponse.Content.ReadAsStringAsync();
                        Console.WriteLine($"Error details: {errorContent}");
                    }
                    break;

                case "dashboard":
                    var response = await httpClient.GetAsync($"dashboard?username={username}");
                    var posts = await response.Content.ReadAsAsync<List<Post>>();
                    foreach (var post in posts)
                    {
                        Console.WriteLine($"{post.Author} Posted -> '{post.Content}' a las {post.Timestamp}");
                    }
                    break;

                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
    }
}

public class Post
{
    public string id { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public DateTime Timestamp { get; set; }
}

public class User
{
    public string Username { get; set; }
}