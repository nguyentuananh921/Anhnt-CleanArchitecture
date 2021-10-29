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
    public class BookRepository : GenericRepository<Book>, IBookRepository  
    {
        //IBookRepository in Domain Layer.
        //The interface in the InnerLayer and The Implementation in the OutterLayer
        //public ApplicationDbContext _context { get; }
        //public BookRepository(ApplicationDbContext context)
        //{
        //    _context = context;
        //}        
        public BookRepository(ApplicationDbContext context) : base(context)
        {
            //No More private here
            //_context = context;
        }
        //public IEnumerable<Book> GetBooks()
        //{
        //    return _context.Books;
        //}
    }
}
