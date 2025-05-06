using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PFT.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFT.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(TransactionProfile));
            return services;
        }
    }
}
