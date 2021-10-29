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
    /// https://nishanc.medium.com/clean-architecture-net-core-part-2-implementation-7376896390c5
    /// </summary>
    //public interface IBookRepository
    //{
    //    IEnumerable<Book> GetBooks();
    //}

    public interface IBookRepository : IGenericRepository<Book>
    { 
    }
}
