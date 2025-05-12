using System.Diagnostics;

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
                Friends.Add(user);
            else
                Console.WriteLine($"{user.FirstName} {user.LastName} is already a friend.");
        }
        public void RemoveUser(User user)
        {
            Friends.Remove(user);
        }
        
        public List<string>? ListOfFriends()
        {
            if (!CheckIfUserHasAnyFriends())
                return null;
            
            Console.WriteLine("Your friends:");
            return Friends.Select(friend => $"{friend.FirstName} {friend.LastName}").ToList();
        }

        public bool CheckIfUserHasAnyFriends() => 
            Friends.Count > 0;
        
        public User SelectFriend(int index) => 
            Friends[index - 1];
    }
}
