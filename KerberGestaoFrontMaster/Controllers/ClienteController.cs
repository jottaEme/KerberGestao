using KerberGestaoFrontMaster.Filters;
using KerberGestaoRegraDeNegocio.Models.Dtos;
using KerberGestaoRegraDeNegocio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KerberGestaoFrontMaster.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ClienteController : Controller
    {
        private readonly IClienteService clienteService;

        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        public IActionResult Index()
        {
            var response = clienteService.PegarTodos();
            return View(response);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ClienteDto cliente)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    clienteService.Criar(cliente);
                    TempData["MensagemSucesso"] = $"Cliente {cliente.NomeCliente} cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(cliente);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar o Cliente. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }


        public IActionResult Atualizar(int id)
        {
            var response = clienteService.PegarPeloId(id);
            return View(response);
        }

        [HttpPost]
        public IActionResult Atualizar(ClienteDto cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clienteService.Atualizar(cliente);
                    TempData["MensagemSucesso"] = $"Cliente {cliente.NomeCliente} alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(cliente);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Não foi possível alterar o Cliente. Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
