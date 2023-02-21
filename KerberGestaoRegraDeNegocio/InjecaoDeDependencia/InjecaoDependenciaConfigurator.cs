using KerberGestaoRegraDeNegocio.Helper;
using KerberGestaoRegraDeNegocio.Repositories;
using KerberGestaoRegraDeNegocio.Repositories.Interface;
using KerberGestaoRegraDeNegocio.Services;
using KerberGestaoRegraDeNegocio.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace KerberGestaoRegraDeNegocio.InjecaoDeDependencia
{
    public static class InjecaoDependenciaConfigurator
    {
        public static IServiceCollection AddInjecaoDependencia(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ISessao, Sessao>();
            services.AddScoped<IEmail, Email>();

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProjetoService, ProjetoService>();
            services.AddScoped<IOrdemServicoService, OrdemServicoService>();
            services.AddScoped<IOrcamentoService, OrcamentoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<IOrdemServicoRepository, OrdemServicoRepository>();
            services.AddScoped<IOrcamentoRepository, OrcamentoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
