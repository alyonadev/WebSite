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
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;


        public MessageController()
        {
            _messageService = new MessageService();
            _userService = new UserService();
        }

        [Authorize]
        public ActionResult Index()
        {
            var users = _userService.GetAllService();

            foreach (var user in users)
            {
                if (user.Photo != null)
                    ViewBag.UserImage = _userService.GetURLPhotoService(user.Photo);
                else
                    ViewBag.UserImage = null;
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