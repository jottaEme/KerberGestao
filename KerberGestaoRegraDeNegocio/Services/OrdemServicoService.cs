using AutoMapper;
using KerberGestaoRegraDeNegocio.Models.Dtos;
using KerberGestaoRegraDeNegocio.Models.Entities;
using KerberGestaoRegraDeNegocio.Repositories;
using KerberGestaoRegraDeNegocio.Repositories.Interface;
using KerberGestaoRegraDeNegocio.Services.Interfaces;

namespace KerberGestaoRegraDeNegocio.Services
{
    public class OrdemServicoService : IOrdemServicoService
    {
        private readonly IOrdemServicoRepository ordemServicoRepository;
        private readonly IClienteService clienteService;
        private readonly IOrcamentoService orcamentoService;
        private readonly IMapper mapper;

        public OrdemServicoService(IOrdemServicoRepository ordemServicoRepository, IMapper mapper, IClienteService clienteService, IOrcamentoService orcamentoService)
        {
            this.ordemServicoRepository = ordemServicoRepository;
            this.mapper = mapper;
            this.clienteService = clienteService;
            this.orcamentoService = orcamentoService;
        }
        public void Criar(OrdemServicoOpcoesDto osOpcoes)
        {
            var ordemServicoEntity = mapper.Map<Ordemservico>(osOpcoes);
            ordemServicoRepository.Criar(ordemServicoEntity);
        }

        public List<OrdemServicoDto> PegarTodos()
        {
            var ordensDeServico = ordemServicoRepository.PegarTodos();
            return mapper.Map<List<OrdemServicoDto>>(ordensDeServico);
        }

        public List<OrdemServicoComNomesDto> PegarTodosComNome()
        {
            var ordensDeServico = ordemServicoRepository.PegarTodos();
            var osComNomes = mapper.Map<List<OrdemServicoComNomesDto>>(ordensDeServico);
            foreach(var os in ordensDeServico)
            {
                var cliente = clienteService.PegarPeloId(os.IdCliente);
                osComNomes.FirstOrDefault(x => x.IdOrdemServico == os.IdOrdemServico).NomeCliente = cliente.NomeCliente;
            }
            foreach (var os in ordensDeServico)
            {
                var orcamento = orcamentoService.PegarPeloId(os.IdOrcamento);
                osComNomes.FirstOrDefault(x => x.IdOrdemServico == os.IdOrdemServico).NomeOrcamento = orcamento.NomeOrcamento;
            }
            return osComNomes;
        }
    }
}
