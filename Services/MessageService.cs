using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Models;
using WebSite.Repository;

namespace Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public void Add(Message item)
        {
            _messageRepository.Add(item);
        }

        public void Delete(int id)
        {
            _messageRepository.Delete(id);
        }

        public void Dispose()
        {
            _messageRepository.Dispose();
        }

        public IEnumerable<Message> GetAll()
        {
            return _messageRepository.GetAll();
        }

        public Message GetById(int id)
        {
            return _messageRepository.GetById(id);
        }

        public void Update(Message item)
        {
            _messageRepository.Update(item);
        }
    }
}
