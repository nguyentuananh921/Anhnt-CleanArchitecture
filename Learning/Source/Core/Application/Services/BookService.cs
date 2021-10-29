using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BookService : IBookService
    {        
        //The interface in the InnerLayer and The Implementation in the OutterLayer
        //Here Interface and the implementation in the same Layer
        public IBookRepository _bookRepository;  //Dependency
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public BookViewModel GetBooks()
        {
            return new BookViewModel()
            {
                Books = _bookRepository.GetAll()
            };
        }
    }
}
