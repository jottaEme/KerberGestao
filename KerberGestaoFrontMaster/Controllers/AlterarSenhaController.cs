using KerberGestaoRegraDeNegocio.Helper;
using KerberGestaoRegraDeNegocio.Models.Dtos;
using KerberGestaoRegraDeNegocio.Models.Entities;
using KerberGestaoRegraDeNegocio.Services;
using KerberGestaoRegraDeNegocio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KerberGestaoFrontMaster.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioService usuarioService;
        private readonly ISessao sessao;

        public AlterarSenhaController(IUsuarioService usuarioService, ISessao sessao)
        {
            this.usuarioService = usuarioService;
            this.sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaDto alterarSenha)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuarioLogado = sessao.BuscarSessaoDoUsuario();
                    alterarSenha.Id = usuarioLogado.Id;
                    usuarioService.AlterarSenha(alterarSenha);
                    TempData["MensagemSucesso"] = $"Senha alterada com sucesso!";
                    return View("Index", alterarSenha);
                }

                TempData["MensagemErro"] = $"Não foi possível alterar a Senha do Usuário.";
                return View("Index", alterarSenha);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível alterar a Senha do Usuário. Detalhe do erro: {e.Message}";
                return View("Index", alterarSenha);
            }
        }
    }
}
