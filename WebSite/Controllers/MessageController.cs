using AutoMapper;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.DBModels;
using WebSite.Models.MessageViewModel;
using WebSite.Models.UserViewModel;

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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, IndexUserViewModel>());
            var mapper = new Mapper(config);

            var users = mapper.Map<List<IndexUserViewModel>>(_userService.GetAllUsersService());

            if (int.TryParse(User.Identity.Name, out int uid))
            {
                users = users.FindAll(v => v.UserId != uid);
            }
            foreach (var u in users)
            {
                if (u.Photo.Length > 0)
                    u.PhotoUrl = _userService.GetURLPhotoUserService(u.Photo);
                else
                    u.PhotoUrl = null;
            }

            return View(users);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Chat(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Message, IndexMessageViewModel>());
            var mapper = new Mapper(config);

            if (int.TryParse(User.Identity.Name, out int userId))
            {
                ViewBag.FromUser =_userService.GetByIdUserService(userId);
                ViewBag.ToUser = _userService.GetByIdUserService(id);

                var messages = mapper.Map<List<IndexMessageViewModel>>(_messageService.GetAllUsersMessagesService(userId, id));

                return View(messages);
            }
            else
                return View("Login", "Authorization");
        }

    }
}