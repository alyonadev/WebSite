using System;
using System.Collections.Generic;
using System.Linq;
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

        public int Age { get; set; }

        public string Address { get; set; }

        public string Login { get; set; }

        public User ToUser(UserModel userModel) 
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

        public UserModel ToUserModel(User user)
        {
            UserModel newUser = new UserModel
            {
                UserId = user.UserId,
                Name = user.Name,
                Surname = user.Surname,
                Address = user.Address,
                Age = user.Age,
                Password = user.Password,
                Login = user.Login,
                Photo = user.Photo
            };

            return newUser;
        }

    }
}