using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KingsLeague.Models;
using KingsLeague.Persistencia;

namespace KingsLeague.Controllers
{
    public class JogadoresController : Controller
    {
        private readonly OracleFIAPDbContext _context;

        public JogadoresController(OracleFIAPDbContext context)
        {
            _context = context;
        }

        // GET: Jogadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jogadores.ToListAsync());
        }

        // GET: Jogadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogadores = await _context.Jogadores.Include(x => x.Times)
                .FirstOrDefaultAsync(m => m.JogadorId == id);
            if (jogadores == null)
            {
                return NotFound();
            }

            return View(jogadores);
        }

        // GET: Jogadores/Create
        public IActionResult Create()
        {
            ViewData["TimeId"] = new SelectList(_context.Times, "TimeId", "Nome");
            return View();
        }

        // POST: Jogadores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JogadorId,Nome,DataNascimento,Salario,Nacionalidade,Posicao,Especialidade,Status,TimeId")] Jogadores jogadores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jogadores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TimeId"] = new SelectList(_context.Times, "TimeId", "Nome", jogadores.TimeId);
            return View(jogadores);
        }

        // GET: Jogadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogadores = await _context.Jogadores.FindAsync(id);
            if (jogadores == null)
            {
                return NotFound();
            }
            return View(jogadores);
        }

        // POST: Jogadores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JogadorId,Nome,DataNascimento,Salario,Nacionalidade,Posicao,Especialidade,Status,TimeId")] Jogadores jogadores)
        {
            if (id != jogadores.JogadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogadores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogadoresExists(jogadores.JogadorId))
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
            ViewData["TimeId"] = new SelectList(_context.Times, "TimeId", "Nome", jogadores.TimeId);
            return View(jogadores);
        }

        // GET: Jogadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogadores = await _context.Jogadores
                .FirstOrDefaultAsync(m => m.JogadorId == id);
            if (jogadores == null)
            {
                return NotFound();
            }

            return View(jogadores);
        }

        // POST: Jogadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jogadores = await _context.Jogadores.FindAsync(id);
            if (jogadores != null)
            {
                _context.Jogadores.Remove(jogadores);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogadoresExists(int id)
        {
            return _context.Jogadores.Any(e => e.JogadorId == id);
        }
    }
}
