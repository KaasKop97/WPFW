using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Models
{
    [Table("AutoFabrikant")]
    public class Fabrikant
    {
        private int FabrikantId { get; }
        private string Naam { get; set; }
        private string Adres { get; set; }
        private string Email { get; set; }
        private string TelefoonNummer { get; set; }
    }
}