//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using System;
using System.IO;
using FileDb.App.Brokers.Storages;
using FileDb.App.Services.Identity;
using FileDb.App.Services.FileService;
using FileDb.App.Services.UserProcessing;
using FileDb.App.Services.UserServices;

internal class Program
{
    private static void Main(string[] args)
    {
        string restartProgram;
        do
        {
            Console.Clear();
            Console.WriteLine("===== Welcome to my File Database Library =====");
            string fileOrUserChoice;
            PrintFilesOrUsers();
            fileOrUserChoice = Console.ReadLine();
            switch (fileOrUserChoice)
            {
                case "1":
                    {
                        Console.Clear();
                        Console.WriteLine("===== Welcome to the Working with Files! =====\n");

                        string assetsPath = "../../../Assets";

                        CompositeFile folder = new CompositeFile(assetsPath);
                        WorkWithSizeOfFiles(folder, assetsPath);
                        folder.PrintFileInfo();
                        break;
                    }
                case "2":
                    {
                        PrintTxtOrJSON();
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
                                        Console.Write("Enter an ID which you want to edit >>> ");
                                        int id = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Enter new name >>> ");
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
                        break;
                    }
                default: Console.WriteLine("Menu selection ERROR!"); break;
            }
            Console.Write("\nDo you want to use the program again? [1 - Yes/0 - No] >>> ");
            restartProgram = Console.ReadLine();
        } while (restartProgram != "0");
        Console.Clear();
        Console.WriteLine("\nThe app has been finished, thanks bye!");
    }

    private static IUserProcessingService InitializeServices()
    {
        string userChoice = Console.ReadLine();
        int choice = Convert.ToInt32(userChoice);
        IStoragesBroker jsonstorageBroker = new JsonStorageBroker();
        IStoragesBroker txtstrorageBroker = new FileStorageBroker();
        IUserService userService = null;
        IStoragesBroker storagesBroker = null;

        switch (choice)
        {
            case 1:
                userService = new UserService(txtstrorageBroker);
                storagesBroker = new FileStorageBroker();
                break;
            case 2:
                userService = new UserService(jsonstorageBroker);
                storagesBroker = new JsonStorageBroker();
                break;
            default:
                Console.WriteLine("Invalid choice, please try again!");
                break;
        }

        IIdentityService identityService = IdentityService.GetIdentityService(storagesBroker);
        IUserProcessingService userProcessingService = new UserProcessingService(userService, identityService);

        return userProcessingService;
    }

    static void WorkWithSizeOfFiles(CompositeFile folder, string foldersPath)
    {
        try
        {
            foreach (string filePath in Directory.GetFiles(foldersPath))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                folder.Add(new FileDb.App.Services.FileService.File(fileInfo.Name, fileInfo.Length));
            }

            foreach (string subFolderPath in Directory.GetDirectories(foldersPath))
            {
                CompositeFile subFolders = new CompositeFile(Path.GetFileName(subFolderPath));
                WorkWithSizeOfFiles(subFolders, subFolderPath);
                folder.Add(subFolders);
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Error in the File: {foldersPath} |||  Exception: {exception.Message}");
        }
    }

    private static void PrintFilesOrUsers()
    {
        Console.WriteLine("1. Know the size of Files");
        Console.WriteLine("2. Work with Users");
        Console.Write("Choose >>> ");
    }

    private static void PrintTxtOrJSON()
    {
        Console.WriteLine("Which file format do you want to save your data to?");
        Console.WriteLine("1 -> .TXT");
        Console.WriteLine("2 -> .JSON");
        Console.Write("Choose >>> ");
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