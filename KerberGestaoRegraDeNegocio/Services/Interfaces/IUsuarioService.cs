using KerberGestaoRegraDeNegocio.Models.Dtos;
using KerberGestaoRegraDeNegocio.Models.Entities;

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
    }
}
