using KerberGestaoRegraDeNegocio.Models.Dtos;

namespace KerberGestaoRegraDeNegocio.Services.Interfaces
{
    public interface IProjetoService
    {
        List<ProjetoDto> PegarTodos();
        void Criar(ProjetoDto projeto);
        ProjetoDto PegarPeloId(int id);
        void Atualizar(ProjetoDto projeto);
    }
}
