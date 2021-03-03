using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.DBModels;
using AutoMapper;

namespace ModelsWithMapper.Mapper
{
    public class UserMapper
    {

        public static User ToUser(UserEditModel userModel)
        {
            User newUser = new User
            {
                UserId = userModel.UserId,
                Name = userModel.Name,
                Surname = userModel.Surname,
                Address = userModel.Address,
                Age = userModel.Age,
                Password = userModel.Password,
                Login = userModel.Login,
                Photo = userModel.Photo
            };

            return newUser;

        }

        public static UserEditModel ToUserModel(User user)
        {
            UserEditModel newUser = new UserEditModel
            {
                UserId = user.UserId,
                Name = user.Name,
                Surname = user.Surname,
                Address = user.Address,
                Age = user.Age,
                Password = user.Password,
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

        public static IEnumerable<UserEditModel> ToUserModelList(IEnumerable<User> users)
        {
            List<UserEditModel> userModels = new List<UserEditModel>();

            foreach (var um in users)
            {
                userModels.Add(ToUserModel(um));
            }

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
    }
}
