using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModels
{
    [Table("User")]
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Surname { get; set; }

        [Required]
        public string Password { get; set; }

        public byte[] Photo { get; set; }

        [Required]
        [Range(6, 80)]
        public int Age { get; set; }

        [MaxLength(40)]
        public string Address { get; set; }

        [Required]
        public string Login { get; set; }

    }
}
