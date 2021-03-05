using AutoMapper;
using Services;
using System.Web.Mvc;
using System.Web.Security;
using WebSite.DBModels;
using WebSite.Models.UserViewModel;

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
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<User, IndexUserViewModel>());
                var mapper = new Mapper(config);

                if (int.TryParse(User.Identity.Name, out int userId))
                {
                    var user = mapper.Map<IndexUserViewModel>(_userService.GetByIdUserService(userId));

                    if (user.Photo.Length > 0)
                    {
                        user.PhotoUrl = _userService.GetURLPhotoUserService(user.Photo);
                    }

                    return View(user);
                }

                return View();
            }
            catch (System.Exception)
            {
                return View("Error");
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit()
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<User, EditUserViewModel>());
                var mapper = new Mapper(config);

                if (int.TryParse(User.Identity.Name, out int userId))
                {
                    EditUserViewModel user = mapper.Map<EditUserViewModel>(_userService.GetByIdUserService(userId));

                    return View(user);
                }
                else
                    return RedirectToAction("Index", "User");
            }
            catch (System.Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel updatedUser)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<EditUserViewModel, User>());
                var mapper = new Mapper(config);

                if (updatedUser.PhotoFile != null)
                {
                    updatedUser.Photo = _userService.GetBytePhotoUserService(updatedUser.PhotoFile);
                }

                if (updatedUser.Age < 6 && updatedUser.Age > 80)
                {
                    ViewBag.ErrorMessage = "Invalid age!";

                    return View(updatedUser);
                }
                else
                {
                    _userService.UpdateUserService(mapper.Map<User>(updatedUser));
                }                

                return RedirectToAction("Index", "User");
            }
            catch (System.Exception)
            {
                return View("Error");
            }
        }

        public ActionResult Delete()
        {
            try
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
            catch (System.Exception)
            {
                return View("Error");
            }
        }

    }
}
