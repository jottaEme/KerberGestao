using KerberGestaoRegraDeNegocio.Data;
using KerberGestaoRegraDeNegocio.Models.Entities;
using KerberGestaoRegraDeNegocio.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KerberGestaoRegraDeNegocio.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly kerbergestaoContext dbContext;

        public UsuarioRepository(kerbergestaoContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Usuario> PegarTodos()
        {
            return dbContext.Usuarios.ToList();
        }

        public Usuario Criar(Usuario usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            dbContext.Usuarios.Add(usuario);
            dbContext.SaveChanges();
            return usuario;
        }

        public void ExcluirPorId(int id)
        {
            Usuario usuarioDb = BuscarPeloId(id);

            if (usuarioDb == null)
            {
                throw new System.Exception("Usuário não localizado");
            }
            dbContext.Usuarios.Remove(usuarioDb);
            dbContext.SaveChanges();
        }

        public Usuario BuscarPeloId(int id)
        {
            return dbContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public Usuario Atualizar(Usuario usuario)
        {
            Usuario usuarioNoBanco = BuscarPeloId(usuario.Id);

            if (usuarioNoBanco == null)
            {
                throw new System.Exception("Houve um erro na atualização do Usuário");
            }

            usuarioNoBanco.Nome = usuario.Nome;
            usuarioNoBanco.DataAtualizacao = DateTime.Now;
            usuarioNoBanco.Perfil = usuario.Perfil;
            usuarioNoBanco.Login = usuario.Login;

            dbContext.Usuarios.Update(usuarioNoBanco);
            dbContext.SaveChanges();

            return usuarioNoBanco;
        }

        public Usuario BuscarPorLogin(string login)
        {
            return dbContext.Usuarios.FirstOrDefault(x => x.Login.ToLower().Equals(login.ToLower()));
        }

        public Usuario BuscarPorEmailELogin(string email, string login)
        {
            return dbContext.Usuarios.FirstOrDefault(x => x.Login.ToLower().Equals(login.ToLower()) &&
                                                          x.Email.ToLower().Equals(email.ToLower()));
        }

        public Usuario AlterarSenha(Usuario usuario)
        {

            throw new NotImplementedException();
        }
    }
}
