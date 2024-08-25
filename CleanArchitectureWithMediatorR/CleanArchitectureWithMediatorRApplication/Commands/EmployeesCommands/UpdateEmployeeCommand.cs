using CleanArchitectureWithMediatorRCore.Entities;
using CleanArchitectureWithMediatorRCore.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWithMediatorRApplication.Commands.EmployeesCommands
{
    public record UpdateEmployeeCommand(Guid EmployeeId, EmployeeEntity Employee)
        : IRequest<EmployeeEntity>;
    public class UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<UpdateEmployeeCommand, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.UpdateEmployeesAsync(request.EmployeeId, request.Employee);
        }
    }
}
