using Jazani.Domain.Admins.Repositories;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infrastructure.Admins.Persistences;
using Jazani.Infrastructure.Generals.Persistences;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jazani.Infrastructure.Cores.Contexts
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection addInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });

            services.AddTransient<IOfficeRepository, OfficeRepository>();
            services.AddTransient<INationalityRepository, NationalityRepository>();
            services.AddTransient<IMineralTypeRepository, MineralTypeRepository>();

            return services;
        }
    }
}
