using System.Collections.Generic;
using DBModels;

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

        string GetLastUserMessagesService(int toId, int fromId);
    }
}
