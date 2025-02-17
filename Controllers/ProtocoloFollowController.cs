using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProtocolSystem.Models;
using ProtocolSystem.wwwroot.Filters;

namespace ProtocolSystem.Controllers
{
    [Autenticacao]
    public class ProtocoloFollowController : Controller
    {
        private readonly AppDbContext _context;

        public ProtocoloFollowController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ProtocoloFollows
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProtocoloFollows.ToListAsync());
        }

        //GET: ProtocoloFollows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocoloFollow = await _context.ProtocoloFollows
                .FirstOrDefaultAsync(m => m.IdFollow == id);
            if (protocoloFollow == null)
            {
                return NotFound();
            }

            return View(protocoloFollow);
        }

        //GET: ProtocoloFollows/Create
        public IActionResult Create()
        {
            ViewBag.Protocolos = new SelectList(_context.Protocolos, "IdProtocolo", "Titulo");
            return View();
        }

        //POST: ProtocoloFollows/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProtocoloFollow,ProtocoloId,Data,Observacao")] ProtocoloFollow protocoloFollow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(protocoloFollow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Protocolos = new SelectList(_context.Protocolos, "IdProtocolo", "Titulo", protocoloFollow.ProtocoloId);
            return View(protocoloFollow);
        }

        //GET: ProtocoloFollows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocoloFollow = await _context.ProtocoloFollows.FindAsync(id);
            if (protocoloFollow == null)
            {
                return NotFound();
            }
            return View(protocoloFollow);
        }

        //POST: ProtocoloFollows/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProtocoloFollow,ProtocoloId,Data,Observacao")] ProtocoloFollow protocoloFollow)
        {
            if (id != protocoloFollow.IdFollow)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(protocoloFollow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProtocoloFollowExists(protocoloFollow.IdFollow))
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
            return View(protocoloFollow);
        }

        //GET: ProtocoloFollows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocoloFollow = await _context.ProtocoloFollows
                .FirstOrDefaultAsync(m => m.IdFollow == id);
            if (protocoloFollow == null)
            {
                return NotFound();
            }

            return View(protocoloFollow);
        }

        //POST: ProtocoloFollows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var protocoloFollow = await _context.ProtocoloFollows.FindAsync(id);
            _context.ProtocoloFollows.Remove(protocoloFollow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProtocoloFollowExists(int id)
        {
            return _context.ProtocoloFollows.Any(e => e.IdFollow == id);
        }
    }
}
