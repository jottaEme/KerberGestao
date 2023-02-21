using KerberGestaoRegraDeNegocio.Models.Entities;

namespace KerberGestaoRegraDeNegocio.Repositories.Interface
{
    public interface IProjetoRepository
    {
        List<Projeto> PegarTodos();
    }
}
