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
    public class CitiesController : Controller
    {
        private readonly StudentDbContext _context;

        public CitiesController(StudentDbContext context)
        {
            _context = context;
        }

        //GET: List
        public async Task<IActionResult> List()
        {
            return _context.Citys != null ?
                        View(await _context.Citys.ToListAsync()) :
                        Problem("Entity set 'StudentDbContext.Citys'  is null.");
        }

        // GET: Cities
        public async Task<IActionResult> Index()
        {
              return _context.Citys != null ? 
                          View(await _context.Citys.ToListAsync()) :
                          Problem("Entity set 'StudentDbContext.Citys'  is null.");
        }

        // GET: Cities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Citys == null)
            {
                return NotFound();
            }

            var city = await _context.Citys
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityId,CityName,BeginDate,EndDate")] City city)
        {
            if (ModelState.IsValid)
            {
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Citys == null)
            {
                return NotFound();
            }

            var city = await _context.Citys.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CityId,CityName,BeginDate,EndDate")] City city)
        {
            if (id != city.CityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.CityId))
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
            return View(city);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Citys == null)
            {
                return NotFound();
            }

            var city = await _context.Citys
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Citys == null)
            {
                return Problem("Entity set 'StudentDbContext.Citys'  is null.");
            }
            var city = await _context.Citys.FindAsync(id);
            if (city != null)
            {
                _context.Citys.Remove(city);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int id)
        {
          return (_context.Citys?.Any(e => e.CityId == id)).GetValueOrDefault();
        }
    }
}
