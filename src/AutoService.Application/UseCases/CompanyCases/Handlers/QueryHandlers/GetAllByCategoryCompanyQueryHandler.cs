using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CompanyCases.Queries;
using AutoService.Domain.Entities.ViewModels.CompanyViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CompanyCases.Handlers.QueryHandlers
{
    public class GetAllByCategoryCompanyQueryHandler : IRequestHandler<GetAllByCategoryCompanyQuery, IEnumerable<CompanyViewModel>>
    {
        private readonly IAppDbContext _context;

        public GetAllByCategoryCompanyQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<CompanyViewModel>> Handle(GetAllByCategoryCompanyQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
