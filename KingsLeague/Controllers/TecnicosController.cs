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
    public class TecnicosController : Controller
    {
        private readonly OracleFIAPDbContext _context;

        public TecnicosController(OracleFIAPDbContext context)
        {
            _context = context;
        }

        // GET: Tecnicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tecnicos.ToListAsync());
        }

        // GET: Tecnicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnicos = await _context.Tecnicos
                .FirstOrDefaultAsync(m => m.TecnicoId == id);
            if (tecnicos == null)
            {
                return NotFound();
            }

            return View(tecnicos);
        }

        // GET: Tecnicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tecnicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("TecnicoId,Nome,DataNascimento,Salario,Nacionalidade,TempoCarreira,Estrategia")] Tecnicos tecnicos)
        {
            Times times = _context.Times.SingleOrDefault(x => x.TimeId == id);

            if (times == null) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Add(tecnicos);
                await _context.SaveChangesAsync();
                times.TecnicoId = tecnicos.TecnicoId;

                _context.Update(times);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tecnicos);
        }

        // GET: Tecnicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnicos = await _context.Tecnicos.FindAsync(id);
            if (tecnicos == null)
            {
                return NotFound();
            }
            return View(tecnicos);
        }

        // POST: Tecnicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TecnicoId,Nome,DataNascimento,Salario,Nacionalidade,TempoCarreira,Estrategia")] Tecnicos tecnicos)
        {
            if (id != tecnicos.TecnicoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tecnicos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TecnicosExists(tecnicos.TecnicoId))
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
            return View(tecnicos);
        }

        // GET: Tecnicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnicos = await _context.Tecnicos
                .FirstOrDefaultAsync(m => m.TecnicoId == id);
            if (tecnicos == null)
            {
                return NotFound();
            }

            return View(tecnicos);
        }

        // POST: Tecnicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tecnicos = await _context.Tecnicos.FindAsync(id);
            if (tecnicos != null)
            {
                _context.Tecnicos.Remove(tecnicos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TecnicosExists(int id)
        {
            return _context.Tecnicos.Any(e => e.TecnicoId == id);
        }
    }
}
