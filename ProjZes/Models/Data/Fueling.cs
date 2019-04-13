using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjZes.Models.Data
{
    [Table("Tankowanie")]
    public class Fueling
    {
        [Column("TAN_PK_id")]
        public int Id { get; set; }

        [Column("TAN_ilosc")]
        [Required]
        public float Amount { get; set; }

        [Column("TAN_data")]
        [Required]
        public DateTime Date { get; set; }

        [Column("TAN_wartosc")]
        [Required]
        public float Value { get; set; }

        [Column("PAL_FK_id")]
        [ForeignKey("Fuel")]
        [Required]
        public int FuelId { get; set; }
        public Fuel Fuel { get; set; }
    }
}