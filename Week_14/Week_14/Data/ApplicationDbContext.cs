using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Week_14.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Student> Student { get; set; }

    public DbSet<Cursus> Cursus { get; set; }
    
    public DbSet<StudentCursussen> StudentCursussenSet { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentCursussen>().HasKey(sc => new {sc.StudentId, sc.CursusId});
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
                Id = i, Lengte = test.NextDouble(), Naam = names[test.Next(0, names.Count)]
            };
            modelBuilder.Entity<Student>().HasData(temp);
        }
    }


}