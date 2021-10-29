using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Shared
{
    public interface ICurrentUserService
    {
        /// <summary>
        /// Interface is placed  in the Inner Layer (Application) and Implementation is placed in the Outsite Layer (Presentation)
        /// https://alexcodetuts.com/2020/02/06/asp-net-core-3-1-clean-architecture-invoice-management-app-part-2-ef-core-audit/
        /// </summary>
        string UserId { get; }
    }
}
