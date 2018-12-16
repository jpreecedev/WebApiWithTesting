using Microsoft.Extensions.DependencyInjection;
using WebApiWithTesting.Data.Repositories;
using WebApiWithTesting.Domain.Repositories;

namespace WebApiWithTesting.API.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped<IHouseRepository, HouseRepository>();
        }
    }
}