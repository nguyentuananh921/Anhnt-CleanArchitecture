﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Contexts;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands
{
    public class CreateProductCommand:IRequest<int>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal Rate { get; set; }
    }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product();
            product.Barcode = command.Barcode;
            product.Name = command.Name;
            product.BuyingPrice = command.BuyingPrice;
            product.Rate = (int)command.Rate;
            product.Description = command.Description;
            _context.Products.Add(product);
            await _context.SaveChangeAsync();
            return product.Id;
        }        
    }
}
