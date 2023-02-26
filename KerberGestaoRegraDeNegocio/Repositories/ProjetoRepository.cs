using KerberGestaoRegraDeNegocio.Data;
using KerberGestaoRegraDeNegocio.Models;
using KerberGestaoRegraDeNegocio.Models.Entities;
using KerberGestaoRegraDeNegocio.Repositories.Interface;

namespace KerberGestaoRegraDeNegocio.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly kerbergestaoContext dbContext;

        public ProjetoRepository(kerbergestaoContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Projeto> PegarTodos()
        {
            return dbContext.Projetos.ToList();
        }

        public Projeto Criar(Projeto projeto)
        {
            dbContext.Projetos.Add(projeto);
            dbContext.SaveChanges();
            return projeto;
        }

        public Projeto PegarPeloId(int id)
        {
            return dbContext.Projetos.FirstOrDefault(x => x.IdProjeto == id);
        }

        public Projeto Atualizar(Projeto projeto)
        {
            Projeto projetoNoBanco = PegarPeloId(projeto.IdProjeto);

            if (projetoNoBanco == null)
            {
                throw new System.Exception("Houve um erro na atualização do Projeto");
            }

            projetoNoBanco.NomeProjeto = projeto.NomeProjeto;
            projetoNoBanco.Descricao = projeto.Descricao;
            projetoNoBanco.StatusProjeto = projeto.StatusProjeto;

            dbContext.Projetos.Update(projetoNoBanco);
            dbContext.SaveChanges();

            return projetoNoBanco;
        }

        public List<Projeto> PegarTodosPorStatus(StatusProjetoEnum status)
        {
            return dbContext.Projetos.Where(x => x.StatusProjeto == status).ToList();
        }

        public List<Projeto> PegarPorNome(string nome)
        {
            return dbContext.Projetos.Where(x => x.NomeProjeto == nome).ToList();
        }
    }
}
