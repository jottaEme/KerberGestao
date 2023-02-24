using KerberGestaoFrontMaster.Filters;
using KerberGestaoRegraDeNegocio.Models.Dtos;
using KerberGestaoRegraDeNegocio.Services;
using KerberGestaoRegraDeNegocio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KerberGestaoFrontMaster.Controllers
{
    [PaginaParaUsuarioLogado]
    public class OrdemServicoController : Controller
    {
        private readonly IOrcamentoService orcamentoService;
        private readonly IClienteService clienteService;
        private readonly IOrdemServicoService ordemServicoService;

        public OrdemServicoController(IOrcamentoService orcamentoService, IClienteService clienteService, IOrdemServicoService ordemServicoService)
        {
            this.orcamentoService = orcamentoService;
            this.clienteService = clienteService;
            this.ordemServicoService = ordemServicoService;
        }

        public IActionResult Index()
        {
            var orcamentos = orcamentoService.PegarTodos();
            var clientes = clienteService.PegarTodos();
            var ordemServicoOpcoes = new OrdemServicoOpcoesDto()
            {
                Clientes = clientes,
                Orcamentos = orcamentos
            };
            return View(ordemServicoOpcoes);
        }

        public IActionResult Dashboard()
        {
            var ordensDeServiço = ordemServicoService.PegarTodosComNome();

            return View(ordensDeServiço);
        }

        public IActionResult CriarNoBanco(OrdemServicoOpcoesDto cliente)
        {

            if (ModelState.IsValid)
            {
                ordemServicoService.Criar(cliente);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
