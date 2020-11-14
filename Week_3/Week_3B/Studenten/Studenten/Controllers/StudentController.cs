using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Studenten.Models;

namespace Studenten.Controllers
{
    public class StudentController : Controller
    {
        private static readonly List<Student> _studentenLijst;

        private static int oldIndex;

        static StudentController()
        {
            _studentenLijst = new List<Student>()
            {
                new Student() {StudentMail = "10000@student.hhs.nl", StudentNaam = "Jan", StudentNummer = 10000},
                new Student() {StudentMail = "20000@student.hhs.nl", StudentNaam = "Kees", StudentNummer = 20000},
                new Student() {StudentMail = "30000@student.hhs.nl", StudentNaam = "Pieter", StudentNummer = 30000},
                new Student() {StudentMail = "40000@student.hhs.nl", StudentNaam = "Jan", StudentNummer = 40000},
                new Student() {StudentMail = "50000@student.hhs.nl", StudentNaam = "Jeroen", StudentNummer = 50000}
            };
        }

        public IActionResult Index()
        {
            return View(_studentenLijst);
        }

        public IActionResult Edit(int id)
        {
            foreach (var student in _studentenLijst.Where(student => student.StudentNummer == id))
            {
                ViewBag.student = student;
                oldIndex = _studentenLijst.FindIndex(a => a.StudentNummer == student.StudentNummer);
                return View();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            // Hacky but works lol
            _studentenLijst.RemoveAt(oldIndex);
            _studentenLijst.Insert(oldIndex, student);
            return RedirectToAction("Index");
        }

        public string Aantal(string naam)
        {
            int aantal = 0;

            foreach (var student in _studentenLijst)
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
            foreach (var student in _studentenLijst)
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
            foreach (var student in _studentenLijst)
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
            _studentenLijst.Add(newStudent);
            return RedirectToAction("Index");
        }
    }
}