using KerberGestaoRegraDeNegocio.Models.Dtos;
using KerberGestaoRegraDeNegocio.Models.Enums;

namespace KerberGestaoRegraDeNegocio.Services.Interfaces
{
    public interface IProjetoService
    {
        List<ProjetoDto> PegarTodos();
        List<ProjetoDto> PegarTodosPorStatus(StatusProjetoEnum status);
        List<ProjetoDto> PegarPorNome(string nome);
        void Criar(ProjetoOpcoesDto projeto);
        ProjetoDto PegarPeloId(int id);
        void Atualizar(ProjetoDto projeto);
    }
}
