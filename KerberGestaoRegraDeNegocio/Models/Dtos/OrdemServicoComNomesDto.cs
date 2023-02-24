using Newtonsoft.Json;

namespace KerberGestaoRegraDeNegocio.Models.Dtos
{
    public class OrdemServicoComNomesDto
    {
        [JsonProperty("IdCliente", NullValueHandling = NullValueHandling.Ignore)]
        public int IdOrdemServico { get; set; }
        public string NomeCliente { get; set; }
        public string NomeOrcamento { get; set; }
        public string Titulo { get; set; } = null!;
        public string Detalhamento { get; set; } = null!;
        public int Status { get; set; }
    }
}
