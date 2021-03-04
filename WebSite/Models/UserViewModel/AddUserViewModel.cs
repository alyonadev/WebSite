using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models.UserViewModel
{
    public class AddUserViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}