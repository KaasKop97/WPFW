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
                using (var command = db.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SELECT Merk FROM Modellen WHERE ModelId = 3";
                    db.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        Console.WriteLine("Doing the execution...");
                        while (result.Read())
                        {
                            Console.WriteLine(result.GetString(0));
                        }
                    }
                }

                var fabrikant = db.Fabrikanten.First(f => f.FabrikantId == 1);
                //TODO For some reason model is empty???? wtf
                var kaas = db.Modellen.FirstOrDefault();
                Console.WriteLine(kaas.Merk);
                // TODO EVEN A RAW QUERY RETURNS NOTHING WTF
                var test = db.Modellen.FromSqlRaw("SELECT * FROM Modellen WHERE Merk ='Tesla'").ToList();
                foreach (var VARIABLE in test)
                {
                    Console.WriteLine(VARIABLE.Merk);
                }


                // var newCar = new Auto()
                // {
                //     Fabrikant = fabrikant, Kenteken = "95-RAN-1", Model = kaas
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