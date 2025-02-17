using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtocolSystem.Models;

namespace ProtocolSystem.Controllers
{
    public class StatusProtocolosController : Controller
    {
        private readonly AppDbContext _context;

        public StatusProtocolosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StatusProtocolos
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Usuario")))
            {
                return RedirectToAction("Index", "Login");
            }

            return View(await _context.StatusProtocolos.ToListAsync());
        }

        // GET: StatusProtocolos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusProtocolo = await _context.StatusProtocolos
                .FirstOrDefaultAsync(m => m.IdStatus == id);
            if (statusProtocolo == null)
            {
                return NotFound();
            }

            return View(statusProtocolo);
        }

        // GET: StatusProtocolos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusProtocolos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStatus,NomeStatus")] StatusProtocolo statusProtocolo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusProtocolo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusProtocolo);
        }

        // GET: StatusProtocolos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusProtocolo = await _context.StatusProtocolos.FindAsync(id);
            if (statusProtocolo == null)
            {
                return NotFound();
            }
            return View(statusProtocolo);
        }

        // POST: StatusProtocolos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStatus,NomeStatus")] StatusProtocolo statusProtocolo)
        {
            if (id != statusProtocolo.IdStatus)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusProtocolo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusProtocoloExists(statusProtocolo.IdStatus))
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
            return View(statusProtocolo);
        }

        // GET: StatusProtocolos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusProtocolo = await _context.StatusProtocolos
                .FirstOrDefaultAsync(m => m.IdStatus == id);
            if (statusProtocolo == null)
            {
                return NotFound();
            }

            return View(statusProtocolo);
        }

        // POST: StatusProtocolos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusProtocolo = await _context.StatusProtocolos.FindAsync(id);
            _context.StatusProtocolos.Remove(statusProtocolo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusProtocoloExists(int id)
        {
            return _context.StatusProtocolos.Any(e => e.IdStatus == id);
        }
    }
}
