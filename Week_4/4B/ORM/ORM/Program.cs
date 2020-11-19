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
                db.Database.EnsureCreated();
                var fabrikanten = db.Fabrikanten.ToList();
                //TODO For some reason model is empty???? wtf
                var kaas = db.Modellen.First(model => model.ModelId == 3);
                // TODO EVEN A RAW QUERY RETURNS NOTHING WTF
                var test = db.Modellen.FromSqlRaw("SELECT * FROM Modellen WHERE Merk ='Tesla'").ToList();
                foreach (var VARIABLE in test)
                {
                    Console.WriteLine(VARIABLE.Merk);
                }
                
                
                // var newCar = new Auto()
                // {
                //     Fabrikant = fabrikanten, Kenteken = "95-RAN-1", Model = kaas
                // };
                // db.Autos.Add(newCar);
                //
                // var newBuyer = new Koper()
                // {
                //     Naam = "Jan", Adres = "Zeldalaan 21", Email = "jan@jan.nl", Heeft = newCar, KoperId = 1,
                //     TelNummer = "0652559862"
                // };
                // db.Kopers.Add(newBuyer);
                // db.SaveChanges();
            }
        }
    }
}