using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSite
{
    public class MessageModel
    {
        public int MessageId { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

    }
}
