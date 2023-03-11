using AutoMapper;
using KerberGestaoRegraDeNegocio.Helper;
using KerberGestaoRegraDeNegocio.Models.Dtos;
using KerberGestaoRegraDeNegocio.Models.Entities;
using KerberGestaoRegraDeNegocio.Repositories;
using KerberGestaoRegraDeNegocio.Repositories.Interface;
using KerberGestaoRegraDeNegocio.Services.Interfaces;

namespace KerberGestaoRegraDeNegocio.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;
        private readonly IEmail emailServer;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, IEmail emailServer)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
            this.emailServer = emailServer;
        }

        public List<UsuarioDto> PegarTodos()
        {
            var usuario = usuarioRepository.PegarTodos();
            return mapper.Map<List<UsuarioDto>>(usuario);
        }

        public void Criar(UsuarioDto cliente)
        {
            var usuarioEntity = mapper.Map<Usuario>(cliente);
            var emailExistente = usuarioRepository.BuscarPorEmail(cliente.Email);
            var loginExistente = usuarioRepository.BuscarPorLogin(cliente.Login);

            if(emailExistente == null && loginExistente == null)
            {
                usuarioRepository.Criar(usuarioEntity);
            }
            else
            {
                throw new Exception("Email e/ou login já existente(s)! Tente criar um novo usuário com email e login diferentes!");
            }
        }

        public UsuarioDto PegarPeloId(int id)
        {
            var usuarioEntity = usuarioRepository.BuscarPeloId(id);
            return mapper.Map<UsuarioDto>(usuarioEntity);
        }

        public void Atualizar(UsuarioDto cliente)
        {
            var usuarioEntity = mapper.Map<Usuario>(cliente);
            usuarioRepository.Atualizar(usuarioEntity);
        }

        public void ExcluirPorId(int id)
        {
            usuarioRepository.ExcluirPorId(id);
        }

        public UsuarioDto FazerLogin(LoginDto loginEfetuado)
        {
            var usuarioEncontrado = usuarioRepository.BuscarPorLogin(loginEfetuado.LoginUsuario);
            if(usuarioEncontrado != null && usuarioEncontrado.SenhaValida(loginEfetuado.Senha))
            {
                return mapper.Map<UsuarioDto>(usuarioEncontrado);
            }

            return null;
        }

        public bool EnviarEmailDeTrocaDeSenha(string email, string login)
        {
            var usuario = usuarioRepository.BuscarPorEmailELogin(email, login);
            var novaSenha = usuario.GerarNovaSenha();

            var mensagem = $"Sua nova senha é: {novaSenha}";
            var emailTeveSucesso = emailServer.Enviar(usuario.Email, "Kerber Móveis Planejados - Nova Senha", mensagem);

            if (emailTeveSucesso)
            {
                usuarioRepository.Atualizar(usuario);
                return true;
            }
            return false;
        }

        public void AlterarSenha(AlterarSenhaDto alterarSenha)
        {
            var usuario = usuarioRepository.BuscarPeloId(alterarSenha.Id);
            if(usuario == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado!");
            if (!usuario.SenhaValida(alterarSenha.SenhaAtual)) throw new Exception("Senha atual está incorreta!");
            if(usuario.SenhaValida(alterarSenha.NovaSenha)) throw new Exception("Nova Senha deve ser diferente da senha atual!");

            usuario.SetNovaSenha(alterarSenha.NovaSenha);
            usuario.DataAtualizacao = DateTime.Now;
            usuarioRepository.Atualizar(usuario);            
        }
    }
}
