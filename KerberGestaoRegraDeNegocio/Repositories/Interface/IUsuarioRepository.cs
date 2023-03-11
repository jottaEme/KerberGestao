using KerberGestaoRegraDeNegocio.Models.Entities;

namespace KerberGestaoRegraDeNegocio.Repositories.Interface
{
    public interface IUsuarioRepository
    {
        Usuario BuscarPorLogin(string login);
        Usuario BuscarPorEmailELogin(string email, string login);
        Usuario BuscarPorEmail(string email);
        List<Usuario> PegarTodos();
        Usuario Criar(Usuario usuario);
        Usuario BuscarPeloId(int id);
        Usuario Atualizar(Usuario usuario);
        Usuario AlterarSenha(Usuario usuario);
        void ExcluirPorId(int id);
    }
}
