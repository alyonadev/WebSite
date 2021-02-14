using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int? UserId { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Surname { get; set; }

        [Required]
        public string Password { get; set; }
        
        public byte[] Photo { get; set; }

        public int Age { get; set; }

        [MaxLength(40)]
        public string Address { get; set; }

        [Required]
        public string Login { get; set; }

    }
}