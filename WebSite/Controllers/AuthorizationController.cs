using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System.Web.Security;
using Services;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class AuthorizationController : Controller
    {
        const string ErrorMsgTemplate = @"
			<div class=""alert alert-danger"" role=""alert"">
				Неверный логин или пароль.
			</div>";

        private readonly IUserService _userService;

        public AuthorizationController(IUserService userService)
        {
            _userService = userService;
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
            ViewData["Message"] = string.Empty;

            if (ModelState.IsValid)
            {
                var user = _userService.FirstOrDefault(
                    u => u.Login == login && u.Password == password);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.UserId.ToString(), true);
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ViewData["Massage"] = ErrorMsgTemplate;
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
        public ActionResult Register(UserInit newUser)
        {
            if (ModelState.IsValid)
            {
                var usr = _userService.FirstOrDefault(
                    u => u.Login == newUser.Login && u.Password == newUser.Password);

                if (usr == null)
                {                  
                    if (newUser.PhotoFile != null)
                        newUser.Photo = _userService.GetPhoto(newUser.PhotoFile);
                    
                    _userService.Add(newUser);

                    FormsAuthentication.SetAuthCookie(newUser.UserId.ToString(), true);

                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ViewData["Massage"] = ErrorMsgTemplate;
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
