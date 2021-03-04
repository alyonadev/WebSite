using System.Collections.Generic;
using WebSite.DBModels;

namespace Services
{
    public interface IMessageService
    {
        List<Message> GetAllUsersMessagesService(int fromId, int toId);

        Message GetByIdMessageService(int id);

        void AddMessageService(Message item);

        void UpdateMessageService(Message item);

        void DeleteMessageService(int id);

        int GetUserUnreadMessagesService(int toId, int fromId);        
    }
}
