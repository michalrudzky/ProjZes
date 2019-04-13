using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjZes.Models.Data
{
    [Table("Pracownik")]
    public class Employee
    {
        [Column("PR_PK_id")]
        public int Id { get; set; }

        [Column("PR_pensja")]
        [Required]
        public float Salary { get; set; }

        [Column("PR_nr_konta")]
        [Required]
        public long AccountNumber { get; set; }

        [Column("PR_liczba_godzin")]
        [Required]
        public float Hours { get; set; }

        [Column("UZ_FK_id")]
        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Column("UPR_FK_id")]
        [ForeignKey("Permission")]
        [Required]
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}