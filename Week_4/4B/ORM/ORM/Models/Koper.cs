namespace ORM.Models
{
    public class Koper
    {
        private int KoperId { get; set; }
        private string Naam { get; set; }
        private string Adres { get; set; }
        private string Email { get; set; }
        private string TelNummer { get; set; }
        private Auto Heeft { get; set; }
    }
}