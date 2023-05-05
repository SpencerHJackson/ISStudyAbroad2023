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
    public class CityActivitiesController : Controller
    {
        private readonly StudentDbContext _context;

        public CityActivitiesController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: CityActivities
        public async Task<IActionResult> Index()
        {
            var studentDbContext = _context.CityActivities.Include(c => c.City);
            return View(await studentDbContext.ToListAsync());
        }

        // GET: CityActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CityActivities == null)
            {
                return NotFound();
            }

            var cityActivity = await _context.CityActivities
                .Include(c => c.City)
                .FirstOrDefaultAsync(m => m.CityActivityId == id);
            if (cityActivity == null)
            {
                return NotFound();
            }

            return View(cityActivity);
        }

        // GET: CityActivities/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Citys, "CityId", "CityName");
            return View();
        }

        // POST: CityActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityActivityId,CityId,CityActivityName,CityActivityLocation,CityActivityDescription")] CityActivity cityActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cityActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Citys, "CityId", "CityName", cityActivity.CityId);
            return View(cityActivity);
        }

        // GET: CityActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CityActivities == null)
            {
                return NotFound();
            }

            var cityActivity = await _context.CityActivities.FindAsync(id);
            if (cityActivity == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Citys, "CityId", "CityName", cityActivity.CityId);
            return View(cityActivity);
        }

        // POST: CityActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CityActivityId,CityId,CityActivityName,CityActivityLocation,CityActivityDescription")] CityActivity cityActivity)
        {
            if (id != cityActivity.CityActivityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cityActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityActivityExists(cityActivity.CityActivityId))
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
            ViewData["CityId"] = new SelectList(_context.Citys, "CityId", "CityName", cityActivity.CityId);
            return View(cityActivity);
        }

        // GET: CityActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CityActivities == null)
            {
                return NotFound();
            }

            var cityActivity = await _context.CityActivities
                .Include(c => c.City)
                .FirstOrDefaultAsync(m => m.CityActivityId == id);
            if (cityActivity == null)
            {
                return NotFound();
            }

            return View(cityActivity);
        }

        // POST: CityActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CityActivities == null)
            {
                return Problem("Entity set 'StudentDbContext.CityActivities'  is null.");
            }
            var cityActivity = await _context.CityActivities.FindAsync(id);
            if (cityActivity != null)
            {
                _context.CityActivities.Remove(cityActivity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityActivityExists(int id)
        {
          return (_context.CityActivities?.Any(e => e.CityActivityId == id)).GetValueOrDefault();
        }
    }
}
