using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjZes.Models.Data
{
    [Table("Myjnia")]
    public class CarWash
    {
        [Column("MYJ_PK_id")]
        public int Id { get; set; }

        [Column("MYJ_uslugi")]
        [Required]
        [MaxLength(20)]
        public string Service { get; set; }

        [Column("MYJ_czas")]
        [Required]
        public TimeSpan Time { get; set; }

        [Column("MYJ_cena")]
        [Required]
        public float Price { get; set; }
    }
}