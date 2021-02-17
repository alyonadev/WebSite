using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebSite.Models;

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
                var user = _userService.GetByIdService(userId);

                if (user.Photo != null)
                    ViewBag.UserImage = _userService.GetURLPhotoService(user.Photo);

                return View(user);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            if (int.TryParse(User.Identity.Name, out int userId))
            {
                return View(_userService.GetByIdService(userId));
            }
            else
                return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public ActionResult Edit(UserModel updatedUser)
        {
            if (updatedUser.PhotoFile != null)
                updatedUser.Photo = _userService.GetBytePhotoService(updatedUser.PhotoFile);
            else
                updatedUser.Photo = null;

            _userService.UpdateService(updatedUser.ToUser(updatedUser));

            return View(updatedUser);
        }

        
        public ActionResult Delete()
        {
            
            if (int.TryParse(User.Identity.Name, out int userId))
            {
                FormsAuthentication.SignOut();
                _userService.DeleteService(userId);

                return RedirectToAction("Login", "Authorization");
            }
            else
                return RedirectToAction("Index", "User");
        }

       
    
    }
}
