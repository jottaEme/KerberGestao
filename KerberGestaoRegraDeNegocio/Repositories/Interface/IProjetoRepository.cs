using KerberGestaoRegraDeNegocio.Models.Dtos;
using KerberGestaoRegraDeNegocio.Models.Entities;
using KerberGestaoRegraDeNegocio.Models.Enums;

namespace KerberGestaoRegraDeNegocio.Repositories.Interface
{
    public interface IProjetoRepository
    {
        List<Projeto> PegarTodos();
        List<Projeto> PegarTodosPorStatus(StatusProjetoEnum status);
        List<Projeto> PegarPorNome(string nome);
        Projeto Criar(Projeto projeto);
        Projeto PegarPeloId(int id);
        Projeto Atualizar(Projeto projeto);
    }
}
