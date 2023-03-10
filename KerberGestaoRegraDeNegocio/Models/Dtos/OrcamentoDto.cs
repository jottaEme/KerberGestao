using KerberGestaoRegraDeNegocio.Models.Enums;
using Newtonsoft.Json;

namespace KerberGestaoRegraDeNegocio.Models.Dtos
{
    public class OrcamentoDto
    {
        [JsonProperty("IdOrcamento", NullValueHandling = NullValueHandling.Ignore)]
        public int IdOrcamentos { get; set; }
        public string NomeOrcamento { get; set; } = null!;
        public StatusOrcamentoEnum StatusOrcamento { get; set; }
    }
}
