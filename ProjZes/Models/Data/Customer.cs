using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjZes.Models.Data
{
    [Table("Klient")]
    public class Customer
    {
        [Column("KL_PK_id")]
        public int Id { get; set; }

        [Column("KL_nr")]
        [Required]
        public int Number { get; set; }

        [Column("KL_nip")]
        [Required]
        public long? Nip { get; set; }

        [Column("UZ_FK_id")]
        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}