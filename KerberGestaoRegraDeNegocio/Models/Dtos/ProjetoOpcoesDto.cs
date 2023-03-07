using Newtonsoft.Json;

namespace KerberGestaoRegraDeNegocio.Models.Dtos
{
    public class ProjetoOpcoesDto
    {
        public List<ClienteDto>? Clientes { get; set; }
        public int IdCliente { get; set; }
        public string NomeProjeto { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public StatusProjetoEnum StatusProjeto { get; set; }
    }
}
