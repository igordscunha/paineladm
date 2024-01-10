using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using System.Text;
using WebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {

        private static List<Pessoa> mensagens = new List<Pessoa>();

        [HttpPost]
        public IActionResult EnviarDadosFormulario([FromForm] Pessoa pessoa)
        {
            mensagens.Add(pessoa);

            if (mensagens.Contains(pessoa))
            {
                return View("Sucesso");
            }
            else
            {
                return View("Erro");
            }
        }

        [HttpGet("mensagens"), Authorize]
        public IEnumerable<Pessoa> ListarMensagens()
        {
            return mensagens;
        }


        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login([FromForm] Login usuario)
        {
            var usuarioMaster = new Login()
            {
                Username = "Teste123",
                Password = "Abc123"
            };

            if(!usuarioMaster.Password.Equals(usuario.Password) || !usuarioMaster.Username.Equals(usuario.Username))
            {
                return RedirectToAction("Administracao", new {erroLogin = true});
            }

            await new Services().Login(HttpContext, usuario);
            return RedirectToAction("Painel");            

        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await new Services().Logout(HttpContext);

            return RedirectToAction("Administracao");
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Administracao(bool erroLogin)
        {
            if (erroLogin)
            {
                ViewBag.Erro = "Usuário e/ou senha incorretos.";
            }
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Painel");
            }
            return View();
        }

        [Authorize]
        public IActionResult Painel()
        {
            return View(mensagens);
        }
    }
}