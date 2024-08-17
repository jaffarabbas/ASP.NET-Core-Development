using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWithMediatorRInfrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastrucureDI(this IServiceCollection service)
        {
            return service;
        }
    }
}
