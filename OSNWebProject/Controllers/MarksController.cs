using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Data.DataBase;

namespace OSNWebProject.Controllers
{
    public class MarksController : Controller
    {
        private readonly AssessmentProjectDbContext _context;

        public MarksController(AssessmentProjectDbContext context)
        {
            _context = context;
        }

        // GET: Marks
        public async Task<IActionResult> Index()
        {
            var assessmentProjectDbContext = _context.Marks.Include(m => m.Student).Include(m => m.Subject).Include(m => m.Term);
            return View(await assessmentProjectDbContext.ToListAsync());
        }

        // GET: Marks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marks = await _context.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .Include(m => m.Term)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (marks == null)
            {
                return NotFound();
            }

            return View(marks);
        }

        // GET: Marks/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.students, "ID", "Name");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "ID", "Name");
            ViewData["TermId"] = new SelectList(_context.Terms, "ID", "Name");
            return View();
        }

        // POST: Marks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,StudyYear,StudentId,SubjectId,TermId,Mark,IsAbsent,Comment,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] Marks marks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.students, "ID", "Name", marks.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "ID", "Name", marks.SubjectId);
            ViewData["TermId"] = new SelectList(_context.Terms, "ID", "Name", marks.TermId);
            return View(marks);
        }

        // GET: Marks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marks = await _context.Marks.FindAsync(id);
            if (marks == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.students, "ID", "Name", marks.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "ID", "Name", marks.SubjectId);
            ViewData["TermId"] = new SelectList(_context.Terms, "ID", "Name", marks.TermId);
            return View(marks);
        }

        // POST: Marks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,StudyYear,StudentId,SubjectId,TermId,Mark,IsAbsent,Comment,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn")] Marks marks)
        {
            if (id != marks.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarksExists(marks.ID))
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
            ViewData["StudentId"] = new SelectList(_context.students, "ID", "Name", marks.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "ID", "Name", marks.SubjectId);
            ViewData["TermId"] = new SelectList(_context.Terms, "ID", "Name", marks.TermId);
            return View(marks);
        }

        // GET: Marks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marks = await _context.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .Include(m => m.Term)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (marks == null)
            {
                return NotFound();
            }

            return View(marks);
        }

        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marks = await _context.Marks.FindAsync(id);
            _context.Marks.Remove(marks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarksExists(int id)
        {
            return _context.Marks.Any(e => e.ID == id);
        }
    }
}
