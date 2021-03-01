﻿using System;
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

        public void AddService(Message item)
        {
            _messageRepository.Add(item);
        }

        public void DeleteService(int id)
        {
            _messageRepository.Delete(id);
        }

        public void DisposeService()
        {
            _messageRepository.Dispose();
        }

        public List<Message> GetAllClientsService(int fromId, int toId)
        {
            IEnumerable<Message> messageList = _messageRepository.GetAll().Where(v => 
            (v.From == fromId && v.To == toId) || 
            (v.From == toId && v.To == fromId));
            return messageList.ToList();
        }

        public Message GetByIdService(int id)
        {
            return _messageRepository.GetById(id);
        }

        public void UpdateService(Message item)
        {
            _messageRepository.Update(item);
        }
        
    }
}
