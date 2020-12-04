using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studenten.Controllers;
using Studenten.Data;
using Studenten.Models;
using Tests.Helper;
using Xunit;

namespace Tests
{
    public class Tests
    {
        public string databaseName;

        [Fact]
        public void TestIndex()
        {
            var test = new StudentController(GetNewInMemoryDatabase(true));
            var result = test.Index();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void TestNewStudent()
        {
            var test = new StudentController(GetInMemoryDbWithData());
            //var testNewStudent = test.CreateStudent("Pietje puk", 1068, "1068@student.hhs.nl");
            //Assert.IsType<RedirectToActionResult>(testNewStudent);
        }

        [Fact]
        public void TestZoekStudent()
        {
            var test = new StudentController(GetInMemoryDbWithData());
            var result = test.ZoekStudent("J");
            Assert.IsType<ViewResult>(result);
            var wrongResult = test.ZoekStudent("Z");
            Assert.IsType<EmptyResult>(wrongResult);
        }

        [Fact]
        public void AantalStudenten()
        {
            var test = new StudentController(GetInMemoryDbWithData());
            var result = test.Aantal("Jan");
            Assert.Equal("De naam Jan komt 2 keer voor in de lijst.", result);
            var wrongResult = test.Aantal("Zulu");
            Assert.Equal("De naam Zulu komt 0 keer voor in de lijst.", wrongResult);
        }

        [Fact]
        public void EditStudenten()
        {
            var db = GetInMemoryDbWithData();
            var test = new StudentController(db);

            var editStudent = db.Studenten.Single(s => s.Id == 1);
            Assert.Equal("Jan", editStudent.StudentNaam);
            editStudent.StudentNaam = "Nepnaam";
            test.Edit(editStudent);
            Assert.Equal("Nepnaam", db.Studenten.Single(s => s.Id == 1).StudentNaam);
        }

        private ApplicationDbContext GetInMemoryDbWithData()
        {
            var context = GetNewInMemoryDatabase(true);
            context.AddRange(new List<Student>()
            {
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
            });
            context.SaveChanges();
            return GetNewInMemoryDatabase(false);
        }

        private ApplicationDbContext GetNewInMemoryDatabase(bool NewDb)
        {
            if (NewDb) databaseName = Guid.NewGuid().ToString(); // unieke naam

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(this.databaseName)
                .Options;

            return new ApplicationDbContext();
        }
    }
}