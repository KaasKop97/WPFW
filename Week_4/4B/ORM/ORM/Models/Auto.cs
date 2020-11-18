using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORM.Models
{
    public class Auto
    {
        [Key]
        public string Kenteken { get; set; }
        public Model Model { get; set; }
        public List<Fabrikant> Fabrikant { get; set; }
    }
}