using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Models;

public class Login : PageModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public bool UsuarioAutenticado { get; set; }

    public IActionResult onPost()
    {
        string username1 = "Teste123!@#";
        string password1 = "Abcx123!@#";

        if (Username == username1 && Password == password1)
        {
            UsuarioAutenticado = true;
        }

        return Page();
    }

}
