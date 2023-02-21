using AutoMapper;
using Castle.Core.Resource;
using KerberGestaoRegraDeNegocio.Models.Dtos;
using KerberGestaoRegraDeNegocio.Models.Entities;
using KerberGestaoRegraDeNegocio.Repositories.Interface;
using KerberGestaoRegraDeNegocio.Services.Interfaces;

namespace KerberGestaoRegraDeNegocio.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IMapper mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;
        }

        public List<ClienteDto> PegarTodos()
        {
            var clientes = clienteRepository.PegarTodos();
            return mapper.Map<List<ClienteDto>>(clientes);
        }

        public void Criar(ClienteDto cliente)
        {
            var clienteEntity = mapper.Map<Cliente>(cliente);
            clienteRepository.Criar(clienteEntity);
        }

        public ClienteDto PegarPeloId(int id)
        {
            var clienteEntity = clienteRepository.PegarPeloId(id);
            return mapper.Map<ClienteDto>(clienteEntity);
        }

        public void Atualizar(ClienteDto cliente)
        {
            var clienteEntity = mapper.Map<Cliente>(cliente);
            clienteRepository.Atualizar(clienteEntity);
        }
    }
}
