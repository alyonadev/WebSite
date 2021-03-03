using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebSite.DBModels;
using WebSite.Repository;

namespace Services
{
    public interface IUserService
    {
        List<User> GetAllUsersService();

        User GetByIdUserService(int id);

        void AddUserService(User item);

        void UpdateUserService(User item);

        void DeleteUserService(int id);

        byte[] GetBytePhotoUserService(HttpPostedFileBase file);

        string GetURLPhotoUserService(byte[] photo);

    }
}
