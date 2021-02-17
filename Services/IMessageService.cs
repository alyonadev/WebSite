using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.DBModels;
using WebSite.Repository;

namespace Services
{
    public interface IMessageService
    {
        List<Message> GetAllService();
        Message GetByIdService(int id);
        void AddService(Message item);
        void UpdateService(Message item);
        void DeleteService(int id);
        
    }
}
