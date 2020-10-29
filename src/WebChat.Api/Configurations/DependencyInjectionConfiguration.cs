using Microsoft.Extensions.DependencyInjection;
using WebChat.Application.Interface;
using WebChat.Application.Service;
using WebChat.Domain.Interface;
using WebChat.Infra.InMemoryDatabase.Repository;

namespace WebChat.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ISessionRepository, SessionRepository>();
            services.AddScoped<IChatService, ChatService>();

            return services;
        }
    }
}