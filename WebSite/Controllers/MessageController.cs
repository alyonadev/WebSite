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
        [HttpGet]
        public ActionResult Index()
        {
            var users = _userService.GetAllService();

            //get user photo

            return View(users);
        }


        [HttpGet]
        public ActionResult Chat()
        {
            if (int.TryParse(User.Identity.Name, out int userId))
            {
                var user = _userService.GetByIdService(userId);

                return View(user);
            }
            else
                return View("Login", "Authorization");
            
        }

    }
}