using Domain.Interfaces.Base;
using Infrastructure.DatabaseContext;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
        /// https://codewithmukesh.com/blog/repository-pattern-in-aspnet-core/
        /// https://codewithmukesh.com/blog/razor-page-crud-in-aspnet-core/
        /// </summary>
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;            
        }
        
        public int Commit()
        {
            return _context.SaveChanges();
        }

        //public async Task<int> CommitAsync()
        //{
        //    return await _context.SaveChangesAsync();
        //}

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
