using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PFT.Application.Contracts.Persistence;
using PFT.Persistence.Data;
using PFT.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFT.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            var dbService = configuration.GetConnectionString("Provider");
            services.AddDbContext<PFTDatabaseContext>(options =>
            {
                if (dbService == "SqlServer")
                {
                    options.UseSqlServer(configuration.GetConnectionString("PFT_Connection"));
                }
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
