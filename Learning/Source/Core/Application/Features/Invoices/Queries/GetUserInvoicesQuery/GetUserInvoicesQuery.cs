using Application.Features.Invoices.ViewModels;
using Application.Interfaces.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Queries.GetUserInvoicesQuery
{

    public class GetUserInvoicesQuery : IRequest<IList<InvoiceVm>>
    {
        public string User { get; set; }
    }
    public class GetUserInvoicesQueryHandler : IRequestHandler<GetUserInvoicesQuery, IList<InvoiceVm>>
    {
        private readonly IApplicationDbContext _context;
        //private readonly IMapper _mapper;

        public GetUserInvoicesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
            //_mapper = mapper;
        }
        public async Task<IList<InvoiceVm>> Handle(GetUserInvoicesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<InvoiceVm>();
            var invoices = await _context.Invoices.Include(i => i.InvoiceItems)
                .Where(i => i.CreatedBy == request.User).ToListAsync();
            //var invoices = await _context.Invoices.Include(i => i.InvoiceItems).ToListAsync();
            if (invoices != null)
            {
                //Manual Mapping
                result = invoices.Select(i => new InvoiceVm
                {
                    AmountPaid = i.AmountPaid,
                    Created = i.Created,
                    Discount = i.Discount,
                    DiscountType = i.DiscountType,
                    DueDate = i.DueDate,
                    From = i.From,
                    To = i.To,
                    Date = i.Date,
                    PaymentTerms = i.PaymentTerms,
                    Tax = i.Tax,
                    TaxType = i.TaxType,
                    Id = i.Id,
                    Logo = i.Logo,
                    InvoiceNumber = i.InvoiceNumber,
                    InvoiceItems = i.InvoiceItems.Select(items => new InvoiceItemVm
                    {
                        Id = items.Id,
                        Item = items.Item,
                        Quantity = items.Quantity,
                        Rate = items.Rate
                    }).ToList()
                }).ToList();
                
                //result = _mapper.Map<List<InvoiceVm>>(invoices);                
            };
            return result;
        }
    }
}
