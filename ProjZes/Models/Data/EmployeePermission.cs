using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjZes.Models.Data
{
    [Table("Tl_Uprawnienia_Pracownikow")]
    public class EmployeePermission
    {
        [Column("UPP_PK_id")]
        public int Id { get; set; }

        [Column("PR_FK_id")]
        [Required]
        public int EmployeeId { get; set; }

        [Column("UPR_FK_id")]
        [Required]
        public int PermissionId { get; set; }
    }
}