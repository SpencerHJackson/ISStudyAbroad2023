using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISStudyAbroad2023.Models;

namespace ISStudyAbroad2023.Controllers
{
    public class ThoughtsController : Controller
    {
        private readonly StudentDbContext _context;

        public ThoughtsController(StudentDbContext context)
        {
            _context = context;
        }

        //GET: Thoughts/List
        public async Task<IActionResult> List()
        {
            var studentDbContext = _context.Thoughts.Include(t => t.Person);
            return View(await studentDbContext.ToListAsync());
        }

        // GET: Thoughts
        public async Task<IActionResult> Index()
        {
            var studentDbContext = _context.Thoughts.Include(t => t.Person);
            return View(await studentDbContext.ToListAsync());
        }

        // GET: Thoughts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Thoughts == null)
            {
                return NotFound();
            }

            var thought = await _context.Thoughts
                .Include(t => t.Person)
                .FirstOrDefaultAsync(m => m.ThoughtId == id);
            if (thought == null)
            {
                return NotFound();
            }

            return View(thought);
        }

        // GET: Thoughts/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName");
            return View();
        }

        // POST: Thoughts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ThoughtId,StudentId,ThoughtDate")] Thought thought)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thought);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", thought.StudentId);
            return View(thought);
        }

        // GET: Thoughts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Thoughts == null)
            {
                return NotFound();
            }

            var thought = await _context.Thoughts.FindAsync(id);
            if (thought == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", thought.StudentId);
            return View(thought);
        }

        // POST: Thoughts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ThoughtId,StudentId,ThoughtDate")] Thought thought)
        {
            if (id != thought.ThoughtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thought);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThoughtExists(thought.ThoughtId))
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
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", thought.StudentId);
            return View(thought);
        }

        // GET: Thoughts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Thoughts == null)
            {
                return NotFound();
            }

            var thought = await _context.Thoughts
                .Include(t => t.Person)
                .FirstOrDefaultAsync(m => m.ThoughtId == id);
            if (thought == null)
            {
                return NotFound();
            }

            return View(thought);
        }

        // POST: Thoughts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Thoughts == null)
            {
                return Problem("Entity set 'StudentDbContext.Thoughts'  is null.");
            }
            var thought = await _context.Thoughts.FindAsync(id);
            if (thought != null)
            {
                _context.Thoughts.Remove(thought);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThoughtExists(int id)
        {
          return (_context.Thoughts?.Any(e => e.ThoughtId == id)).GetValueOrDefault();
        }
    }
}
