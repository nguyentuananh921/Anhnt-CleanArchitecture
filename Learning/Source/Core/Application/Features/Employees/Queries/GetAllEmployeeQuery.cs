using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Employees.Queries
{
    public class GetAllEmployeeQuery: IRequest<IEnumerable<Employee>>
    {
    }
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<Employee>>
    {
        private readonly IEmployeeRepository _employeeRepo;

        public GetAllEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepo = employeeRepository;
        }
        public async Task<IEnumerable<Employee>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            //var employeelist= await _employeeRepo.GetAllAsync();
            return (IEnumerable<Employee>)await _employeeRepo.GetAllAsync();
        }
    }
    public class EmployeeDTO 
    {
        public Int64 EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
