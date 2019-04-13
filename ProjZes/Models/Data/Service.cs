using System.ComponentModel.DataAnnotations.Schema;

namespace ProjZes.Models.Data
{
    [Table("Usluga")]
    public class Service
    {
        [Column("US_PK_id")]
        public int Id { get; set; }

        [Column("TAN_FK_id")]
        [ForeignKey("Fueling")]
        public int FuelingId { get; set; }
        public Fueling Fueling { get; set; }

        [Column("REZ_FK_id")]
        [ForeignKey("Reservation")]
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}