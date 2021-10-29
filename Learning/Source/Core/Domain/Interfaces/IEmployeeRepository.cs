using Domain.Entities;
using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// https://codewithmukesh.com/blog/razor-page-crud-in-aspnet-core/
    /// https://github.com/iammukeshm/RazorCRUD.jQueryAJAX/blob/master/Core/Interfaces/ICustomerRepositoryAsync.cs
    /// </summary>
    
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
    }
}
