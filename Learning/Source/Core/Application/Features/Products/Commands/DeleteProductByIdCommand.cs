using Application.Interfaces.Contexts;
using Domain.Interfaces;
using Domain.Interfaces.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands
{
    public class DeleteProductByIdCommand:IRequest<int>
    {
        public int Id { get; set; }
    }
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IProductRepository _productRepository;       

        private IUnitOfWork _unitOfWork { get; set; }
        public DeleteProductByIdCommandHandler(IApplicationDbContext context, 
                    IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _context = context;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(command.Id);
            await _productRepository.DeleteAsync(product);
            await _unitOfWork.CommitAsync();
            return product.Id;            
        }
    }
}
