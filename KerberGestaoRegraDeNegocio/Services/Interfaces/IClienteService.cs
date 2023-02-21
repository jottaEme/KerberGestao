using KerberGestaoRegraDeNegocio.Models.Dtos;

namespace KerberGestaoRegraDeNegocio.Services.Interfaces
{
    public interface IClienteService
    {
        List<ClienteDto> PegarTodos();
        void Criar(ClienteDto cliente);
        ClienteDto PegarPeloId(int id);
        void Atualizar(ClienteDto cliente);
    }
}
