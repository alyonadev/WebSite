using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.DBModels;
using WebSite.Repository;

namespace Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService()
        {
            _messageRepository = new MessageRepository(new WebSiteContext());
        }

        public void AddMessageService(Message item)
        {
            _messageRepository.Add(item);
        }

        public void DeleteMessageService(int id)
        {
            _messageRepository.Delete(id);
        }

        public void DisposeService()
        {
            _messageRepository.Dispose();
        }

        public List<Message> GetAllUsersMessagesService(int fromId, int toId)
        {
            IEnumerable<Message> messageList = _messageRepository.GetAll().Where(v => 
            (v.From == fromId && v.To == toId) || 
            (v.From == toId && v.To == fromId));

            return messageList.ToList();
        }

        public int GetUserUnreadMessagesService(int toId, int fromId)
        {
            int countMessage = _messageRepository.GetAll()
                .Where(v => (v.From == fromId && v.To == toId && v.Status == false)).Count();

            return countMessage;
        }

        public string GetLastUserMessagesService(int toId, int fromId)
        {
            string lastMessage = _messageRepository.GetAll().Where(v =>
            (v.From == fromId && v.To == toId) ||
            (v.From == toId && v.To == fromId))
            .Reverse().FirstOrDefault().Text;

            return lastMessage;
        }

        public Message GetByIdMessageService(int id)
        {
            return _messageRepository.GetById(id);
        }

        public void UpdateMessageService(Message item)
        {
            _messageRepository.Update(item);
        }
        
    }
}
