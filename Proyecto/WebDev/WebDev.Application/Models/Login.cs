using System.ComponentModel.DataAnnotations;

namespace WebDev.Application.Models
{
  public class Login
  {
    [Required(ErrorMessage = "El Email es Requerido")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "El Password es Requerido")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
  }
}