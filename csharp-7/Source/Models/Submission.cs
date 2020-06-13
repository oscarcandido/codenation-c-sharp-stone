using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Codenation.Challenge.Models
{
    [Table("submission")]
    public class Submission
    {
        [Column("user_id")]
        [Required]
        [ForeignKey("User")]
        public int User_id { get; set; }
        public User User { get; set; }

        [Column("challenge_id")]
        [Required]
        [ForeignKey("Challenge")]
        public int Challenge_id { get; set; }
        public Challenge Challenge { get; set; }

        [Column("score")]
        [Required]
        public decimal score { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime Created_at { get; set; }
    }
}
