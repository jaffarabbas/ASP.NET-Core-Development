using CleanArchitectureWithMediatorRCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWithMediatorRCore.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeEntity>> GetEmployees();
        Task<EmployeeEntity> GetEmployeesByIdAsync(Guid id);
        Task<EmployeeEntity> AddEmployeesAsync(EmployeeEntity employee);
        Task<EmployeeEntity> UpdateEmployeesAsync(Guid employeeId, EmployeeEntity employee);
        Task<bool> DeleteEmployeesAsync(Guid employeeId);
    }
}
