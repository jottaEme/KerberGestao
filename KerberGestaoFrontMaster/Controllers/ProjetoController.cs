using KerberGestaoFrontMaster.Filters;
using KerberGestaoRegraDeNegocio.Services;
using KerberGestaoRegraDeNegocio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KerberGestaoFrontMaster.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ProjetoController : Controller
    {
        private readonly IProjetoService projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            this.projetoService = projetoService;
        }

        public IActionResult Index()
        {
            var response = projetoService.PegarTodos();
            return View(response);
        }
    }
}
