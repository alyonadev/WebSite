using AutoMapper;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBModels;
using WebSite.Models.MessageViewModel;
using WebSite.Models.UserViewModel;

namespace WebSite.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly IDialogService _dialogService;

        public MessageController()
        {
            _messageService = new MessageService();
            _userService = new UserService();
            _dialogService = new DialogService();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            try
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
                    u.PhotoUrl = null;
                }

                var messages = mapperMessage.Map<List<IndexMessageViewModel>>(users);

                foreach (var m in messages)
                {
                    var dialog = _dialogService.GetDialogService(m.UserId, uid);

                    m.CountOfUnread = _messageService.GetUnreadMessagesService(dialog.DialogId);
                    m.LastMessage = _messageService.GetLastUserMessagesService(dialog.DialogId);
                }

                return View(messages);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Chat(int id)
        {
            try
            {
                ReadMessages(id);

                var config = new MapperConfiguration(cfg => cfg.CreateMap<Message, IndexMessageViewModel>());
                var configUser = new MapperConfiguration(cfg => cfg.CreateMap<User, IndexUserViewModel>());

                var mapper = new Mapper(config);
                var mapperUser = new Mapper(configUser);

                if (int.TryParse(User.Identity.Name, out int userId))
                {
                    var userFrom = mapperUser.Map<IndexUserViewModel>(_userService.GetUserService(userId));
                    var userTo = mapperUser.Map<IndexUserViewModel>(_userService.GetUserService(id));

                    userFrom.PhotoUrl = _userService.GetURLPhotoUserService(userFrom.Photo);
                    userTo.PhotoUrl = _userService.GetURLPhotoUserService(userTo.Photo);

                    ViewBag.FromUser = userFrom;
                    ViewBag.ToUser = userTo;
                    ViewBag.PassedPhotoUrl = userFrom.PhotoUrl ?? "/img/defaultPhoto.jpg";

                    var dialog = _dialogService.GetDialogService(userId, id);

                    var messages = mapper.Map<List<IndexMessageViewModel>>(_messageService.GetAllDialogMessagesService(dialog.DialogId));

                    return View(messages);
                }
                else
                    return View("Login", "Authorization");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        private void ReadMessages(int id)
        {
            if (int.TryParse(User.Identity.Name, out int userId))
            {
                var userFrom = _userService.GetUserService(userId);
                var userTo = _userService.GetUserService(id);

                var messageList = _messageService
                    .GetAllDialogMessagesService(userFrom.UserId, userTo.UserId)
                    .Where(v => (v.From == userTo.UserId && v.To == userFrom.UserId));

                var mes = _dialogService.

                foreach (var message in messageList)
                {
                    message.Status = true;
                    _messageService.UpdateMessageService(message);
                }
            }
            
        }

    }
}