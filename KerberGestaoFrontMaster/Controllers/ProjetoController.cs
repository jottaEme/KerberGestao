using KerberGestaoFrontMaster.Filters;
using KerberGestaoRegraDeNegocio.Models.Dtos;
using KerberGestaoRegraDeNegocio.Models.Enums;
using KerberGestaoRegraDeNegocio.Services;
using KerberGestaoRegraDeNegocio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KerberGestaoFrontMaster.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ProjetoController : Controller
    {
        private readonly IProjetoService projetoService;
        private readonly IClienteService clienteService;

        public ProjetoController(IProjetoService projetoService, IClienteService clienteService)
        {
            this.projetoService = projetoService;
            this.clienteService = clienteService;
        }

        public IActionResult Criar()
        {
            var clientes = clienteService.PegarTodosAtivos();
            var projetoOpcoes = new ProjetoOpcoesDto()
            {
                Clientes = clientes
            };
            return View(projetoOpcoes);
        }

        public IActionResult Index()
        {
            var response = projetoService.PegarTodos();
            return View(response);
        }
        public IActionResult Atualizar(int id)
        {
            var response = projetoService.PegarPeloId(id);
            return View(response);
        }

        [HttpPost]
        public IActionResult BuscarPorStatus(StatusProjetoEnum status)
        {
            var response = projetoService.PegarTodosPorStatus(status);
            return View("Index", response);
        }

        [HttpPost]
        public IActionResult BuscarPorNome(string nome)
        {
            var response = projetoService.PegarPorNome(nome);
            return View("Index", response);
        }

        [HttpPost]
        public IActionResult Atualizar(ProjetoDto projeto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    projetoService.Atualizar(projeto);
                    TempData["MensagemSucesso"] = $"Projeto {projeto.IdProjeto} alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(projeto);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível alterar o Projeto. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult CriarNoBanco(ProjetoOpcoesDto projeto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    projetoService.Criar(projeto);
                    TempData["MensagemSucesso"] = $"Projeto {projeto.NomeProjeto} criado com sucesso";
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }catch(Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível criar o Projeto. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
            
        }
    }
}
