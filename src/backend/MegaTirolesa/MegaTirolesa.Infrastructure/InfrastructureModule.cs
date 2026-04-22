using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MegaTirolesa.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MegaTirolesa.Infrastructure
{
    public static class InfrastructureModule
    {
        extension(IServiceCollection services)
        {
            public IServiceCollection AddInfrastructure(IConfiguration configuration)
            {
                services
                    .AddData(configuration);

                return services;
            }
            private IServiceCollection AddData(IConfiguration configuration)
            {
                services
                    .AddDbContext<MegaTirolesaDbContext>(options => options.UseSqlServer(
                        configuration.GetConnectionString("MegaTirolesaDb")));

                return services;
            }
        }

    }
}
