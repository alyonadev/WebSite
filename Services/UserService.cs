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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository(new WebSiteContext());
        }

        public void AddUserService(User item)
        {
            _userRepository.Add(item);
        }

        public void DeleteUserService(int id)
        {
            _userRepository.Delete(id);
        }

        public List<User> GetAllUsersService()
        {
            IEnumerable<User> userList = _userRepository.GetAll();

            return userList.ToList();
        }

        public User GetByIdUserService(int id)
        {
            return _userRepository.GetById(id);
        }

        public void UpdateUserService(User item)
        {
            _userRepository.Update(item);
        }

        public byte[] GetBytePhotoUserService(HttpPostedFileBase photoFile)
        {
            byte[] photoData = new byte[photoFile.ContentLength];
            photoFile.InputStream.Read(photoData, 0, photoFile.ContentLength);

            return photoData;
        }

        public string GetURLPhotoUserService(byte[] photo)
        {
            string userPhotoBase64Data = Convert.ToBase64String(photo);
            string imgDataURL = string.Format("data:image/png;base64,{0}", userPhotoBase64Data);

            return imgDataURL;
        }
    }
}
