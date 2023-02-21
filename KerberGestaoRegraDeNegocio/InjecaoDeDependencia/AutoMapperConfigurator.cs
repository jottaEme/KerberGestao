using KerberGestaoRegraDeNegocio.Models.Dtos;
using KerberGestaoRegraDeNegocio.Models.Entities;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AutoMapperConfigurator
    {
        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddClienteProfiles();
            return services;
        }

        public static void AddClienteProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ClienteDto));
            services.AddAutoMapper(typeof(Cliente));
        }
    }
}
