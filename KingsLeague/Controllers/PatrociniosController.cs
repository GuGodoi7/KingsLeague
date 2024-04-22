using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KingsLeague.Models;
using KingsLeague.Persistencia;

namespace KingsLeague.Controllers
{
    public class PatrociniosController : Controller
    {
        private readonly OracleFIAPDbContext _context;

        public PatrociniosController(OracleFIAPDbContext context)
        {
            _context = context;
        }

        // GET: Patrocinios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patrocinios.ToListAsync());
        }

        // GET: Patrocinios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patrocinios = await _context.Patrocinios
                .FirstOrDefaultAsync(m => m.PatrocinioId == id);
            if (patrocinios == null)
            {
                return NotFound();
            }

            return View(patrocinios);
        }

        // GET: Patrocinios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patrocinios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatrocinioId,Marca,Verba,PrazoContrato,TipoContrato,TimeId")] Patrocinios patrocinios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patrocinios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patrocinios);
        }

        // GET: Patrocinios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patrocinios = await _context.Patrocinios.FindAsync(id);
            if (patrocinios == null)
            {
                return NotFound();
            }
            return View(patrocinios);
        }

        // POST: Patrocinios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatrocinioId,Marca,Verba,PrazoContrato,TipoContrato,TimeId")] Patrocinios patrocinios)
        {
            if (id != patrocinios.PatrocinioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patrocinios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatrociniosExists(patrocinios.PatrocinioId))
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
            return View(patrocinios);
        }

        // GET: Patrocinios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patrocinios = await _context.Patrocinios
                .FirstOrDefaultAsync(m => m.PatrocinioId == id);
            if (patrocinios == null)
            {
                return NotFound();
            }

            return View(patrocinios);
        }

        // POST: Patrocinios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patrocinios = await _context.Patrocinios.FindAsync(id);
            if (patrocinios != null)
            {
                _context.Patrocinios.Remove(patrocinios);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatrociniosExists(int id)
        {
            return _context.Patrocinios.Any(e => e.PatrocinioId == id);
        }
    }
}
