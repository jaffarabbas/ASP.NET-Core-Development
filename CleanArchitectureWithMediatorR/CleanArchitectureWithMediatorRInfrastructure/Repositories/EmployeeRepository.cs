using CleanArchitectureWithMediatorRCore.Entities;
using CleanArchitectureWithMediatorRCore.Interfaces;
using CleanArchitectureWithMediatorRInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWithMediatorRInfrastructure.Repositories
{
    public class EmployeeRepository(AppDbContext dbContext) : IEmployeeRepository
    {
        public async Task<IEnumerable<EmployeeEntity>> GetEmployees()
        {
            return await dbContext.Employees.ToListAsync();
        }
        public async Task<EmployeeEntity> GetEmployeesByIdAsync(Guid id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<EmployeeEntity> AddEmployeesAsync(EmployeeEntity employee)
        {
            employee.Id = Guid.NewGuid();
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
            return employee;
        }
        public async Task<EmployeeEntity> UpdateEmployeesAsync(Guid employeeId,EmployeeEntity employee)
        {
            var data = await dbContext.Employees.FirstOrDefaultAsync(a => a.Id == employeeId);
            if (data is not null)
            {
                employee.Name = data.Name;
                employee.Phone = data.Phone;
                employee.Email = data.Email;    
                await dbContext.SaveChangesAsync();
                return employee;
            }
            return employee;
        }
        public async Task<bool> DeleteEmployeesAsync(Guid employeeId)
        {
            var data = await dbContext.Employees.FirstOrDefaultAsync(a => a.Id == employeeId);
            if (data is not null)
            {
                dbContext.Employees.Remove(data);
                return await dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
