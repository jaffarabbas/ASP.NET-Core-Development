using CleanArchitectureWithMediatorRApplication;
using CleanArchitectureWithMediatorRInfrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWithMediatorR
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection service)
        {
            service.AddApplicationDI()
                .AddInfrastrucureDI();
            return service;
        }
    }
}
