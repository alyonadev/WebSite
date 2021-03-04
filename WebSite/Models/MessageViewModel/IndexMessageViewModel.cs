using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models.MessageViewModel
{
    public class IndexMessageViewModel
    {
        public int MessageId { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public bool Status { get; set; }
    }
}