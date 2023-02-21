using KerberGestaoRegraDeNegocio.Models.Dtos;

namespace KerberGestaoRegraDeNegocio.Services.Interfaces
{
    public interface IProjetoService
    {
        List<ProjetoDto> PegarTodos();
    }
}
