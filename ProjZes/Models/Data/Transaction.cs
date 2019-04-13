using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace ProjZes.Models.Data
{
    [Table("Transakcja")]
    public class Transaction
    {
        [Column("TR_PK_id")]
        public int Id { get; set; }

        [Column("TR_data")]
        [Required]
        public DateTime Date { get; set; }

        [Column("TR_wartosc")]
        [Required]
        public float Value { get; set; }

        [Column("KOS_FK_id")]
        [ForeignKey("Cart")]
        [Required]
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        [Column("PR_FK_id")]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}