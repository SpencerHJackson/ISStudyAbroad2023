﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISStudyAbroad2023.Models;

namespace ISStudyAbroad2023.Controllers
{
    public class QuotesController : Controller
    {
        private readonly StudentDbContext _context;

        public QuotesController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: Quotes
        public async Task<IActionResult> Index()
        {
              return _context.Quotes != null ? 
                          View(await _context.Quotes.ToListAsync()) :
                          Problem("Entity set 'StudentDbContext.Quotes'  is null.");
        }

        // GET: Quotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Quotes == null)
            {
                return NotFound();
            }

            var quote = await _context.Quotes
                .FirstOrDefaultAsync(m => m.QuoteId == id);
            if (quote == null)
            {
                return NotFound();
            }

            return View(quote);
        }

        // GET: Quotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuoteId,QuoteAuthor,QuoteText")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quote);
        }

        // GET: Quotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Quotes == null)
            {
                return NotFound();
            }

            var quote = await _context.Quotes.FindAsync(id);
            if (quote == null)
            {
                return NotFound();
            }
            return View(quote);
        }

        // POST: Quotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuoteId,QuoteAuthor,QuoteText")] Quote quote)
        {
            if (id != quote.QuoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuoteExists(quote.QuoteId))
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
            return View(quote);
        }

        // GET: Quotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Quotes == null)
            {
                return NotFound();
            }

            var quote = await _context.Quotes
                .FirstOrDefaultAsync(m => m.QuoteId == id);
            if (quote == null)
            {
                return NotFound();
            }

            return View(quote);
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Quotes == null)
            {
                return Problem("Entity set 'StudentDbContext.Quotes'  is null.");
            }
            var quote = await _context.Quotes.FindAsync(id);
            if (quote != null)
            {
                _context.Quotes.Remove(quote);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuoteExists(int id)
        {
          return (_context.Quotes?.Any(e => e.QuoteId == id)).GetValueOrDefault();
        }
    }
}
