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
    public class GetAllServiceCategoryCommandHandler : IRequestHandler<GetAllServiceCategoryCommand, List<CarSeateBrandViewModel>>
    {
        private readonly IAppDbContext _appDbContext;

        public GetAllServiceCategoryCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<CarSeateBrandViewModel>> Handle(GetAllServiceCategoryCommand request, CancellationToken cancellationToken)
        {
            var user= await _appDbContext.ServiceCategories.ToListAsync(cancellationToken);
            return user.Skip(request.PageIndex - 1)
                    .Take(request.Size)
                            .ToList();
        }
    }
}
