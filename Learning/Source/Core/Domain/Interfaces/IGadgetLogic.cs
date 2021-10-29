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
    /// https://www.learmoreseekmore.com/2021/05/clean-architecture-in-dotnet5-application.html
    /// https://github.com/Naveen512/Dotnet5CleanArchitecture
    /// </summary>    
    

    public interface IGadgetLogic : IGenericRepository<Gadget>
    { 
    }
    //Task<IEnumerable<GadgetDto>> GetAllDTO();
}
