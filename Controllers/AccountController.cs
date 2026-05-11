using Microsoft.AspNetCore.Mvc;

namespace GerenciadorEnderecos.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string usuario, string senha)
        {
            if (usuario == "testeAec" && senha == "aec")
            {
                return RedirectToAction("Index", "Enderecos");
            }

            ViewBag.Error = "Usuário ou senha inválidos. (Dica: testeAec / aec)";
            return View();
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}