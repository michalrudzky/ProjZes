using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjZes.Models.Data
{
    [Table("Zbiornik")]
    public class Tank
    {
        [Column("ZB_PK_id")]
        public int Id { get; set; }

        [Column("ZB_stan")]
        [Required]
        public float Amount { get; set; }

        [Column("PAL_FK_id")]
        [ForeignKey("Fuel")]
        [Required]
        public int FuelId { get; set; }
        public Fuel Fuel { get; set; }
    }
}