using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels
{
    public class Dialog
    {
        [Table("Dialog")]
        public class Message
        {
            [Key]
            public Guid DialogId { get; set; }

            public int FromUserId { get; set; }

            [ForeignKey("FromUserId")]
            public virtual User From { get; set; }

            public int ToUserId { get; set; }

            [ForeignKey("ToUserId")]
            public virtual User To { get; set; }
        }
    }
}
