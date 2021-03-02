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

        public byte[] GetBytePhotoService(HttpPostedFileBase photoFile)
        {
            byte[] photoData = new byte[photoFile.ContentLength];
            photoFile.InputStream.Read(photoData, 0, photoFile.ContentLength);

            return photoData;
        }

        public string GetURLPhotoService(byte[] photo)
        {
            string userPhotoBase64Data = Convert.ToBase64String(photo);
            string imgDataURL = string.Format("data:image/png;base64,{0}", userPhotoBase64Data);
            return imgDataURL;
        }
        public string GetHashService(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(value)));
        }
    }
}
