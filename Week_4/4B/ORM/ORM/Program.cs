using System;
using System.Linq;
using ORM.Models;

namespace ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Database.EnsureCreated();
                var fabrikanten = db.Fabrikanten.ToList();
                var kaas = db.Modellen.ToList();
                
                Console.WriteLine(kaas.Count);
                foreach (var modelletje in kaas)
                {
                    Console.WriteLine(modelletje.Merk);
                }
                
                var newCar = new Auto()
                {
                    Fabrikant = fabrikanten, Kenteken = "95-RAN-1", Model = model[0]
                };
                db.Autos.Add(newCar);
                
                var newBuyer = new Koper()
                {
                    Naam = "Jan", Adres = "Zeldalaan 21", Email = "jan@jan.nl", Heeft = newCar, KoperId = 1,
                    TelNummer = "0652559862"
                };
                db.Kopers.Add(newBuyer);
                db.SaveChanges();
            }
        }
    }
}