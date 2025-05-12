using Interface;

var allUsers = InitializeUsers();
var currentUser = CreateUser();


while (true)
{
    Console.Clear();
    UserInterface.DisplayMenu();
    var keyInfo = Console.ReadKey(true);
    var choice = keyInfo.KeyChar;
    switch (choice)
    {
        case '1':
            AddFriendFlow(currentUser, allUsers);
            break;
        case '2':
            RemoveFriendFlow(currentUser);
            break;
        case '3':
            UserInterface.DisplayFriendList(currentUser);
            break;
        case '4':
            DisplayInterestsFlow(currentUser);
            break;
        default:
            Console.WriteLine("Exiting...");
            return;
    }

    WaitForKeyPress();
}


static List<User> InitializeUsers()
{
    return
    [
        new User("John", "Doe", ["Reading", "Hiking"]),
        new User("Jane", "Smith", ["Cooking", "Traveling"]),
        new User("Alice", "Johnson", ["Photography", "Gardening"]),
        new User("Bob", "Brown", ["Gaming", "Music"]),
        new User("Charlie", "Davis", ["Sports", "Movies"]),
        new User("Diana", "Wilson", ["Art", "Fitness"]),
        new User("Ethan", "Garcia", ["Technology", "Writing"])
    ];
}

static User CreateUser()
{
    var firstName = UserInterface.GetValidEntry("Enter first name:");
    var lastName = UserInterface.GetValidEntry("Enter last name:");
    var interests = new List<string>();
    while (interests.Count == 0)
    {
        string? input = UserInterface.GetValidEntry("Enter interest:");
        var listInput = input.Split(',').Select(x => x.Trim()).ToList();
        if (listInput.Count != 0)
        {
            interests = listInput;
        }
    }

    return new User(firstName, lastName, interests);
}

static void AddFriendFlow(User currentUser, List<User> users)
{
    Console.WriteLine("Select a user to add as a friend:");
    UserInterface.DisplayAllUsers(users);
    var choice = UserInterface.GetValidChoice(users.Count);
    currentUser.AddUser(users[choice - 1]);
    Console.WriteLine($"You have added {users[choice - 1].FirstName} {users[choice - 1].LastName} as a friend.");
}

static void RemoveFriendFlow(User currentUser)
{
    UserInterface.DisplayFriendList(currentUser);
    Console.WriteLine("Select a friend to remove:");
    var choice = UserInterface.GetValidChoice(currentUser.Friends.Count);
    var friendToRemove = currentUser.SelectFriend(choice);
    currentUser.RemoveUser(friendToRemove);
    Console.WriteLine($"You have removed {friendToRemove.FirstName} {friendToRemove.LastName} from your friends.");
}

static void DisplayInterestsFlow(User currentUser)
{
    UserInterface.DisplayFriendList(currentUser);
    Console.WriteLine("Select a friend to view their interests:");
    var choice = UserInterface.GetValidChoice(currentUser.Friends.Count);
    var selectedUser = currentUser.SelectFriend(choice);
    Console.WriteLine(
        $"{selectedUser.FirstName} {selectedUser.LastName}'s interests: {string.Join(", ", selectedUser.Interests)}");
}

static void WaitForKeyPress()
{
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey(true);
}