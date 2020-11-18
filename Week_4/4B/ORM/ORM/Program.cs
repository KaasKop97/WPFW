using System;

namespace ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Database.EnsureCreated();
                Console.WriteLine("Maybe going to do something with database.");
                
            }
        }
    }
}