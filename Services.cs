using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using WebApp.Models;

namespace WebApp;

public class Services
{
    public async Task Login(HttpContext context, Login userLogin)
    {
        var claims = new List<Claim>();

        claims.Add(new Claim(ClaimTypes.Name, userLogin.Username));


        var claimsIdentity = 
            new ClaimsPrincipal(
                new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)
                );

        var authProperties = new AuthenticationProperties
        {
            ExpiresUtc = DateTime.UtcNow.AddHours(3),
            IssuedUtc = DateTime.UtcNow,
            IsPersistent = false,
        };

        await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsIdentity, authProperties);
    }

    public async Task Logout(HttpContext context)
    {
        await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
