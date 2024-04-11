﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FileDb.App.Brokers.Storages;
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
            string usersString = File.ReadAllText(FilePath);
            List<User> users = JsonSerializer.Deserialize<List<User>>(usersString);
            users.Add(user);
            string serializedUsers = JsonSerializer.Serialize(users);
            File.WriteAllText(FilePath, serializedUsers);

            return user;
        }

        public List<User> ReadAllUsers()
        {
            string usersString = File.ReadAllText(FilePath);
            List<User> users = JsonSerializer.Deserialize<List<User>>(usersString);

            return users;
        }

        public User UpdateUser(User user)
        {
            string usersString = File.ReadAllText(FilePath);
            List<User> users = JsonSerializer.Deserialize<List<User>>(usersString);

            User updatedUser = users.Find(u => u.Id == user.Id);
            updatedUser.Name = user.Name;

            string serializedUsers = JsonSerializer.Serialize(users);
            File.WriteAllText(FilePath, serializedUsers);

            return updatedUser;
        }

        public bool DeleteUser(int id)
        {
            string usersString = File.ReadAllText(FilePath);
            List<User> users = JsonSerializer.Deserialize<List<User>>(usersString);
            User user = users.FirstOrDefault(u => u.Id == id);
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
            }
        }
    }
}