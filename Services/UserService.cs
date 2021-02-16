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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository(new WebSiteContext());
        }

        public void AddService(User item)
        {
            _userRepository.Add(item);
        }

        public void DeleteService(int id)
        {
            _userRepository.Delete(id);
        }

        public void DisposeService()
        {
            _userRepository.Dispose();
        }

        public List<User> GetAllService()
        {
            IEnumerable<User> userList = _userRepository.GetAll();
            return userList.ToList();
        }

        public User GetByIdService(int id)
        {
            return _userRepository.GetById(id);
        }

        public void UpdateService(User item)
        {
            _userRepository.Update(item);
        }

        public byte[] GetPhotoService(HttpPostedFileBase photoFile)
        {
            byte[] photoData = new byte[photoFile.ContentLength];
            photoFile.InputStream.Read(photoData, 0, photoFile.ContentLength);

            return photoData;
        }


    }
}
