using KerberGestaoRegraDeNegocio.Models.Dtos;

namespace KerberGestaoRegraDeNegocio.Services.Interfaces
{
    public interface IOrcamentoService
    {
        List<OrcamentoDto> PegarTodos();
        OrcamentoDto PegarPeloId(int id);
    }
}
