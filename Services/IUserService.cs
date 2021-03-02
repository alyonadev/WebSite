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
        List<User> GetAllService();
        User GetByIdService(int id);
        void AddService(User item);
        void UpdateService(User item);
        void DeleteService(int id);
        byte[] GetBytePhotoService(HttpPostedFileBase file);
        string GetURLPhotoService(byte[] photo);
        string GetHashService(string value);
    }
}
