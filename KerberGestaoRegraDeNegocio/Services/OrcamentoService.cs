using AutoMapper;
using KerberGestaoRegraDeNegocio.Models.Dtos;
using KerberGestaoRegraDeNegocio.Repositories;
using KerberGestaoRegraDeNegocio.Repositories.Interface;
using KerberGestaoRegraDeNegocio.Services.Interfaces;

namespace KerberGestaoRegraDeNegocio.Services
{
    public class OrcamentoService : IOrcamentoService
    {
        private readonly IOrcamentoRepository orcamentoRepository;
        private readonly IMapper mapper;

        public OrcamentoService(IOrcamentoRepository orcamentoRepository, IMapper mapper)
        {
            this.orcamentoRepository = orcamentoRepository;
            this.mapper = mapper;
        }

        public List<OrcamentoDto> PegarTodos()
        {
            var orcamentos = orcamentoRepository.PegarTodos();
            return mapper.Map<List<OrcamentoDto>>(orcamentos);
        }

        public OrcamentoDto PegarPeloId(int id)
        {
            var orcamentoEntity = orcamentoRepository.PegarPeloId(id);
            return mapper.Map<OrcamentoDto>(orcamentoEntity);
        }
    }
}
