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
            var configUser = new MapperConfiguration(cfg => cfg.CreateMap<User, IndexUserViewModel>());
            var configMessage = new MapperConfiguration(cfg => cfg.CreateMap<IndexUserViewModel, IndexMessageViewModel>());

            var mapperUser = new Mapper(configUser);
            var mapperMessage = new Mapper(configMessage);

            var users = mapperUser.Map<List<IndexUserViewModel>>(_userService.GetAllUsersService());

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

            var messages = mapperMessage.Map<List<IndexMessageViewModel>>(users);

            foreach (var m in messages)
            {
                m.From = m.UserId;
                m.To = uid;

                m.CountOfUnread = _messageService.GetUserUnreadMessagesService(m.To, m.From);
                m.LastMessage = _messageService.GetLastUserMessagesService(m.To, m.From);
            }

            return View(messages);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Chat(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Message, IndexMessageViewModel>());
            var configUser = new MapperConfiguration(cfg => cfg.CreateMap<User, IndexUserViewModel>());

            var mapper = new Mapper(config);
            var mapperUser = new Mapper(configUser);

            if (int.TryParse(User.Identity.Name, out int userId))
            {
                var userFrom = mapperUser.Map<IndexUserViewModel>(_userService.GetByIdUserService(userId));
                var userTo = mapperUser.Map<IndexUserViewModel>(_userService.GetByIdUserService(id));

                if (userFrom.Photo.Length > 0)
                    userFrom.PhotoUrl = _userService.GetURLPhotoUserService(userFrom.Photo);
                
                if (userTo.Photo.Length > 0)
                    userTo.PhotoUrl = _userService.GetURLPhotoUserService(userTo.Photo);
                
                ViewBag.FromUser = userFrom;
                ViewBag.ToUser = userTo;
                ViewBag.PassedPhotoUrl = userFrom.PhotoUrl ?? "/img/defaultPhoto.jpg";

                var messages = mapper.Map<List<IndexMessageViewModel>>(_messageService.GetAllUsersMessagesService(userId, id));

                return View(messages);
            }
            else
                return View("Login", "Authorization");
        }

    }
}