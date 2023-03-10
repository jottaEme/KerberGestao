using KerberGestaoRegraDeNegocio.Data;
using KerberGestaoRegraDeNegocio.Models.Entities;
using KerberGestaoRegraDeNegocio.Models.Enums;
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

        public List<Orcamento> PegarTodosAtivos()
        {
            return dbContext.Orcamentos.Where(x => x.StatusOrcamento != StatusOrcamentoEnum.Finalizado).ToList();
        }

        public Orcamento PegarPeloId(int id)
        {
            return dbContext.Orcamentos.FirstOrDefault(x => x.IdOrcamentos == id);
        }

        public Orcamento Criar(Orcamento orcamento)
        {
            dbContext.Orcamentos.Add(orcamento);
            dbContext.SaveChanges();
            return orcamento;
        }

        public Orcamento Atualizar(Orcamento orcamento)
        {
            Orcamento orcamentoNoBanco = PegarPeloId(orcamento.IdOrcamentos);

            if (orcamentoNoBanco == null)
            {
                throw new System.Exception("Houve um erro na atualização do Cliente");
            }

            orcamentoNoBanco.StatusOrcamento = orcamento.StatusOrcamento;

            dbContext.Orcamentos.Update(orcamentoNoBanco);
            dbContext.SaveChanges();

            return orcamentoNoBanco;
        }
    }
}
