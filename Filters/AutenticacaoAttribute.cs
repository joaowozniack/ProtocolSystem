using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProtocolSystem.wwwroot.Filters
{
    public class AutenticacaoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session.GetString("Usuario");

            // Se não estiver autenticado, redireciona para a página de login
            if (string.IsNullOrEmpty(session))
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
