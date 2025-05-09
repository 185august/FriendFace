namespace Interface
{
    public class User
    {
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public List<string> Interests { get; private set; } = new List<string>();
        public List<User> Friends { get; private set; } = new List<User>();
        public User(string? firstName, string? lastName, List<string> interests)
        {
            FirstName = firstName;
            LastName = lastName;
            Interests = interests;
        }
        public void AddUser(User user)
        {
            if (!Friends.Contains(user))
            {
                Friends.Add(user);
            }
            else
            {
                Console.WriteLine($"{user.FirstName} {user.LastName} is already a friend.");
            }
        }
        public void RemoveUser(User user)
        {
            Friends.Remove(user);
        }

    }
}
