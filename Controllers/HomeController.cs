using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using WebApp.Models;
using Microsoft.Extensions.Http;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        private static List<Pessoa> usuarios = new List<Pessoa>();


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public IActionResult EnviarDadosFormulario([FromForm] Pessoa usuario)
        {
            usuarios.Add(usuario);

            if (usuarios.Contains(usuario))
            {
                return View("Sucesso");
            }
            else
            {
                return View("Erro");
            }
        }

        [HttpGet("usuarios")]
        public IEnumerable<Pessoa> ListarUsuarios()
        {
            return usuarios;
        }

        public IActionResult Administracao()
        {
            var usuarios = ListarUsuarios();

            return View(usuarios); //testar usar o 'usuarios' direto do método da classe / campo
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}