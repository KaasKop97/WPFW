using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Studenten.Data;
using Studenten.Models;

namespace Studenten.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController()
        {
            _context = new ApplicationDbContext();
        }

        public IActionResult Index()
        {
            return View(_context.Studenten.ToList());
        }

        public IActionResult Edit(int id)
        {
            foreach (var student in _context.Studenten.Where(student => student.StudentNummer == id))
            {
                ViewBag.student = student;
                return View();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var oldRow = _context.Studenten.Single(s => s.Id == student.Id);
            oldRow.StudentMail = student.StudentMail;
            oldRow.StudentNaam = student.StudentNaam;
            oldRow.StudentNummer = student.StudentNummer;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }    

        public string Aantal(string naam)
        {
            int aantal = 0;

            foreach (var student in _context.Studenten.ToList())
            {
                if (student.StudentNaam == naam)
                {
                    aantal++;
                }
            }

            return "De naam " + naam + " komt " + aantal + " keer voor in de lijst.";
        }

        public IActionResult Email(int id)
        {
            // id is the students id
            foreach (var student in _context.Studenten.ToList())
            {
                Console.WriteLine(student.StudentNummer);
                Console.WriteLine(id);
                if (student.StudentNummer == id)
                {
                    ViewData["Email_message"] = "Student bestaat met mail adres: " + student.StudentMail;
                    break;
                }
                else
                {
                    ViewData["Email_message"] = "Student bestaat niet met met nummer: " + id.ToString();
                }
            }

            return View();
        }

        // I call it an ID because then ASP.net handles it automatically.
        public IActionResult ZoekStudent(string id)
        {
            List<Student> tempStudentList = new List<Student>();
            ViewData["searchedLetter"] = id;
            foreach (var student in _context.Studenten.ToList())
            {
                // If the name starts with an upper or lower letter we find any.
                if (student.StudentNaam.StartsWith(id.ToUpper()) || student.StudentNaam.StartsWith(id.ToLower()))
                {
                    tempStudentList.Add(student);
                }
            }

            return View(tempStudentList);
        }

        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudent(string studentNaam, int studentNummer, string studentMail)
        {
            var newStudent = new Student
            {
                StudentMail = studentMail, StudentNaam = studentNaam, StudentNummer = studentNummer
            };
            _context.Studenten.Add(newStudent);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}