using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class MessageController : Controller
    {
        private IMessageService _messageService;
        private IUserService _userService;


        public MessageController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        [Authorize]
        public ActionResult Index()
        {
            var users = _userService.GetAllService();

            foreach (var user in users)
            {
                if (user.Photo != null)
                {
                    string userPhotoBase64Data = Convert.ToBase64String(user.Photo);
                    string imgDataURL = string.Format("data:image/png;base64,{0}", userPhotoBase64Data);
                    ViewBag.UserImage = imgDataURL;
                }
            }

            return View(users);
        }

        [HttpGet]
        public ActionResult Chat()
        {
            

            return View();
        }

    }
}