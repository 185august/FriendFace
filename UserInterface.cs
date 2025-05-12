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

        public static void DisplayFriendList(User currentUser)
        {
            var friends = currentUser.ListOfFriends();
            if (friends == null)
            {
                Console.WriteLine("You have no friends to display.");
                return;
            }
            for (var i = 0; i < friends.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {friends[i]}");
            }
        }
        
    }
}
