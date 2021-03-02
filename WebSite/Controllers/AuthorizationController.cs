using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System.Web.Security;
using Services;
using WebSite.Models;
using System.Linq;
using WebSite.Repository;
using WebSite.DBModels;

namespace WebSite.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IUserService _userService;

        public AuthorizationController()
        {
            _userService = new UserService();
        }

        [HttpGet]
        public ActionResult Login() 
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string login, string password)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetAllService().
                    FirstOrDefault(u => u.Login == login && u.Password == _userService.GetHashService(password));

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.UserId.ToString(), true);
                    return RedirectToAction("Index", "Message");
                }
                else
                {
                    ViewBag.ErrorMessage = "Неверный логин или пароль!";
                    return View();
                }
            }
            else
            {
                return View();
            }                
            
        }

        public ActionResult Logout()
        { 
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Authorization");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel newUser)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetAllService().
                     FirstOrDefault(u => u.Login == newUser.Login && u.Password == _userService.GetHashService(newUser.Password));

                if (user == null)
                {                  
                    if (newUser.PhotoFile != null)
                        newUser.Photo = UserModel.GetBytePhotoService(newUser.PhotoFile);
                    
                    _userService.AddService(UserModel.ToUser(newUser));

                    var userLogin = _userService.GetAllService().
                        FirstOrDefault(u => u.Login == newUser.Login && u.Password == _userService.GetHashService(newUser.Password));

                    FormsAuthentication.SetAuthCookie(userLogin.UserId.ToString(), true);

                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ViewBag.ErrorMessage = "Пользователь с таким логином и паролем уе существует!";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
       
    }
}
