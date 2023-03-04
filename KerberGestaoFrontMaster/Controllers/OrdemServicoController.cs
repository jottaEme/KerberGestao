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

        public IActionResult Criar()
        {
            var orcamentos = orcamentoService.PegarTodosAtivos();
            var clientes = clienteService.PegarTodosAtivos();
            var ordemServicoOpcoes = new OrdemServicoOpcoesDto()
            {
                Clientes = clientes,
                Orcamentos = orcamentos
            };
            return View(ordemServicoOpcoes);
        }

        public IActionResult Index()
        {
            var ordensDeServiço = ordemServicoService.PegarTodosComNome();
            ordensDeServiço = ordensDeServiço.OrderBy(x => (int)x.Status).ToList();
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

        public IActionResult Atualizar(int id)
        {
            var response = ordemServicoService.PegarPeloId(id);
            return View(response);
        }

        [HttpPost]
        public IActionResult Atualizar(OrdemServicoComNomesDto osComNomes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ordemServicoService.Atualizar(osComNomes);
                    TempData["MensagemSucesso"] = $"Ordem De Serviço do Cliente {osComNomes.Cliente.NomeCliente} alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(osComNomes);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível alterar a Ordem de Serviço. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
