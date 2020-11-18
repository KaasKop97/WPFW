using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Models
{
    [Table("AutoFabrikant")]
    public class Fabrikant
    {
        public int FabrikantId { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public string TelefoonNummer { get; set; }
    }
}