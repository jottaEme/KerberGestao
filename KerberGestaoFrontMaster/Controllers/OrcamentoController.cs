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
            try
            {
                var response = orcamentoService.PegarTodos();
                return View(response);
            }catch(Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível abrir tela de Orçamento. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Criar()
        {
            try
            {
                return View();
            }
            catch(Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível abrir tela de Criação. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult CriarNoBanco(OrcamentoDto orcamento)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    orcamentoService.Criar(orcamento);
                    TempData["MensagemSucesso"] = $"Orçamento {orcamento.NomeOrcamento} cadastrado com sucesso";
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
            try
            {
                var response = orcamentoService.PegarPeloId(id);
                return View(response);
            }
            catch(Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível abrir tela de atualização. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(OrcamentoDto orcamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    orcamentoService.Atualizar(orcamento);
                    TempData["MensagemSucesso"] = $"Orçamento {orcamento.NomeOrcamento} alterado com sucesso";
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
