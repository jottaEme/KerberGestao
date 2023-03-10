using Castle.Core.Resource;
using KerberGestaoRegraDeNegocio.Data;
using KerberGestaoRegraDeNegocio.Models.Entities;
using KerberGestaoRegraDeNegocio.Models.Enums;
using KerberGestaoRegraDeNegocio.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace KerberGestaoRegraDeNegocio.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly kerbergestaoContext dbContext;

        public ClienteRepository(kerbergestaoContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Cliente> PegarTodos()
        {
            return dbContext.Clientes.ToList();
        }

        public List<Cliente> PegarTodosAtivos()
        {
            return dbContext.Clientes.Where(x => x.Status == StatusClienteEnum.Ativo).ToList();
        }

        public Cliente Criar(Cliente cliente)
        {
            dbContext.Clientes.Add(cliente);
            dbContext.SaveChanges();
            return cliente;
        }

        public Cliente PegarPeloId(int id)
        {
            return dbContext.Clientes.FirstOrDefault(x => x.IdCliente == id);
        }

        public Cliente Atualizar(Cliente cliente)
        {
            Cliente clienteNoBanco = PegarPeloId(cliente.IdCliente);

            if (clienteNoBanco == null)
            {
                throw new System.Exception("Houve um erro na atualização do Cliente");
            }

            clienteNoBanco.NomeCliente = cliente.NomeCliente;
            clienteNoBanco.CpfCliente = cliente.CpfCliente;
            clienteNoBanco.EnderecoCliente = cliente.EnderecoCliente;
            clienteNoBanco.BairroCliente = cliente.BairroCliente;
            clienteNoBanco.CidadeCliente = cliente.CidadeCliente;
            clienteNoBanco.EstadoCliente = cliente.EstadoCliente;
            clienteNoBanco.TelefoneCliente = cliente.TelefoneCliente;
            clienteNoBanco.CelularCliente = cliente.CpfCliente;
            clienteNoBanco.Status = cliente.Status;

            dbContext.Clientes.Update(clienteNoBanco);
            dbContext.SaveChanges();

            return clienteNoBanco;
        }
    }
}
