using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.DBModels;

namespace WebSite
{
    public class UserAddModel : UserBase
    {
        public static User ToUser(UserAddModel userModel)
        {
            User newUser = new User
            {
                UserId = userModel.UserId,
                Name = userModel.Name,
                Surname = userModel.Surname,
                Address = null,
                Age = userModel.Age,
                Password = userModel.Password,
                Login = userModel.Login,
                Photo = null
            };

            return newUser;

        }

        public static UserAddModel ToUserModel(User user)
        {
            UserAddModel newUser = new UserAddModel
            {
                UserId = user.UserId,
                Name = user.Name,
                Surname = user.Surname,
                Age = user.Age,
                Password = user.Password,
                Login = user.Login
            };

            return newUser;
        }

    }
}
