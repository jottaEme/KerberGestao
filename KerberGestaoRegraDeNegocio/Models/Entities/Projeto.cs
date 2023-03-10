using KerberGestaoRegraDeNegocio.Models.Enums;

namespace KerberGestaoRegraDeNegocio.Models.Entities
{
    public partial class Projeto
    {
        public int IdProjeto { get; set; }
        public int IdCliente { get; set; }
        public string NomeProjeto { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public StatusProjetoEnum StatusProjeto { get; set; }
    }
}
