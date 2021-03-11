using System.Collections.Generic;
using DBModels;

namespace Services
{
    public interface IMessageService
    {
        List<Message> GetAllDialogMessagesService(int dialogId);

        void AddMessageService(Message item);

        void UpdateMessageService(Message item);

        void DeleteMessageService(int id);

        int GetUnreadMessagesService(int dialogId); 

        string GetLastUserMessagesService(int dialogId);
    }
}
