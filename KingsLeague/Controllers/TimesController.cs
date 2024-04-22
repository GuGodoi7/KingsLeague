using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KingsLeague.Models;
using KingsLeague.Persistencia;

namespace KingsLeague.Controllers
{
    public class TimesController : Controller
    {
        private readonly OracleFIAPDbContext _context;

        public TimesController(OracleFIAPDbContext context)
        {
            _context = context;
        }

        // GET: Times
        public async Task<IActionResult> Index()
        {
            return View(await _context.Times.ToListAsync());
        }

        // GET: Times/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var times = await _context.Times
                .FirstOrDefaultAsync(m => m.TimeId == id);
            if (times == null)
            {
                return NotFound();
            }

            return View(times);
        }

        // GET: Times/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Times/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeId,Nome,DataFundacao,Presidencia,Estadio,TecnicoId")] Times times)
        {
            if (ModelState.IsValid)
            {
                _context.Add(times);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(times);
        }

        // GET: Times/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var times = await _context.Times.FindAsync(id);
            if (times == null)
            {
                return NotFound();
            }
            return View(times);
        }

        // POST: Times/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeId,Nome,DataFundacao,Presidencia,Estadio,TecnicoId")] Times times)
        {
            if (id != times.TimeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(times);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimesExists(times.TimeId))
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
            return View(times);
        }

        // GET: Times/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var times = await _context.Times
                .FirstOrDefaultAsync(m => m.TimeId == id);
            if (times == null)
            {
                return NotFound();
            }

            return View(times);
        }

        // POST: Times/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var times = await _context.Times.FindAsync(id);
            if (times != null)
            {
                _context.Times.Remove(times);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimesExists(int id)
        {
            return _context.Times.Any(e => e.TimeId == id);
        }
    }
}
