namespace RedSocial.Core.Entities
{
    public class Post
    {
        public string Author { get; private set; }
        public string Content { get; private set; }
        public DateTime Timestamp { get; private set; }

        public Post(User author, string content, DateTime timestamp)
        {
            Author = author.Username;
            Content = content;
            Timestamp = timestamp;
        }
    }
}
