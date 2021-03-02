using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

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
            var users = UserModel.ToUserModelList(_userService.GetAllService());
            if (int.TryParse(User.Identity.Name, out int uid))
            {
                users = users.Where(v => v.UserId != uid).AsEnumerable();
            }
            return View(users);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Chat(int id)
        {
            if (int.TryParse(User.Identity.Name, out int userId))
            {
                ViewBag.FromUser = UserModel.ToUserModel(_userService.GetByIdService(userId));
                ViewBag.ToUser = UserModel.ToUserModel(_userService.GetByIdService(id));
                var messages = _messageService.GetAllClientsService(userId, id);
                return View(messages);
            }
            else
                return View("Login", "Authorization");
        }

    }
}