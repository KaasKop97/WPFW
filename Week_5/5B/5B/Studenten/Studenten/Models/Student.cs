using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Studenten.Models
{
    public class Student : Model
    {
        public int Id { get; set; }
        [Required]
        [Range(3000, 1000000, ErrorMessage = "Dat is geen studentnummer.")]
        public int StudentNummer { get; set; }
        [Required]
        public string StudentNaam { get; set; }
        [Required]
        public string StudentMail { get; set; }
        [Required]
        [Range(0600000000, 0699999999)]
        public int StudentPhonenr { get; set; }
        [Range(0, 99, ErrorMessage = "Das best wel oud niet?")]
        public int StudentAge { get; set; }
        public double StudentGrade { get; set; }
        List<Student> Vrienden { get; set; }
    }
}