using KerberGestaoRegraDeNegocio.Models.Dtos;

namespace KerberGestaoRegraDeNegocio.Services.Interfaces
{
    public interface IOrdemServicoService
    {
        void Criar(OrdemServicoOpcoesDto osOpcoes);
        List<OrdemServicoDto> PegarTodos();
        List<OrdemServicoComNomesDto> PegarTodosComNome();
        OrdemServicoComNomesDto PegarPeloId(int id);
        void Atualizar(OrdemServicoComNomesDto osComNomes);
    }
}
