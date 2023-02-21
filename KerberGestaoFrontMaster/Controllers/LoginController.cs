using KerberGestaoRegraDeNegocio.Helper;
using KerberGestaoRegraDeNegocio.Models.Dtos;
using KerberGestaoRegraDeNegocio.Repositories.Interface;
using KerberGestaoRegraDeNegocio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KerberGestaoFrontMaster.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService usuarioService;
        private readonly ISessao sessao;

        public LoginController(IUsuarioService usuarioService, ISessao sessao)
        {
            this.usuarioService = usuarioService;
            this.sessao = sessao;
        }

        public IActionResult Index()
        
        {
            if(sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        public IActionResult Sair()
        {
            sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginDto login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = usuarioService.FazerLogin(login);
                    if(usuario != null)
                    {
                        sessao.CriarSessaoDoUsuario(usuario);
                        return RedirectToAction("Index", "Home");
                    }
                }
                TempData["MensagemErro"] = $"Usuário e/ou Senha inválido(s)!";
                return View("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar o login. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaDto redefinirSenha)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = usuarioService.EnviarEmailDeTrocaDeSenha(redefinirSenha.Email, redefinirSenha.LoginUsuario);
                    if (usuario != null)
                    {
                        TempData["MensagemSucesso"] = $"Enviamos para seu email cadastrado uma nova senha";
                        return RedirectToAction("Index", "Login");
                    }
                }
                TempData["MensagemErro"] = $"Não conseguimos redefinir sua Senha. Por favor, verifique os dados informados";
                return View("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Não conseguimos redefinir sua Senha. Tente novamente! Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
