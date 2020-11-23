using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ORM.Models;

namespace ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ApplicationDbContext())
            {
                // Get the first factory
                var fabrikant = db.Fabrikanten.First(f => f.FabrikantId == 1);
                // Get the tesla brand/model car
                var model = db.Modellen.First(m => m.Merk == "Tesla");
                
                //Create new car
                var newCar = new Auto()
                {
                    AutoFabrikant = fabrikant, Kenteken = "95-RAN-1", ModelAuto = model
                };
                db.Autos.Add(newCar);
                // Sell it to this person
                var newBuyer = new Koper()
                {
                    Naam = "Jan", Adres = "Zeldalaan 21", Email = "jan@jan.nl", Heeft = newCar, KoperId = 1,
                    TelNummer = "0652559862"
                };
                // Yay you sold a car!
                db.Kopers.Add(newBuyer);
                db.SaveChanges();
            }
        }
    }
}