using System.ComponentModel.DataAnnotations;


namespace WebApp.Models;

public class Pessoa
{
    [Required]
    public string Nome { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Mensagem { get; set; }
}
