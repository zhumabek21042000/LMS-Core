using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lms_core.Data;
using lms_core.Models;

namespace lms_core.Controllers
{
    public class MatriculationsController : Controller
    {
        private readonly CourseContext _context;

        public MatriculationsController(CourseContext context)
        {
            _context = context;
        }

        // GET: Matriculations
        public async Task<IActionResult> Index()
        {
            var courseContext = _context.Matriculations.Include(m => m.Course).Include(m => m.Student);
            return View(await courseContext.ToListAsync());
        }

        // GET: Matriculations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matriculation = await _context.Matriculations
                .Include(m => m.Course)
                .Include(m => m.Student)
                .FirstOrDefaultAsync(m => m.EnrollmentID == id);
            if (matriculation == null)
            {
                return NotFound();
            }

            return View(matriculation);
        }

        // GET: Matriculations/Create
        public IActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID");
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "ID");
            return View();
        }

        // POST: Matriculations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentID,CourseID,StudentID,Grade")] Matriculation matriculation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matriculation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", matriculation.CourseID);
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "ID", matriculation.StudentID);
            return View(matriculation);
        }

        // GET: Matriculations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matriculation = await _context.Matriculations.FindAsync(id);
            if (matriculation == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", matriculation.CourseID);
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "ID", matriculation.StudentID);
            return View(matriculation);
        }

        // POST: Matriculations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollmentID,CourseID,StudentID,Grade")] Matriculation matriculation)
        {
            if (id != matriculation.EnrollmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matriculation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatriculationExists(matriculation.EnrollmentID))
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
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID", matriculation.CourseID);
            ViewData["StudentID"] = new SelectList(_context.Students, "ID", "ID", matriculation.StudentID);
            return View(matriculation);
        }

        // GET: Matriculations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matriculation = await _context.Matriculations
                .Include(m => m.Course)
                .Include(m => m.Student)
                .FirstOrDefaultAsync(m => m.EnrollmentID == id);
            if (matriculation == null)
            {
                return NotFound();
            }

            return View(matriculation);
        }

        // POST: Matriculations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matriculation = await _context.Matriculations.FindAsync(id);
            _context.Matriculations.Remove(matriculation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatriculationExists(int id)
        {
            return _context.Matriculations.Any(e => e.EnrollmentID == id);
        }
    }
}
