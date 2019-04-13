using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjZes.Models.Data
{
    [Table("Koszyk")]
    public class Cart
    {
        [Column("KOS_PK_id")]
        public int Id { get; set; }

        [Column("KOS_wartosc")]
        [Required]
        public float Value { get; set; }

        [Column("US_FK_id")]
        [ForeignKey("Service")]
        [Required]
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}