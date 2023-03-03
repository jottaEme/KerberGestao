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

        [JsonProperty("Senha", NullValueHandling = NullValueHandling.Ignore)]
        public string? Senha { get; set; }

        [JsonProperty("DataCadastro", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DataCadastro { get; set; }

        [JsonProperty("DataAtualizacao", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DataAtualizacao { get; set; }
    }
}
