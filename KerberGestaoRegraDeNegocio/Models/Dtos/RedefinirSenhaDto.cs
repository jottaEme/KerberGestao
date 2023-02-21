using System.ComponentModel.DataAnnotations;

namespace KerberGestaoRegraDeNegocio.Models.Dtos
{
    public class RedefinirSenhaDto
    {
        [Required(ErrorMessage = "Digite o Login")]
        public string LoginUsuario { get; set; }

        [Required(ErrorMessage = "Digite o E-mail")]
        public string Email { get; set; }
    }
}
