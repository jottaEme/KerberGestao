using Newtonsoft.Json;

namespace KerberGestaoRegraDeNegocio.Models.Dtos
{
    public class OrcamentoDto
    {
        [JsonProperty("IdCliente", NullValueHandling = NullValueHandling.Ignore)]
        public int IdOrcamentos { get; set; }
        public string NomeOrcamento { get; set; } = null!;
        public int StatusOrcamento { get; set; }
    }
}
