using System.ComponentModel.DataAnnotations;

namespace KerberGestaoRegraDeNegocio.Models.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Digite o Login")]
        public string LoginUsuario { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }
    }
}
