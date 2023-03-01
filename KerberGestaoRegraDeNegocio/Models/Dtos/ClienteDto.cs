using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace KerberGestaoRegraDeNegocio.Models.Dtos
{
    public class ClienteDto
    {
        [JsonProperty("IdCliente", NullValueHandling = NullValueHandling.Ignore)]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "Digite o Nome do Cliente")]
        public string NomeCliente { get; set; } = null!;
        [Required(ErrorMessage = "Digite o CPF do Cliente")]
        public string CpfCliente { get; set; } = null!;
        [Required(ErrorMessage = "Digite o Endereço do Cliente")]
        public string EnderecoCliente { get; set; } = null!;
        public string? BairroCliente { get; set; }
        [Required(ErrorMessage = "Digite a Cidade do Cliente")]
        public string CidadeCliente { get; set; } = null!;
        [Required(ErrorMessage = "Digite o Estado do Cliente")]
        public string EstadoCliente { get; set; } = null!;
        [Phone(ErrorMessage = "O telefone informado não é válido!")]
        public string? TelefoneCliente { get; set; }
        [Phone(ErrorMessage = "O telefone informado não é válido!")]
        public string? CelularCliente { get; set; }
        [Required(ErrorMessage = "Digite o Status do Cliente")]
        public StatusClienteEnum Status { get; set; }
    }
}
