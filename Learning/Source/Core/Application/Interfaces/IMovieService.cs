using Application.ViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMovieService
    {                
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(int? id);
    }
}
