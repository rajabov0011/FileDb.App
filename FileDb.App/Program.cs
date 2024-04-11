using System;
using FileDb.App.Brokers.Storages;
using FileDb.App.Brokers.Loggings;
using FileDb.App.Services.Identities;
using FileDb.App.Services.UserProcessing;
using FileDb.App.Services.UserServices;

internal class Program
{
    private static void Main(string[] args)
    {
        IUserProcessingService userProcessingService = InitializeServices();

        string userChoice;
        do
        {
            PrintMenu();
            Console.Write("Enter your choice: ");
            userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    Console.Clear();
                    Console.Write("Enter your name: ");
                    string userName = Console.ReadLine();
                    userProcessingService.CreateNewUser(userName);
                    break;

                case "2":
                    {
                        Console.Clear();
                        userProcessingService.DisplayUsers();
                    }
                    break;

                case "3":
                    {
                        Console.Clear();
                        Console.WriteLine("Enter an ID which you want to delete");
                        Console.Write("Enter ID: ");
                        int deleteWithId = Convert.ToInt32(Console.ReadLine());
                        userProcessingService.DeleteUser(deleteWithId);
                    }
                    break;

                case "4":
                    {
                        Console.Clear();
                        Console.WriteLine("Enter an id which you want to edit");
                        Console.Write("Enter an ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter new name: ");
                        string newName = Console.ReadLine();
                        userProcessingService.UpdateUser(id, newName);
                    }
                    break;

                case "0": break;

                default:
                    Console.WriteLine("You entered wrong input, please try again!");
                    break;
            }
        }
        while (userChoice != "0");
        Console.Clear();
        Console.WriteLine("The app has been finished, thanks bye!");
    }

    private static IUserProcessingService InitializeServices()
    {
        ILoggingBroker loggingBroker = new LoggingBroker();
        IStoragesBroker storagesBroker = new JsonStorageBroker();
        IUserService userService = new UserService(loggingBroker,storagesBroker);
        IIdentityService identityService = IdentityService.GetIdentityService();
        IUserProcessingService userProcessingService = new UserProcessingService(userService, identityService);

        return userProcessingService;
    }

    private static void PrintMenu()
    {
        Console.WriteLine("1.Create User");
        Console.WriteLine("2.Display User");
        Console.WriteLine("3.Delete User by ID");
        Console.WriteLine("4.Update User by ID");
        Console.WriteLine("0.Exit");
    }
}