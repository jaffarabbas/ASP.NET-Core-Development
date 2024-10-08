﻿using CleanArchitectureWithMediatorRCore.Interfaces;
using CleanArchitectureWithMediatorRInfrastructure.Data;
using CleanArchitectureWithMediatorRInfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
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
            service.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Server=mssql-server2;Database=TestDB;User Id=sa;Password=JAFFARempire@1399;Trusted_Connection=False;TrustServerCertificate=true;MultipleActiveResultSets=True;");
            });
            service.AddScoped<IEmployeeRepository, EmployeeRepository>();
            return service;
        }
    }
}
