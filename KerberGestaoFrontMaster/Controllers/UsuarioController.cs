using KerberGestaoFrontMaster.Filters;
using KerberGestaoRegraDeNegocio.Models.Dtos;
using KerberGestaoRegraDeNegocio.Services;
using KerberGestaoRegraDeNegocio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KerberGestaoFrontMaster.Controllers
{
    [PaginaRestritaAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            var response = usuarioService.PegarTodos();
            return View(response);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioDto usuario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    usuarioService.Criar(usuario);
                    TempData["MensagemSucesso"] = $"Usuário {usuario.Nome} cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar o Usuário. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
