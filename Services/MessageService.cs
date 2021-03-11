using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModels;
using Repository;

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

        public List<Message> GetAllDialogMessagesService(int dialogId)
        {
            IEnumerable<Message> messageList = _messageRepository.GetAll()
                .Where(v => v.DialogId == dialogId);

            return messageList.ToList();
        }

        public int GetUnreadMessagesService(int dialogId)
        {
            int countMessage = _messageRepository.GetAll()
                .Where(v => (v.DialogId == dialogId && v.Status == false)).Count();

            return countMessage;
        }

        public string GetLastUserMessagesService(int dialogId)
        {
            var lastMessage = _messageRepository.GetAll()
                .Where(v => v.DialogId == dialogId).LastOrDefault();

            string textMessage = lastMessage != null ? lastMessage.Text : "";

            return textMessage;
        }

        public void UpdateMessageService(Message item)
        {
            _messageRepository.Update(item);
        }
        
    }
}
