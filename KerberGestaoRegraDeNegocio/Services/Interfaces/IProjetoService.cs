using KerberGestaoRegraDeNegocio.Models;
using KerberGestaoRegraDeNegocio.Models.Dtos;

namespace KerberGestaoRegraDeNegocio.Services.Interfaces
{
    public interface IProjetoService
    {
        List<ProjetoDto> PegarTodos();
        List<ProjetoDto> PegarTodosPorStatus(StatusProjetoEnum status);
        List<ProjetoDto> PegarPorNome(string nome);
        void Criar(ProjetoDto projeto);
        ProjetoDto PegarPeloId(int id);
        void Atualizar(ProjetoDto projeto);
    }
}
