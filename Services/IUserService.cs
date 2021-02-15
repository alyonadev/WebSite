using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebSite.Models;
using WebSite.Repository;

namespace Services
{
    public interface IUserService : IRepository<User>, IUserRepository
    {
    }
}
