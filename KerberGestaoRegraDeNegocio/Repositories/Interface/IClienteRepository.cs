using KerberGestaoRegraDeNegocio.Models.Entities;

namespace KerberGestaoRegraDeNegocio.Repositories.Interface
{
    public interface IClienteRepository
    {
        List<Cliente> PegarTodos();
        Cliente Criar(Cliente cliente);
        Cliente PegarPeloId(int id);
        Cliente Atualizar(Cliente cliente);
    }
}
