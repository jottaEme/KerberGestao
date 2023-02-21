using KerberGestaoRegraDeNegocio.Models.Entities;

namespace KerberGestaoRegraDeNegocio.Repositories.Interface
{
    public interface IOrdemServicoRepository
    {
        Ordemservico Criar(Ordemservico ordemServico);
        List<Ordemservico> PegarTodos();
    }
}
