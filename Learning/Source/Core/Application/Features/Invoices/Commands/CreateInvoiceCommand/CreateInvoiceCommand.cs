using Application.Interfaces.Contexts;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Commands.CreateInvoiceCommand
{
    /// <summary>
    /// https://alexcodetuts.com/2020/02/09/asp-net-core-3-1-clean-architecture-invoice-management-app-part-3-mediatr-and-fluentvalidation/
    /// https://github.com/alexcalingasan/InvoiceManagementApp/blob/master/InvoiceManagementApp.Application/Invoices/Commands/CreateInvoiceCommand.cs
    /// https://www.youtube.com/watch?v=LH57cG1td9U
    /// </summary>
    public class CreateInvoiceCommand: IRequest<int>
    {
        public CreateInvoiceCommand()
        {
            this.InvoiceItems = new List<InvoiceItem>();
            //Can you view model 
        }

        //public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string Logo { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string PaymentTerms { get; set; }
        public DateTime? DueDate { get; set; }
        public DiscountType DiscountType { get; set; }
        public double Discount { get; set; }
        public TaxType TaxType { get; set; }
        public double Tax { get; set; }
        public double AmountPaid { get; set; }
        public IList<InvoiceItem> InvoiceItems { get; set; }
    }

    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateInvoiceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var entity = new Invoice //Manual Mapping properties from request
            {
                AmountPaid = request.AmountPaid,
                Date = request.Date,
                Discount = request.Discount,
                DiscountType = request.DiscountType,
                DueDate = request.DueDate,
                From = request.From,
                InvoiceNumber = request.InvoiceNumber,
                Logo = request.Logo,
                To = request.To,
                PaymentTerms = request.PaymentTerms,
                Tax = request.Tax,
                TaxType = request.TaxType,
                InvoiceItems = request.InvoiceItems.Select(i => new InvoiceItem
                { 
                    Item=i.Item,
                    Quantity=i.Quantity,
                    Rate=i.Rate
                }).ToList()
            };
            _context.Invoices.Add(entity);
            await _context.SaveSimpleAuditAsync(cancellationToken);
            return entity.Id;
        }
    }
}
