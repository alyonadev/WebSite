using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models.UserViewModel
{
    public class EditUserViewModel
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public byte[] Photo { get; set; }

        public HttpPostedFileBase PhotoFile { get; set; }

        public string Address { get; set; }
    }
}