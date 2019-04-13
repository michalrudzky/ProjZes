using System.ComponentModel.DataAnnotations.Schema;

namespace ProjZes.Models.Data
{
    [Table("Uprawnienia")]
    public class Permission
    {
        [Column("UPR_PK_id")]
        public int Id { get; set; }

        [Column("UPR_uprawnienia")]
        public string Power { get; set; }

    }
}