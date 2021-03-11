using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebSite.DBModels;

namespace WebSite.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly WebSiteContext _context;

        public MessageRepository(WebSiteContext context)
        {
            _context = context;
        }

        public IEnumerable<Message> GetAll()
        {
            return _context.Messages.ToList();
        }

        public Message GetById(int messageId)
        {
            return _context.Messages.Find(messageId);
        }

        public void Add(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public void Update(Message message)
        {
            _context.Entry(message).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int messageId)
        {
            Message message = _context.Messages.Find(messageId);

            _context.Messages.Remove(message);
            _context.SaveChanges();
        }

        private bool disposed = false;

    }
}