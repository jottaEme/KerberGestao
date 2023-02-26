using KerberGestaoRegraDeNegocio.Models.Entities;

namespace KerberGestaoRegraDeNegocio.Repositories.Interface
{
    public interface IProjetoRepository
    {
        List<Projeto> PegarTodos();
        Projeto Criar(Projeto projeto);
        Projeto PegarPeloId(int id);
        Projeto Atualizar(Projeto projeto);
    }
}
