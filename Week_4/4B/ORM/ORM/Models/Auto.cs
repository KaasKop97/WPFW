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
        public Model ModelAuto { get; set; }
        [ForeignKey("Fabrikanten")]
        public Fabrikant AutoFabrikant { get; set; }
        [NotMapped]
        public string volledigeNaam
        {
            get { return $"{AutoFabrikant} {ModelAuto}";  }
        }
    }
}