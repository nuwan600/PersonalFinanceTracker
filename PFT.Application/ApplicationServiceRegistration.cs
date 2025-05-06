using Microsoft.Extensions.DependencyInjection;
using PFT.Application.Contracts.Services;
using PFT.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFT.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITransactionService, TransactionService>();
            return services;
        }
    }
}
