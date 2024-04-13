using FileDb.App.Brokers.Storages;
using FileDb.App.Models.Users;
using System.Collections.Generic;

namespace FileDb.App.Services.UserServices
{
    internal interface IUserService
    {
        User AddUser(User user);
        List<User> ShowUsers();
        void Update(User user);
        void Delete(int id);
    }
}
