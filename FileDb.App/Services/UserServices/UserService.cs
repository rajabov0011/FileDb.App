//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using FileDb.App.Brokers.Storages;
using FileDb.App.Brokers.Loggings;
using FileDb.App.Models.Users;
using System;
using System.Collections.Generic;

namespace FileDb.App.Services.UserServices
{
    internal class UserService : IUserService
    {
        private readonly IStoragesBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public UserService(IStoragesBroker storagesBroker)
        {
            this.storageBroker = storagesBroker;
            this.loggingBroker = new LoggingBroker();
        }

        public User AddUser(User user)
        {
            return user is null
                ? CreateAndLogInvalidUser()
                : ValidateAndAddUser(user);
        }

        public List<User> ShowUsers()
        {
           
            List<User> users = this.storageBroker.ReadAllUsers();
            
            foreach (User user in users)
            {
                this.loggingBroker.LogSuccessUser($"{user.Id}. {user.Name}");
            }
            this.loggingBroker.LogInforamation("===End of users===");

            return users;
        }

        private User CreateAndLogInvalidUser()
        {
            this.loggingBroker.LogError("User is invalid");
            return new User();
        }

        private User ValidateAndAddUser(User user)
        {
            if (user.Id is 0 || String.IsNullOrWhiteSpace(user.Name))
            {
                this.loggingBroker.LogError("User details missing.");
                return new User();
            }
            else
            {
                this.loggingBroker.LogInforamation("User is created successfully");
                return this.storageBroker.AddUser(user);
            }
        }

        public void DeleteUser(int id)
        {
            List<User> users = this.storageBroker.ReadAllUsers();
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i] != null && users[i].Id == id)
                {
                    users.RemoveAt(i);
                    this.loggingBroker.LogInforamation($"User with ID {id} deleted successfully.");
                    return;
                }
            }
            this.loggingBroker.LogError($"User with ID {id} not found.");
        }

        public void Update(User user)
        {
            if (user is null)
            {
                this.loggingBroker.LogError("Your user is empty");
            }

            if (user.Id == 0 || String.IsNullOrEmpty(user.Name))
            {
                this.loggingBroker.LogError("Your user is invalid");
            }

            this.storageBroker.UpdateUser(user);
        }

        public void Delete(int id)
        {
            this.storageBroker.DeleteUser(id);
        }
    }
}