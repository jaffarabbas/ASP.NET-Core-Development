using test.repository;
using test.model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees = new List<Employee>();
        public Task<List<Employee>> GetAllEmployeeAsAsync()
        {
            return employees;
        }

        public Task<Employee> GetEmployeeFromIdAsAsync(int id)
        {
            Employee emp = employees.Find(employees.id == id);
            return emp;
        }

        public Task<int> AddEmployeesAsync(Employee employeeModel)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployeeFromIdAsAsync(int id, Employee employeeModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBooksAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}