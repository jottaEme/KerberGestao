using Newtonsoft.Json;

namespace KerberGestaoRegraDeNegocio.Models.Dtos
{
    public class ProjetoDto
    {
        [JsonProperty("IdProjeto", NullValueHandling = NullValueHandling.Ignore)]
        public int IdProjeto { get; set; }
        public string NomeProjeto { get; set; } = null!;
        public StatusOrdemServicoEnum StatusProjeto { get; set; }
    }
}
