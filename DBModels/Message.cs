using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels
{
    [Table("Message")]
    public class Message
    {
        [Key]
        public Guid MessageId { get; set; }

        [ForeignKey("DialogId")]
        public Dialog DialogId { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime Date { get; set; }

        public bool Status { get; set; }
    }
}
