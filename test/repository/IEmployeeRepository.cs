using test.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace test.repository{
    public interface IEmployeeRepository{
      Task<List<Employee>> GetAllEmployeeAsAsync();
      Task<Employee> GetEmployeeFromIdAsAsync(int id);
      Task<int> AddEmployeesAsync(Employee employeeModel);
      Task UpdateEmployeeFromIdAsAsync(int id, Employee employeeModel);        
      Task DeleteBooksAsync(int id);
    }
}