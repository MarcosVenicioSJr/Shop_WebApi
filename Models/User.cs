using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
  public class User
  {
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo Username é obrigatório")]
    [MaxLength(20, ErrorMessage = "Este campo deve conter de 3 a 60 caracteres.")]
    [MinLength(3, ErrorMessage = "Este campo deve conter de 3 a 60 caracteres.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Campo Username é obrigatório")]
    [MaxLength(20, ErrorMessage = "Este campo deve conter de 3 a 60 caracteres.")]
    [MinLength(3, ErrorMessage = "Este campo deve conter de 3 a 60 caracteres.")]
    public string Password { get; set; }

    public string role { get; set; }
  }
}