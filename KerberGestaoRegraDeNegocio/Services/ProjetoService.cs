using AutoMapper;
using KerberGestaoRegraDeNegocio.Models.Dtos;
using KerberGestaoRegraDeNegocio.Models.Entities;
using KerberGestaoRegraDeNegocio.Models.Enums;
using KerberGestaoRegraDeNegocio.Repositories.Interface;
using KerberGestaoRegraDeNegocio.Services.Interfaces;

namespace KerberGestaoRegraDeNegocio.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository projetoRepository;
        private readonly IClienteService clienteService;
        private readonly IMapper mapper;

        public ProjetoService(IProjetoRepository projetoRepository, IMapper mapper, IClienteService clienteService)
        {
            this.projetoRepository = projetoRepository;
            this.mapper = mapper;
            this.clienteService = clienteService;
        }

        public List<ProjetoDto> PegarTodos()
        {
            var projetos = projetoRepository.PegarTodos();
            var projetoDto = mapper.Map<List<ProjetoDto>>(projetos);
            foreach (var projeto in projetos)
            {
                var cliente = clienteService.PegarPeloId(projeto.IdCliente);
                projetoDto.FirstOrDefault(x => x.IdProjeto == projeto.IdProjeto).Cliente
                    = mapper.Map<ClienteSimplificadoDto>(cliente);
            }
            return projetoDto;
        }

        public void Criar(ProjetoOpcoesDto projeto)
        {
            var projetoEntity = mapper.Map<Projeto>(projeto);
            projetoRepository.Criar(projetoEntity);
        }

        public ProjetoDto PegarPeloId(int id)
        {
            var projetoEntity = projetoRepository.PegarPeloId(id);
            var projetoDto = mapper.Map<ProjetoDto>(projetoEntity);
            projetoDto.Cliente = mapper.Map<ClienteSimplificadoDto>(clienteService.PegarPeloId(projetoEntity.IdCliente));

            return projetoDto;
        }

        public void Atualizar(ProjetoDto projeto)
        {
            var projetoEntity = mapper.Map<Projeto>(projeto);
            projetoRepository.Atualizar(projetoEntity);
        }

        public List<ProjetoDto> PegarTodosPorStatus(StatusProjetoEnum status)
        {
            var projetos = projetoRepository.PegarTodosPorStatus(status);
            var projetoDto = mapper.Map<List<ProjetoDto>>(projetos);
            foreach (var projeto in projetos)
            {
                var cliente = clienteService.PegarPeloId(projeto.IdCliente);
                projetoDto.FirstOrDefault(x => x.IdProjeto == projeto.IdProjeto).Cliente
                    = mapper.Map<ClienteSimplificadoDto>(cliente);
            }
            return projetoDto;
        }

        public List<ProjetoDto> PegarPorNome(string nome)
        {
            var projetos = projetoRepository.PegarPorNome(nome);
            var projetoDto = mapper.Map<List<ProjetoDto>>(projetos);
            foreach (var projeto in projetos)
            {
                var cliente = clienteService.PegarPeloId(projeto.IdCliente);
                projetoDto.FirstOrDefault(x => x.IdProjeto == projeto.IdProjeto).Cliente
                    = mapper.Map<ClienteSimplificadoDto>(cliente);
            }
            return projetoDto;
        }
    }
}
