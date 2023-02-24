using AutoMapper;
using KerberGestaoRegraDeNegocio.Models.Dtos;
using KerberGestaoRegraDeNegocio.Models.Entities;
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
                osComNomes.FirstOrDefault(x => x.IdOrdemServico == os.IdOrdemServico).Cliente 
                    = mapper.Map<ClienteSimplificadoDto>(cliente);
            }
            foreach (var os in ordensDeServico)
            {
                var orcamento = orcamentoService.PegarPeloId(os.IdOrcamento);
                osComNomes.FirstOrDefault(x => x.IdOrdemServico == os.IdOrdemServico).Orcamento 
                    = mapper.Map<OrcamentoSimplificadoDto>(orcamento);
            }
            return osComNomes;
        }

        public OrdemServicoComNomesDto PegarPeloId(int id)
        {
            var osEntity = ordemServicoRepository.PegarPeloId(id);
            var osComNomes = mapper.Map<OrdemServicoComNomesDto>(osEntity);
            osComNomes.Cliente = mapper.Map<ClienteSimplificadoDto>(clienteService.PegarPeloId(osEntity.IdCliente));
            osComNomes.Orcamento = mapper.Map<OrcamentoSimplificadoDto>(orcamentoService.PegarPeloId(osEntity.IdOrcamento));
            
            return osComNomes;
        }

        public void Atualizar(OrdemServicoComNomesDto osComNomes)
        {
            var osEntity = mapper.Map<Ordemservico>(osComNomes);
            osEntity.IdCliente = osComNomes.Cliente.IdCliente;
            osEntity.IdOrcamento = osComNomes.Orcamento.IdOrcamentos;
            ordemServicoRepository.Atualizar(osEntity);
        }
    }
}
