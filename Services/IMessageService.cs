using System.Collections.Generic;
using WebSite.DBModels;

namespace Services
{
    public interface IMessageService
    {
        List<Message> GetAllClientsService(int fromId, int toId);
        Message GetByIdService(int id);
        void AddService(Message item);
        void UpdateService(Message item);
        void DeleteService(int id);
    }
}
