using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtocolSystem.Models;

namespace ProtocolSystem.Controllers
{
    public class ProtocolosController : Controller
    {
        private readonly AppDbContext _context;

        public ProtocolosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Procolos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Protocolos.ToListAsync());
        }

        // GET: Procolos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocolo = await _context.Protocolos
                .FirstOrDefaultAsync(m => m.IdProtocolo == id);
            if (protocolo == null)
            {
                return NotFound();
            }

            return View(protocolo);
        }

        // GET: Procolos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Procolos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProtocolo,ClienteId,StatusId,DataAbertura,DataFechamento")] Protocolo protocolo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(protocolo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(protocolo);
        }

        // GET: Procolos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocolo = await _context.Protocolos.FindAsync(id);
            if (protocolo == null)
            {
                return NotFound();
            }
            return View(protocolo);
        }

        // POST: Procolos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProtocolo,ClienteId,StatusId,DataAbertura,DataFechamento")] Protocolo protocolo)
        {
            if (id != protocolo.IdProtocolo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(protocolo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProtocoloExists(protocolo.IdProtocolo))
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
            return View(protocolo);
        }

        // GET: Procolos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocolo = await _context.Protocolos
                .FirstOrDefaultAsync(m => m.IdProtocolo == id);
            if (protocolo == null)
            {
                return NotFound();
            }

            return View(protocolo);
        }

        // POST: Procolos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var protocolo = await _context.Protocolos.FindAsync(id);
            _context.Protocolos.Remove(protocolo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProtocoloExists(int id)
        {
            return _context.Protocolos.Any(e => e.IdProtocolo == id);
        }
    }
}
