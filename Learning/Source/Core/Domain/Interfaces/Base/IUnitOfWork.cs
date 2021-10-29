using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Base
{
    /// <summary>
    /// https://codewithmukesh.com/blog/repository-pattern-in-aspnet-core/
    /// 
    /// in the instruction here
    /// https://codewithmukesh.com/blog/razor-page-crud-in-aspnet-core/
    /// IUnitOfWork does have Interface
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {        
        int Commit();
        Task CommitAsync();
        //Task<int> CommitAsync();
    }
}
