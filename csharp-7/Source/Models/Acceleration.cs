using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Codenation.Challenge.Models
{
    [Table("acceleration")]
    public class Acceleration
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Column("slug")]
        [MaxLength(50)]
        [Required]
        public string Slug { get; set; }

        [Column("challenge_id")]
        [Required]
        [ForeignKey("Challenge")]
        public int Challenge_id { get; set; }
        public Challenge Challenge { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime Created_at { get; set; }

        public ICollection<Candidate> Candidates { get; set; }
    }

}
