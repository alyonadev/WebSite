using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels
{
    public class WebSiteContext : DbContext
    {
        public WebSiteContext() : base("WebSite") { }

        public DbSet<User> Users { get; set; }

        public DbSet<Dialog> Dialogs { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}
