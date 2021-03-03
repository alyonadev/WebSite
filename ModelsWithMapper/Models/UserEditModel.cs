using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ModelsWithMapper
{
    public class UserEditModel : UserBase
    {
        public byte[] Photo { get; set; }

        public HttpPostedFileBase PhotoFile { get; set; }

        public string PhotoUrl { get; set; }

        public string Address { get; set; }

    }
}
