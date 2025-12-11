using AssiT.BackEnd.Application.Services.Commands.ContactCommands.CreateContact;
using Microsoft.Extensions.DependencyInjection;

namespace AssiT.BackEnd.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddHandlers();
            return services;
        }


        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(Config => Config.RegisterServicesFromAssemblyContaining<CreateAssetHandler>());
            return services;
        }
    }
}
