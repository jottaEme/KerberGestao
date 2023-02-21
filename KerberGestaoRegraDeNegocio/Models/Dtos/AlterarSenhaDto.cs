using System.ComponentModel.DataAnnotations;

namespace KerberGestaoRegraDeNegocio.Models.Dtos
{
    public class AlterarSenhaDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a senha atual do usuário")]
        public string SenhaAtual { get; set; }
        [Required(ErrorMessage = "Digite a nova senha do usuário")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage = "Confirme a nova senha do usuário")]
        [Compare("NovaSenha", ErrorMessage = "Nova Senha e Confirmação de nova Senha estão diferentes")]
        public string ConfirmarNovaSenha { get; set; }
    }
}
