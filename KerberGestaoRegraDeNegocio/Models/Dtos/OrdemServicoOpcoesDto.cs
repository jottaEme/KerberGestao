using KerberGestaoRegraDeNegocio.Models.Enums;

namespace KerberGestaoRegraDeNegocio.Models.Dtos
{
    public class OrdemServicoOpcoesDto
    {
        public List<ClienteDto>? Clientes { get; set; }
        public List<OrcamentoDto>? Orcamentos { get; set; }
        public List<int>? OrcamentosList { get; set; }
        public int IdCliente { get; set; }
        public int IdOrcamento { get; set; }
        public string Titulo { get; set; } = null!;
        public string Detalhamento { get; set; } = null!;
        public StatusOrdemServicoEnum Status { get; set; }
    }
}
