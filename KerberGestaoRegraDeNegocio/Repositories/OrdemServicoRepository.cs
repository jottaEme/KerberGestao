using KerberGestaoRegraDeNegocio.Data;
using KerberGestaoRegraDeNegocio.Models.Entities;
using KerberGestaoRegraDeNegocio.Repositories.Interface;

namespace KerberGestaoRegraDeNegocio.Repositories
{
    public class OrdemServicoRepository : IOrdemServicoRepository
    {
        private readonly kerbergestaoContext dbContext;

        public OrdemServicoRepository(kerbergestaoContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Ordemservico Criar(Ordemservico ordemServico)
        {
            dbContext.Ordemservicos.Add(ordemServico);
            dbContext.SaveChanges();
            return ordemServico;
        }

        public List<Ordemservico> PegarTodos()
        {
            return dbContext.Ordemservicos.ToList();
        }
    }
}
