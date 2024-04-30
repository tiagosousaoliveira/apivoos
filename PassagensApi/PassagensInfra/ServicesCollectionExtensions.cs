using Microsoft.Extensions.DependencyInjection;
using PassagensServices;
using PassagensServices.contracts;

namespace PassagensInfra
{
    public static class ServicesCollectionExtensions 
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBuscarPassagensHttp, BuscarPassagensHttp>();
            return services;
        }
    }
}
