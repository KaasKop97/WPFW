using System.ComponentModel.DataAnnotations;

namespace ORM.Models
{
    public class Model
    {
        public int ModelId { get; set; }
        [Required]
        public string Merk { get; set; }
        [Required]
        public string Serie { get; set; }
        [Required]
        public string Type { get; set; }
    }
}