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
        private IUserService _userService;
                
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        public ActionResult Index()
        {
            if (int.TryParse(User.Identity.Name, out int userId)) 
            {
                var user = _userService.GetByIdService(userId);

                if (user.Photo != null)
                {
                    string userPhotoBase64Data = Convert.ToBase64String(user.Photo);
                    string imgDataURL = string.Format("data:image/png;base64,{0}", userPhotoBase64Data);
                    ViewBag.UserImage = imgDataURL;
                }

                return View(user);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            if (int.TryParse(User.Identity.Name, out int userId))
                return View(_userService.GetByIdService(userId));
            else
                return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public ActionResult Edit(UserModel updatedUser)
        {
            if (updatedUser.PhotoFile != null)
                updatedUser.Photo = _userService.GetPhotoService(updatedUser.PhotoFile);

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
