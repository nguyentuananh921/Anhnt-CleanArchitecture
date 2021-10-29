using Application.Features.Gadgets.Models;
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
    public class GadgetLogic : GenericRepository<Gadget>, IGadgetLogic
    {
        public GadgetLogic(ApplicationDbContext context) : base(context)
        {

        }
        //public async Task<IEnumerable<GadgetDto>> GetAllDTO()
        //{
        //    return _context.Gadgets
        //    .Select(_ => new GadgetDto
        //    {
        //        Brand = _.Brand,
        //        Cost = _.Cost,
        //        Id = _.Id,
        //        ProductName = _.ProductName,
        //        Type = _.Type
        //    }).ToList();
        //}
    }
}
