using Newtonsoft.Json;

namespace KerberGestaoRegraDeNegocio.Models.Dtos
{
    public class OrdemServicoComNomesDto
    {
        [JsonProperty("IdCliente", NullValueHandling = NullValueHandling.Ignore)]
        public int IdOrdemServico { get; set; }
        public ClienteSimplificadoDto Cliente { get; set; }
        public OrcamentoSimplificadoDto Orcamento { get; set; }
        public string Titulo { get; set; } = null!;
        public string Detalhamento { get; set; } = null!;
        public StatusOrdemServicoEnum Status { get; set; }
    }
}
