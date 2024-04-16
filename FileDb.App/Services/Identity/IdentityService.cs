//----------------------------------------
// Tarteeb School (c) All rights reserved
//----------------------------------------

using FileDb.App.Brokers.Storages;
using FileDb.App.Models.Users;
using System.Collections.Generic;

namespace FileDb.App.Services.Identity
{
    internal sealed class IdentityService : IIdentityService
    {
        private static IdentityService instance;
        private readonly IStoragesBroker storagesBroker;

        private IdentityService(IStoragesBroker storagesBroker)
        {
            this.storagesBroker = storagesBroker;
        }

        public static IdentityService GetIdentityService(IStoragesBroker storagesBroker)
        {
            if (instance is null)
            {
                instance = new IdentityService(storagesBroker);
            }
            return instance;
        }

        public int GetNewId()
        {
            List<User> users = this.storagesBroker.ReadAllUsers();

            return users.Count is not 0
                ? IncrementListUsersId(users)
                : 1;
        }

        private static int IncrementListUsersId(List<User> users) =>
            users[users.Count - 1].Id + 1;
    }
}