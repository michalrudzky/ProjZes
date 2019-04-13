using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjZes.Models.Data
{
    [Table("Znizka")]
    public class Discount
    {
        [Column("ZN_PK_id")]
        public int Id { get; set; }

        [Column("ZN_nazwa")]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [Column("ZN_wartosc")]
        [Required]
        public int Amount { get; set; }
    }
}