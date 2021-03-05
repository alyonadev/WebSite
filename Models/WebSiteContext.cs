using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace WebSite.DBModels
{
    public class WebSiteContext: DbContext
    {
        public WebSiteContext() : base("WebSite") {}

        public DbSet<User> Users { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}