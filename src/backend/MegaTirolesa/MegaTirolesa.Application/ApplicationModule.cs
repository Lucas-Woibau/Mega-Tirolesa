using MegaTirolesa.Application.Common;
using Microsoft.Extensions.DependencyInjection;

namespace MegaTirolesa.Application
{
    public static class ApplicationModule
    {
        extension(IServiceCollection services)
        {
            public IServiceCollection AddApplication()
            {
                services
                    .AddHandlers();

                return services;
            }

            private IServiceCollection AddHandlers()
            {
                services.AddScoped<IMediator, Mediator>();

                services.Scan(s =>
                    s.FromAssemblies(typeof(ApplicationModule).Assembly)
                        .AddClasses(c => c.AssignableTo(typeof(IHandler<,>)))
                        .AsImplementedInterfaces()
                        .WithTransientLifetime()
                );

                return services;
            }
        }
    }
}
