using CleanArchitectureWithMediatorRCore.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWithMediatorRApplication.Commands.EmployeesCommands
{
    public record DeleteEmployeeCommand(Guid EmployeeId) : IRequest<bool>;

    internal class DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.DeleteEmployeesAsync(request.EmployeeId);
        }
    }
}
