using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite.Models;
using WebSite.Repository;

namespace Services
{
    public class UserService : UserRepository, IUserRepository
    {
        public UserService(WebSiteContext context) : base(context)
        {
        }
    }
}
