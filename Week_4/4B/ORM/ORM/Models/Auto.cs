using System;
using System.Collections.Generic;

namespace ORM.Models
{
    public class Auto
    {
        private string Kenteken { get; set; }
        private Model Model { get; set; }
        private List<Fabrikant> Fabrikant { get; set; }
    }
}