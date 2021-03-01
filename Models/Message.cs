using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSite.DBModels
{
    [Table ("Message")]
    public class Message
    {
        [Key]
        public int? MessageId { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        [Required]
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

        

    }
}