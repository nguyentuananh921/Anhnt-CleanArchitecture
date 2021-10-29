using Domain.Entities;
using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    //https://codewithmukesh.com/blog/repository-pattern-in-aspnet-core/
    public interface IDeveloperRepository:IGenericRepository<Developer>
    {

        //Here we are inheriting all the Functions of the Generic Repository, 
        //    as well as adding a new Funciton ‘GetPopularDevelopers’. 
        IEnumerable<Developer> GetPopularDevelopers(int count);
    }
}
