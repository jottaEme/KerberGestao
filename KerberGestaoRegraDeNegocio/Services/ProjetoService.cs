using AutoMapper;
using KerberGestaoRegraDeNegocio.Models.Dtos;
using KerberGestaoRegraDeNegocio.Repositories;
using KerberGestaoRegraDeNegocio.Repositories.Interface;
using KerberGestaoRegraDeNegocio.Services.Interfaces;

namespace KerberGestaoRegraDeNegocio.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository projetoRepository;
        private readonly IMapper mapper;

        public ProjetoService(IProjetoRepository projetoRepository, IMapper mapper)
        {
            this.projetoRepository = projetoRepository;
            this.mapper = mapper;
        }

        public List<ProjetoDto> PegarTodos()
        {
            var projetos = projetoRepository.PegarTodos();
            return mapper.Map<List<ProjetoDto>>(projetos);
        }
    }
}
