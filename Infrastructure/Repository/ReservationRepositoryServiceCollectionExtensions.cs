using Infrastructure.Abstraction;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Infrastructure.DbContext;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ReservationRepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddReservationRepository(this IServiceCollection services)
        {
            services.AddScoped<IReservationRepository, ReservationRepository>();
            return services;
        }
    }
}
