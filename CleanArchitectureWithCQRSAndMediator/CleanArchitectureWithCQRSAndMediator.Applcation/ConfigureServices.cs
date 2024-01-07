using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWithCQRSAndMediator.Applcation
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(ctg =>
            {
                ctg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });
            return services;
        }
    }
}
