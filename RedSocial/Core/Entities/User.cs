namespace RedSocial.Core.Entities
{
    public class User
    {
        public string Username { get; set; }
        public List<User> Following { get; private set; }
        public List<Post> Posts { get; private set; }

        public User(string username)
        {
            Username = username;
            Following = new List<User>();
            Posts = new List<Post>();
        }

        public void Follow(User user)
        {
            if (!Following.Contains(user))
            {
                Following.Add(user);
            }
        }

        public void AddPost(Post post)
        {
            Posts.Add(post);
        }
    }
}
