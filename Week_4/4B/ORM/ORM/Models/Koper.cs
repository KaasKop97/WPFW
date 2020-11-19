using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Models
{
    public class Koper
    {
        public int KoperId { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public string TelNummer { get; set; }
        [ForeignKey("HeeftAuto")]
        [NotMapped]
        public Auto Heeft { get; set; }
    }
}