using CleanArchitectureWithMediatorRCore.Entities;
using CleanArchitectureWithMediatorRCore.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWithMediatorRApplication.Queries.EmployeesQueries
{
    public record GetEmployeeByIdQuery(Guid EmployeeId) : IRequest<EmployeeEntity>;

    public class GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<GetEmployeeByIdQuery, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetEmployeesByIdAsync(request.EmployeeId);
        }
    }
}
