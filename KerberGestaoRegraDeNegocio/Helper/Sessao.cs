using KerberGestaoRegraDeNegocio.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace KerberGestaoRegraDeNegocio.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            this.httpContext = httpContext;
        }

        public UsuarioDto BuscarSessaoDoUsuario()
        {
            var saida = new Byte[20000];
            var sessaoUsuario = httpContext.HttpContext.Session.TryGetValue("sessaoUsuarioLogado", out saida);
            if (saida == null) return null;
            return JsonConvert.DeserializeObject<UsuarioDto>(System.Text.Encoding.UTF8.GetString(saida));
        }

        public void CriarSessaoDoUsuario(UsuarioDto usuario)
        {
            var valor = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(usuario));
            httpContext.HttpContext.Session.Set("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoDoUsuario()
        {
            httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
