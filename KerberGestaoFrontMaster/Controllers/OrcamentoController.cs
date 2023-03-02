using KerberGestaoFrontMaster.Filters;
using KerberGestaoRegraDeNegocio.Models.Dtos;
using KerberGestaoRegraDeNegocio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KerberGestaoFrontMaster.Controllers
{
    [PaginaRestritaAdmin]
    public class OrcamentoController : Controller
    {
        private readonly IOrcamentoService orcamentoService;

        public OrcamentoController(IOrcamentoService orcamentoService)
        {
            this.orcamentoService = orcamentoService;
        }

        public IActionResult Index()
        {
            var response = orcamentoService.PegarTodos();
            return View(response);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(OrcamentoDto orcamento)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    orcamentoService.Criar(orcamento);
                    TempData["MensagemSucesso"] = $"Orçamento {orcamento.IdOrcamentos} cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(orcamento);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar o Orçamento. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }


        public IActionResult Atualizar(int id)
        {
            var response = orcamentoService.PegarPeloId(id);
            return View(response);
        }

        [HttpPost]
        public IActionResult Atualizar(OrcamentoDto orcamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    orcamentoService.Atualizar(orcamento);
                    TempData["MensagemSucesso"] = $"Orçamento {orcamento.IdOrcamentos} alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(orcamento);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível alterar o orçamento. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
