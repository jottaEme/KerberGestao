namespace KerberGestaoRegraDeNegocio.Models.Dtos
{
    public class OrdemServicoOpcoesDto
    {
        public List<ClienteDto>? Clientes { get; set; }
        public List<OrcamentoDto>? Orcamentos { get; set; }
        public int IdCliente { get; set; }
        public int IdOrcamento { get; set; }
        public string Titulo { get; set; } = null!;
        public string Detalhamento { get; set; } = null!;
        public int Status { get; set; }
    }
}
