using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.ServiceCases.ServiceCategoryCases.Queries;
using AutoService.Domain.Entities.Models.ServiceModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ServiceCases.ServiceCategoryCases.Handlers
{
    public class GetAllServiceCategoryCommandHandler : IRequestHandler<GetAllServiceCategoryCommand, List<ServiceCategory>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetAllServiceCategoryCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<ServiceCategory>> Handle(GetAllServiceCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _appDbContext.ServiceCategories.ToListAsync(cancellationToken);
        }
    }
}
