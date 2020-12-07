using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Week_14.Models;

namespace Week_14
{
    public class StudentCursussenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentCursussenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentCursussen
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentCursussenSet.ToListAsync());
        }

        // GET: StudentCursussen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCursussen = await _context.StudentCursussenSet
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentCursussen == null)
            {
                return NotFound();
            }

            return View(studentCursussen);
        }

        // GET: StudentCursussen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentCursussen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,CursusId")] StudentCursussen studentCursussen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentCursussen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentCursussen);
        }

        // GET: StudentCursussen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCursussen = await _context.StudentCursussenSet.FindAsync(id);
            if (studentCursussen == null)
            {
                return NotFound();
            }
            return View(studentCursussen);
        }

        // POST: StudentCursussen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,CursusId")] StudentCursussen studentCursussen)
        {
            if (id != studentCursussen.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentCursussen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentCursussenExists(studentCursussen.StudentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(studentCursussen);
        }

        // GET: StudentCursussen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCursussen = await _context.StudentCursussenSet
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentCursussen == null)
            {
                return NotFound();
            }

            return View(studentCursussen);
        }

        // POST: StudentCursussen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentCursussen = await _context.StudentCursussenSet.FindAsync(id);
            _context.StudentCursussenSet.Remove(studentCursussen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentCursussenExists(int id)
        {
            return _context.StudentCursussenSet.Any(e => e.StudentId == id);
        }
    }
}
