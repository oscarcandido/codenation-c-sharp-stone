using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Codenation.Challenge.Models
{
    [Table("candidate")]
    public class Candidate
    {
        [Column("user_id")]
        [Required]
        [ForeignKey("User")]
        public int User_id { get; set; }
        public User User { get; set; }

        [Required]
        [Column("acceleration_id")]
        [ForeignKey("Acceleration")]
        public int Acceleration_id { get; set; }
        public Acceleration Acceleration { get; set; }

        [Column("company_id")]
        [Required]
        [ForeignKey("Company")]
        public int Company_id { get; set; }
        public Company Company { get; set; }

        [Column("status")]
        [Required]
        public int Status { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime Created_at { get; set; }
    }
}
