using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Week_15.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Week_15.Models.Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasKey(sc => new {sc.StudentId});
            var names = new List<string>()
            {
                "Aleta",
                "Jan",
                "Pieter",
                "Kees",
                "Max",
                "Sabertooth",
                "Janmetdekorteachternaam"
            };
            var test = new Random();
            for (var i = 1; i < 30; i++)
            {
                var temp = new Student()
                {
                    StudentId = i, Leeftijd = test.Next(0, 50), Naam = names[test.Next(0, names.Count)]
                };
                modelBuilder.Entity<Student>().HasData(temp);
            }
        }
    }
