using ModelsWithMapper;
using Services;
using System.Web.Mvc;
using System.Web.Security;

namespace WebSite.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
                
        public UserController()
        {
            _userService = new UserService();
        }

        [Authorize]
        public ActionResult Index()
        {
            if (int.TryParse(User.Identity.Name, out int userId)) 
            {
                var user = UserEditModel.ToUserModel(_userService.GetByIdUserService(userId));

                if (user.Photo != null)
                    user.PhotoUrl = UserEditModel.GetURLPhotoService(user.Photo);

                return View(user);
            }

            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit()
        {
            if (int.TryParse(User.Identity.Name, out int userId))
            {
                UserEditModel user = UserEditModel.ToUserModel(_userService.GetByIdUserService(userId));

                return View(user);
            }
            else
                return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public ActionResult Edit(UserEditModel updatedUser)
        {
            try
            {
                if (updatedUser.PhotoFile != null)
                    updatedUser.Photo = UserEditModel.GetBytePhotoService(updatedUser.PhotoFile);

                _userService.UpdateUserService(UserEditModel.ToUser(updatedUser));

                return View(updatedUser);
            }
            catch (System.Exception)
            {
                ViewBag.ErrorMessage = "Invalid age!";

                return View(updatedUser);
            }
        }

        public ActionResult Delete()
        {
            if (int.TryParse(User.Identity.Name, out int userId))
            {
                FormsAuthentication.SignOut();

                _userService.DeleteUserService(userId);

                return RedirectToAction("Login", "Authorization");
            }
            else
                return RedirectToAction("Index", "User");
        }

    }
}
