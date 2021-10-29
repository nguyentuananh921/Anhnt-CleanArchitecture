using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DatabaseContext;
using Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    //https://codewithmukesh.com/blog/repository-pattern-in-aspnet-core/
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            //No More private here
            //_context = context;
        }
    }
}
