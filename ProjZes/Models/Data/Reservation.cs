using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjZes.Models.Data
{
    [Table("Rezerwacja")]
    public class Reservation
    {
        [Column("REZ_PK_id")]
        public int Id { get; set; }

        [Column("REZ_data")]
        [Required]
        public DateTime Date { get; set; }

        [Column("REZ_czas")]
        [Required]
        public TimeSpan Time { get; set; }

        [Column("KL_FK_id")]
        [ForeignKey("Customer")]
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}