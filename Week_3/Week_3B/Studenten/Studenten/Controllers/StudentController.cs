using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Studenten.Models;

namespace Studenten.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> studenten;
        public StudentController()
        {
            studenten = new List<Student>()
            {
                new Student() {StudentMail = "10000@student.hhs.nl", StudentNaam = "Jan", StudentNummer = 10000},
                new Student() {StudentMail = "20000@student.hhs.nl", StudentNaam = "Kees", StudentNummer = 20000},
                new Student() {StudentMail = "30000@student.hhs.nl", StudentNaam = "Pieter", StudentNummer = 30000},
                new Student() {StudentMail = "40000@student.hhs.nl", StudentNaam = "Jan", StudentNummer = 40000},
                new Student() {StudentMail = "50000@student.hhs.nl", StudentNaam = "Jeroen", StudentNummer = 50000},
            };

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Aantal(string naam) {
            int aantal;

            foreach(var student in studenten)
            {
                if (Student.StudentNaam == naam) {
                    aantal++;
                }
            }

            return "De naam " + naam + " komt " + aantal + " keer voor in de lijst.";
        }

        // I call it an ID because then ASP.net handles it automatically.
        public IActionResult ZoekStudent(string id)
        {
            List<Student> tempStudentList = new List<Student>();
            ViewData["searchedLetter"] = id;
            foreach (var student in studenten)
            {
                // If the name starts with an upper or lower letter we find any.
                if (student.StudentNaam.StartsWith(id.ToUpper()) || student.StudentNaam.StartsWith(id.ToLower()))
                {
                    tempStudentList.Add(student);
                }
            }
            return View(tempStudentList);
        }
    }
}