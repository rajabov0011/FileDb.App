//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FileDb.App.Models.Users;

namespace FileDb.App.Brokers.Storages
{
    internal class JsonStorageBroker : IStoragesBroker
    {
        private const string FilePath = "../../../UsersJson.json";

        public JsonStorageBroker()
        {
            EnsureFileExists();
        }

        public User AddUser(User user)
        {
            string usersItems = File.ReadAllText(FilePath);
            List<User> users = JsonSerializer.Deserialize<List<User>>(usersItems);
            users.Add(user);
            string seralizedUsers = JsonSerializer.Serialize(users);
            File.WriteAllText(FilePath, seralizedUsers);

            return user;
        }

        public List<User> ReadAllUsers()
        {
            string usersItems = File.ReadAllText(FilePath);
            List<User> users = JsonSerializer.Deserialize<List<User>>(usersItems);
            return users;
        }

        public User UpdateUser(User user)
        {
            string usersItems = File.ReadAllText(FilePath);
            List<User> users = JsonSerializer.Deserialize<List<User>>(usersItems);
            User updatedUser = users.FirstOrDefault(u => u.Id == user.Id);
            updatedUser.Name = user.Name;
            string serializedUsers = JsonSerializer.Serialize(users);
            File.WriteAllText(FilePath, serializedUsers);

            return updatedUser;
        }

        public bool DeleteUser(int userId)
        {
            string usersItems = File.ReadAllText(FilePath);
            List<User> users = JsonSerializer.Deserialize<List<User>>(usersItems);
            User user = users.FirstOrDefault(u => u.Id == userId);
            users.Remove(user);
            string serializedUsers = JsonSerializer.Serialize(users);
            File.WriteAllText(FilePath, serializedUsers);

            return true;
        }

        private void EnsureFileExists()
        {
            bool fileExists = File.Exists(FilePath);
            if (fileExists is false)
            {
                File.Create(FilePath).Close();
                File.WriteAllText(FilePath, "[]");
            }
        }
    }
}