using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DBModels;
using Repository;

namespace Services
{
    public interface IUserService
    {
        List<User> GetAllUsersService();

        User GetUserService(int id);

        User GetUserService(string login, string password);

        void AddUserService(User item);

        void UpdateUserService(User item);

        void DeleteUserService(int id);

        string GetURLPhotoUserService(byte[] photo);

        byte[] GetBytePhotoUserService(HttpPostedFileBase photoFile);

    }
}
