using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjZes.Models.Data
{
    [Table("Paliwo")]
    public class Fuel
    {
        [Column("PAL_PK_id")]
        public int Id { get; set; }

        [Column("PAL_rodzaj")]
        [Required]
        public string Type { get; set; }

        [Column("PAL_cena")]
        [Required]
        public float Price { get; set; }
    }
}