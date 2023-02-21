using KerberGestaoRegraDeNegocio.Models.Entities;

namespace KerberGestaoRegraDeNegocio.Repositories.Interface
{
    public interface IOrcamentoRepository
    {
        List<Orcamento> PegarTodos();
    }
}
