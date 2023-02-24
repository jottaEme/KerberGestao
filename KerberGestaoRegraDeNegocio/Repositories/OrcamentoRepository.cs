using KerberGestaoRegraDeNegocio.Data;
using KerberGestaoRegraDeNegocio.Models.Entities;
using KerberGestaoRegraDeNegocio.Repositories.Interface;

namespace KerberGestaoRegraDeNegocio.Repositories
{
    public class OrcamentoRepository : IOrcamentoRepository
    {
        private readonly kerbergestaoContext dbContext;

        public OrcamentoRepository(kerbergestaoContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Orcamento> PegarTodos()
        {
            return dbContext.Orcamentos.ToList();
        }

        public Orcamento PegarPeloId(int id)
        {
            return dbContext.Orcamentos.FirstOrDefault(x => x.IdOrcamentos == id);
        }
    }
}
