using KerberGestaoRegraDeNegocio.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KerberGestaoFrontMaster.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            var usuario = JsonConvert.DeserializeObject<UsuarioDto>(sessaoUsuario);

            return View(usuario);
        }
    }
}
