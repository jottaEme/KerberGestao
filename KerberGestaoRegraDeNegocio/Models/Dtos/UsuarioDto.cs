using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace KerberGestaoRegraDeNegocio.Models.Dtos
{
    public class UsuarioDto
    {
        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o Login")]
        public string Login { get; set; }

        [EmailAddress(ErrorMessage = "O Email informado não é válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Perfil precisa ser selecionado")]
        public PerfilEnum Perfil { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }
    }
}
