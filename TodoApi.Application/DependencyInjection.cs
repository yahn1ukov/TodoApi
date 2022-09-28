using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TodoApi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        services.AddMediatR(typeof(DependencyInjection).Assembly);

        return services;
    }
}