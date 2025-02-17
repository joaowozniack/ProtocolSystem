using Microsoft.AspNetCore.Mvc;

namespace ProtocolSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Autenticar(string nome, string senha)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Nome == nome && u.Senha == senha);
            if (usuario != null)
            {
                HttpContext.Session.SetString("Usuario", usuario.Nome);
                return RedirectToAction("Index", "Clientes");
            }

            ViewBag.Mensagem = "Usuário ou senha inválidos.";
            return View("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Usuario");
            return RedirectToAction("Index");
        }
    }

}
