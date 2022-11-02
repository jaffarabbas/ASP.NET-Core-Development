using test.model;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace test.repository{
    public interface IEmployeeRepository{
        public Task<List<Employee>> GetAllEmployeeAsAsync();
        public Task<EmployeeModel> GetEmployeeFromIdAsAsync(int id);
        public Task<int> AddEmployeesAsync(Employee employeeModel);
        public Task UpdateEmployeeFromIdAsAsync(int id, Employee employeeModel);        
        public Task DeleteBooksAsync(int id);
    }
}