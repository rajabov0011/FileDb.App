using FileDb.App.Models.Users;
using System.Collections.Generic;

namespace FileDb.App.Brokers.Storages
{
    internal interface IStoragesBroker
    {
        User AddUser(User user);
        List<User> ReadAllUsers();
        User UpdateUser(User user);
        bool DeleteUser(int id);
    }
}
