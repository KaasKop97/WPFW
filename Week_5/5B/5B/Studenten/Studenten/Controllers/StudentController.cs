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

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Studenten.ToList());
        }

        public IActionResult Edit(int id)
        {
            // Wait why am I iterating here oops...
            // Anyways this is to get the student we wanna edit.
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
            // Post request of the edited student.
            // Here we get the old student
            var oldRow = _context.Studenten.Single(s => s.Id == student.Id);
            // Update its values
            oldRow.StudentMail = student.StudentMail;
            oldRow.StudentNaam = student.StudentNaam;
            oldRow.StudentNummer = student.StudentNummer;
            oldRow.StudentPhonenr = student.StudentPhonenr;
            oldRow.StudentAge = student.StudentAge;
            oldRow.StudentGrade = student.StudentGrade;
            // Saving it to the database.
            _context.SaveChanges();
            return RedirectToAction("Index");
        }    

        public string Aantal(string naam)
        {
            int aantal = 0;
            // Get list of students and count number of occurences in the list.
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
                // Checking if student exists with email address
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
            // We set the letter in the viewdata so view can display it (EXTRA "CHALLENGE" :P)
            ViewData["searchedLetter"] = id;
            // Get the student as a list then search in that list for name startswith() upper and lowercase.
            List<Student> tempStudentList = _context.Studenten.ToList().Where(student => student.StudentNaam.StartsWith(id.ToUpper()) || student.StudentNaam.StartsWith(id.ToLower())).ToList();
            if (tempStudentList.Count > 0)
            {
                // Nice we found at least one student with that letter.
                return View(tempStudentList);    
            }
            // Rip sending empty result
            return new EmptyResult();

        }

        //Work damn it
        public IActionResult TopStudents()
        {
            Studenten.OrderByDesc(x => x.StudentGrade).Select(StudentNaam).Take(3);
            //I have no idea if Select is the right option
        }

        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudent(string studentNaam, int studentNummer, string studentMail, int StudentPhonenr, int StudentAge)
        {
            // Create the new student, add it to the context and save the changes.
            var newStudent = new Student
            {
                StudentMail = studentMail, StudentNaam = studentNaam, StudentNummer = studentNummer
                StudentPhonenr = StudentPhonenr, StudentAge = StudentAge, StudentGrade = StudentGrade
            };
            _context.Studenten.Add(newStudent);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}