using FileDb.App.Brokers.Storages;
using FileDb.App.Brokers.Storages;
using FileDb.App.Models.Users;
using System.Collections.Generic;

namespace FileDb.App.Services.Identities
{
    internal sealed class IdentityService : IIdentityService
    {
        private static IdentityService instance;
        private readonly IStoragesBroker storagesBroker;

        private IdentityService()
        {
            this.storagesBroker = new JsonStorageBroker();
        }

        public static IdentityService GetIdentityService()
        {
            if (instance == null)
            {
                instance = new IdentityService();
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

        private static int IncrementListUsersId(List<User> users)
        {
            return users[users.Count - 1].Id + 1;
            
        }
    }
}
