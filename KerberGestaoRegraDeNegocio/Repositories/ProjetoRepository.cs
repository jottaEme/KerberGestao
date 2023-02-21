using KerberGestaoRegraDeNegocio.Data;
using KerberGestaoRegraDeNegocio.Models.Entities;
using KerberGestaoRegraDeNegocio.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

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
    }
}
