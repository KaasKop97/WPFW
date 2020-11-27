using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Studenten.Models;

namespace Studenten.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Studenten { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=/home/mitch/Projects/School/Jaar 2/WPFW/Week_5/5B/5B/Studenten/Studenten/Studenten.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1, StudentMail = "10000@student.hhs.nl", StudentNaam = "Jan", StudentNummer = 10000,
                    StudentPhonenr = 06123, StudentAge = 21, StudentGrade = 5.5
                },
                new Student()
                {
                    Id = 2, StudentMail = "20000@student.hhs.nl", StudentNaam = "Kees", StudentNummer = 20000,
                    StudentPhonenr = 06234, StudentAge = 17, StudentGrade = 7.2
                },
                new Student()
                {
                    Id = 3, StudentMail = "30000@student.hhs.nl", StudentNaam = "Pieter", StudentNummer = 30000,
                    StudentPhonenr = 06345, StudentAge = 18, StudentGrade = 8.8
                },
                new Student()
                {
                    Id = 4, StudentMail = "40000@student.hhs.nl", StudentNaam = "Jan", StudentNummer = 40000,
                    StudentPhonenr = 06456, StudentAge = 24, StudentGrade = 6.5
                },
                new Student()
                {
                    Id = 5, StudentMail = "50000@student.hhs.nl", StudentNaam = "Jeroen", StudentNummer = 50000,
                    StudentPhonenr = 06567, StudentAge = 20, StudentGrade = 4.3
                }
            );
        }
    }
}