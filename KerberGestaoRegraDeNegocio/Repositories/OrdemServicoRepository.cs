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

        public Ordemservico PegarPeloId(int id)
        {
            return dbContext.Ordemservicos.FirstOrDefault(x => x.IdOrdemServico == id);
        }

        public Ordemservico Atualizar(Ordemservico os)
        {
            Ordemservico osNoBanco = PegarPeloId(os.IdOrdemServico);

            if (osNoBanco == null)
            {
                throw new System.Exception("Ordem de Serviço não encontrada em nosso Banco de Dados.");
            }

            osNoBanco.Titulo = os.Titulo;
            osNoBanco.Detalhamento = os.Detalhamento;
            osNoBanco.Status = os.Status;

            dbContext.Ordemservicos.Update(osNoBanco);
            dbContext.SaveChanges();

            return osNoBanco;
        }
    }
}
