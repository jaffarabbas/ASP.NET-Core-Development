using CleanArchitectureWithMediatorRCore.Entities;
using CleanArchitectureWithMediatorRCore.Interfaces;
using MediatR;

namespace CleanArchitectureWithMediatorRApplication.Commands.EmployeesCommands
{
    public record AddEmployeeCommand(EmployeeEntity Employee) : IRequest<EmployeeEntity>;
    public class AddEmployeesCommands(IEmployeeRepository employeeRepository)
        : IRequestHandler<AddEmployeeCommand, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.AddEmployeesAsync(request.Employee);
        }
    }
}
