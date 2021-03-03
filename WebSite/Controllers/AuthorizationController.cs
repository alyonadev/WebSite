using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System.Web.Security;
using Services;
using System.Linq;
using ModelsWithMapper.Models;

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
        public ActionResult Register(UserAddModel newUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _userService.GetAllUsersService().
                         FirstOrDefault(u => u.Login == newUser.Login && u.Password == newUser.Password);

                    if (user == null)
                    {
                        _userService.AddUserService(UserAddModel.ToUser(newUser));

                        var userLogin = _userService.GetAllUsersService().
                            FirstOrDefault(u => u.Login == newUser.Login && u.Password == newUser.Password);

                        FormsAuthentication.SetAuthCookie(userLogin.UserId.ToString(), true);

                        return RedirectToAction("Index", "User");
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

                ViewBag.ErrorMessage = "Invalid age!";

                return View();
            }
        }
       
    }
}
