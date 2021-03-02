using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using WebSite.DBModels;

namespace WebSite.Models
{
    
    public class UserModel
    {
        public int? UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Password { get; set; }

        public byte[] Photo { get; set; }

        public HttpPostedFileBase PhotoFile { get; set; }

        public string PhotoUrl { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public string Login { get; set; }

        public static User ToUser(UserModel userModel) 
        {
            User newUser = new User
            {
                UserId = userModel.UserId,
                Name = userModel.Name,
                Surname = userModel.Surname,
                Address = userModel.Address,
                Age = userModel.Age,
                Password = Hash(userModel.Password),
                Login = userModel.Login,
                Photo = userModel.Photo
            };

            return newUser;

        }

        public static UserModel ToUserModel(User user)
        {
            UserModel newUser = new UserModel
            {
                UserId = user.UserId,
                Name = user.Name,
                Surname = user.Surname,
                Address = user.Address,
                Age = user.Age,
                Password = Hash(user.Password),
                Login = user.Login,
                Photo = null,
                PhotoUrl = null
            };

            if (user.Photo != null)
            {
                newUser.Photo = user.Photo;
                newUser.PhotoUrl = GetURLPhotoService(user.Photo);
            }

            return newUser;
        }

        public static IEnumerable<User> ToUserList(IEnumerable<UserModel> userModels)
        {
            List<User> users = new List<User>();
            foreach (var um in userModels) users.Add(ToUser(um));
            return users.AsEnumerable();
        }

        public static IEnumerable<UserModel> ToUserModelList(IEnumerable<User> users)
        {
            List<UserModel> userModels = new List<UserModel>();
            foreach (var um in users) userModels.Add(ToUserModel(um));
            return userModels.AsEnumerable();
        }

        public static byte[] GetBytePhotoService(HttpPostedFileBase photoFile)
        {
            byte[] photoData = new byte[photoFile.ContentLength];
            photoFile.InputStream.Read(photoData, 0, photoFile.ContentLength);

            return photoData;
        }

        public static string GetURLPhotoService(byte[] photo)
        {
            string userPhotoBase64Data = Convert.ToBase64String(photo);
            string imgDataURL = string.Format("data:image/png;base64,{0}", userPhotoBase64Data);
            return imgDataURL;
        }
        public static string Hash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(value)));
        }

    }
}