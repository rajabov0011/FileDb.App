using FileDb.App.Models.Users;

namespace FileDb.App.Services.UserServices
{
    internal interface IUserService
    {
        User AddUser(User user);
        void ShowUsers();
        void Update(User user);
        void Delete(int id);
    }
}
