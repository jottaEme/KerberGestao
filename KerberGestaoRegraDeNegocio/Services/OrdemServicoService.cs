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
        private readonly IMapper mapper;

        public OrdemServicoService(IOrdemServicoRepository ordemServicoRepository, IMapper mapper)
        {
            this.ordemServicoRepository = ordemServicoRepository;
            this.mapper = mapper;
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
    }
}
