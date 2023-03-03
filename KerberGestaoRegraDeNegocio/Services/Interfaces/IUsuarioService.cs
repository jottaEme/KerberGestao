using KerberGestaoRegraDeNegocio.Models.Dtos;

namespace KerberGestaoRegraDeNegocio.Services.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioDto FazerLogin(LoginDto loginEfetuado);
        List<UsuarioDto> PegarTodos();
        void Criar(UsuarioDto usuario);
        UsuarioDto PegarPeloId(int id);
        bool EnviarEmailDeTrocaDeSenha(string email, string login);
        void Atualizar(UsuarioDto usuario);
        void AlterarSenha(AlterarSenhaDto alterarSenha);
        void ExcluirPorId(int id);
    }
}
