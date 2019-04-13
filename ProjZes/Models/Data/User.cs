using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjZes.Models.Data
{
    [Table("Uzytkownik")]
    public class User
    {
        [Column("UZ_PK_id")]
        public int Id { get; set; }

        [Column("UZ_imie")]
        [MaxLength(20)]
        [Required]
        public string FirstName { get; set; }

        [Column("UZ_nazwisko")]
        [MaxLength(20)]
        [Required]
        public string LastName { get; set; }

        [Column("UZ_adres")]
        [MaxLength(20)]
        [Required]
        public string Address { get; set; }

        [Column("UZ_nr_tel")]
        [Required]
        public int PhoneNumber { get; set; }

        [Column("UZ_email")]
        [MaxLength(20)]
        [Required]
        public string Email { get; set; }

        [Column("UZ_haslo")]
        [MaxLength(20)]
        [Required]
        public string Password { get; set; }

        [Column("UZ_punkty")]
        [Required]
        public int Points { get; set; }
    }
}