using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjZes.Models.Data
{
    [Table("TL_Rezerwacja_Myjni")]
    public class CarWashReservation
    {
        [Column("MRE_PK_id")]
        public int Id { get; set; }

        [Column("MYJ_FK_id")]
        [Required]
        public int CarWashId { get; set; }

        [Column("REZ_FK_id")]
        [Required]
        public int ReservationId { get; set; }
    }
}