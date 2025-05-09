namespace Interface
{
    public static class UserInterface
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("1. Add Friend");
            Console.WriteLine("2. Remove Friend");
            Console.WriteLine("3. Display All Friends");
            Console.WriteLine("4. Display interests of a friend");
            Console.WriteLine("5. Exit");
        }
        public static void DisplayAllUsers(List<User> users)
        {
            int i = 1;
            foreach (var user in users)
            {
                Console.WriteLine($"{i}: {user.FirstName} {user.LastName}");
                i++;
            }
        }
        public static string? GetValidEntry(string? input)
        {
            while (true)
            {
                Console.WriteLine(input);
                input = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                Console.WriteLine("Invalid input, please try again");
            }
        }
        public static int GetValidChoice(int maxOption)
        {
            int choice;
            while (true)
            {
                Console.WriteLine($"Please enter a number between 1 and {maxOption}:");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= maxOption)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }
        public static void DisplayAllFriends(User currentUser)
        {
            if (!CheckIfUserHasAnyFriends(currentUser))
            {
                Console.WriteLine("You do not have any friends");
                return;
            }
            Console.WriteLine("Your friends:");
            var i = 1;
            foreach (var friend in currentUser.Friends)
            {
                Console.WriteLine($"{i}: {friend.FirstName} {friend.LastName}");
                i++;
            }
        }

        public static bool CheckIfUserHasAnyFriends(User currentUser)
        {
            return currentUser.Friends.Count > 0;
        }
        public static User SelectFriend(User currentUser)
        {
            if (!CheckIfUserHasAnyFriends(currentUser)) return null!;
            DisplayAllFriends(currentUser);
            int index = GetValidChoice(currentUser.Friends.Count);
            return currentUser.Friends[index - 1];
        }
    }
}
