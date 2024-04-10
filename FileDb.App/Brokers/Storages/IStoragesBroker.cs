using FileDbGroup.App.Modals.Users;
using System.Collections.Generic;

namespace FileDbGroup.App.Brokers.Storages
{
    internal interface IStoragesBroker
    {
        User AddUser(User user);
        List<User> ReadAllUsers();
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
