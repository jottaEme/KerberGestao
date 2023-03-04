using KerberGestaoRegraDeNegocio.Models.Entities;

namespace KerberGestaoRegraDeNegocio.Repositories.Interface
{
    public interface IOrcamentoRepository
    {
        List<Orcamento> PegarTodos();
        List<Orcamento> PegarTodosAtivos();
        Orcamento PegarPeloId(int id);
        Orcamento Criar(Orcamento orcamento);
        Orcamento Atualizar(Orcamento orcamento);
    }
}
