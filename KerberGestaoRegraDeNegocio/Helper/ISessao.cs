using KerberGestaoRegraDeNegocio.Models.Dtos;

namespace KerberGestaoRegraDeNegocio.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioDto usuario);
        void RemoverSessaoDoUsuario();
        UsuarioDto BuscarSessaoDoUsuario();
    }
}
