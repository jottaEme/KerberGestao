using Newtonsoft.Json;

namespace KerberGestaoRegraDeNegocio.Models.Dtos
{
    public class OrdemServicoDto
    {
        [JsonProperty("IdCliente", NullValueHandling = NullValueHandling.Ignore)]
        public int IdOrdemServico { get; set; }
        public int IdCliente { get; set; }
        public int IdOrcamento { get; set; }
        public string Titulo { get; set; } = null!;
        public string Detalhamento { get; set; } = null!;
        public int Status { get; set; }
    }
}
