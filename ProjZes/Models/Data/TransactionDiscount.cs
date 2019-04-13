using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjZes.Models.Data
{
    [Table("TL_Znizka")]
    public class TransactionDiscount
    {
        [Column("TRZ_PK_id")]
        public int Id { get; set; }

        [Column("ZN_FK_id")]
        [Required]
        public int DiscountId { get; set; }

        [Column("TR_FK_id")]
        [Required]
        public int TransactionId { get; set; }
    }
}