using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Models;

public class Login
{
    public string Username { get; set; }
    public string Password { get; set; }
}
