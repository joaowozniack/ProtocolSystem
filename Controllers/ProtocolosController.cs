using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProtocolSystem.Models;
using ProtocolSystem.wwwroot.Filters;

namespace ProtocolSystem.Controllers
{
    [Autenticacao]
    public class ProtocolosController : Controller
    {
        private readonly AppDbContext _context;

        public ProtocolosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Procolos
        public IActionResult Index(string search, string sortOrder, int page = 1, int pageSize = 10)
        {
            var protocolos = _context.Protocolos.Include(p => p.Cliente).Include(p => p.ProtocoloStatus).AsQueryable();

            // Filtro de busca
            if (!string.IsNullOrEmpty(search))
            {
                protocolos = protocolos.Where(p => p.Titulo.Contains(search) || p.Cliente.Nome.Contains(search));
            }

            // Ordenação dinâmica
            switch (sortOrder)
            {
                case "titulo_asc":
                    protocolos = protocolos.OrderBy(p => p.Titulo);
                    break;
                case "titulo_desc":
                    protocolos = protocolos.OrderByDescending(p => p.Titulo);
                    break;
                case "data_asc":
                    protocolos = protocolos.OrderBy(p => p.DataAbertura);
                    break;
                case "data_desc":
                    protocolos = protocolos.OrderByDescending(p => p.DataAbertura);
                    break;
                default:
                    protocolos = protocolos.OrderBy(p => p.IdProtocolo); // Ordem padrão
                    break;
            }

            // Paginação
            int totalItens = protocolos.Count();
            var protocolosPaginados = protocolos.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.Page = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalItens / (double)pageSize);
            ViewBag.SortOrder = sortOrder;
            ViewBag.Search = search;

            return View(protocolosPaginados);
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
            ViewBag.Clientes = new SelectList(_context.Clientes, "IdCliente", "Nome");
            ViewBag.StatusProtocolos = new SelectList(_context.StatusProtocolos, "IdStatus", "NomeStatus");
            return View();
        }

        // POST: Procolos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titulo,Descricao,ClienteId,ProtocoloStatusId")] Protocolo protocolo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(protocolo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Erro ao salvar protocolo: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("ModelState não é válido");
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
            }
            ViewBag.Clientes = new SelectList(_context.Clientes, "IdCliente", "Nome", protocolo.ClienteId);
            ViewBag.StatusProtocolos = new SelectList(_context.StatusProtocolos, "IdStatus", "NomeStatus", protocolo.ProtocoloStatusId);
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
