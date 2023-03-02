using KerberGestaoRegraDeNegocio.Models.Dtos;

namespace KerberGestaoRegraDeNegocio.Services.Interfaces
{
    public interface IOrcamentoService
    {
        List<OrcamentoDto> PegarTodos();
        OrcamentoDto PegarPeloId(int id);
        void Criar(OrcamentoDto orcamento);
        void Atualizar(OrcamentoDto orcamento);
    }
}
