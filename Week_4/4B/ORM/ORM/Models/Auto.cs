using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Models
{
    public class Auto
    {
        [Key]
        [StringLength(8)]
        public string Kenteken { get; set; }
        [ForeignKey("Model")]
        [NotMapped]
        public Model Model { get; set; }
        [ForeignKey("Fabrikanten")]
        [NotMapped]
        public List<Fabrikant> Fabrikant { get; set; }
    }
}