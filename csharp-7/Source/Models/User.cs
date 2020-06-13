using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("full_name")]
        [Required]
        [MaxLength(100)]
        public string Full_name { get; set; }

        [Column("email")]
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Column("nickname")]
        [Required]
        [MaxLength(50)]
        public string Nickname { get; set; }

        [Column("password")]
        [Required]
        [MaxLength(255)]
        public string Password { get; set; }
        
        [Column("created_at")]
        [Required]
        public DateTime Created_at { get; set; }

        public ICollection<Candidate> Candidates { get; set; }
        public ICollection<Submission> Submissions { get; set; }

    }
}
