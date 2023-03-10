using KerberGestaoRegraDeNegocio.Models.Enums;
using Newtonsoft.Json;

namespace KerberGestaoRegraDeNegocio.Models.Dtos
{
    public class ProjetoDto
    {
        [JsonProperty("IdProjeto", NullValueHandling = NullValueHandling.Ignore)]
        public int IdProjeto { get; set; }
        public ClienteSimplificadoDto Cliente { get; set; }
        public string NomeProjeto { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public StatusProjetoEnum StatusProjeto { get; set; }
    }
}
