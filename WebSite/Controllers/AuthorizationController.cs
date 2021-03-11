using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System.Web.Security;
using Services;
using System.Linq;
using AutoMapper;
using DBModels;
using WebSite.Models.UserViewModel;

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
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _userService.GetAllUsersService().
                        FirstOrDefault(u => u.Login == login && u.Password == password);

                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(user.UserId.ToString(), true);

                        return RedirectToAction("Index", "Message");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Incorrect login or password!";

                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (System.Exception)
            {
                return View("Error");
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
        public ActionResult Register(AddUserViewModel addUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _userService.GetAllUsersService().
                         FirstOrDefault(u => u.Login == addUser.Login && u.Password == addUser.Password);

                    if (user == null)
                    {
                        if (addUser.Age < 6 || addUser.Age > 80)
                        {
                            ViewBag.ErrorMessage = "Invalid age!";

                            return View();
                        }
                        else
                        {
                            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddUserViewModel, User>());
                            var mapper = new Mapper(config);

                            _userService.AddUserService(mapper.Map<AddUserViewModel, User>(addUser));

                            var userLogin = _userService.GetAllUsersService().
                                FirstOrDefault(u => u.Login == addUser.Login && u.Password == addUser.Password);

                            FormsAuthentication.SetAuthCookie(userLogin.UserId.ToString(), true);

                            return RedirectToAction("Index", "User");
                        }                        
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "This user already exists!";

                        return View();
                    }
                }                
                else
                {
                    return View();
                }
            }
            catch (System.Exception)
            {
                return View("Error");                
            }
        }
       
    }
}
