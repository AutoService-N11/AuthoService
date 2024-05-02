using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CompanyCases.Queries;
using AutoService.Domain.Entities.ViewModels.CompanyViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace AutoService.Application.UseCases.CompanyCases.Handlers.QueryHandlers
{
    public class GetAllByCategoryCompanyQueryHandler : IRequestHandler<GetAllByCategoryCompanyQuery, List<CompanyViewModel>>
    {
        private readonly IAppDbContext _context;

        public GetAllByCategoryCompanyQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CompanyViewModel>> Handle(GetAllByCategoryCompanyQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null.");
            }

            var companies = await _context.Companies
                .Where(c => c.CompanyCategories.Any(cc => cc.CategoryName == request.CategoryName))
                .Select(c => new CompanyViewModel
                {
                    CompanyName = c.CompanyName,
                    PhotoPath = c.PhotoPath,
                    CompanyHistory = c.CompanyHistory,
                })
                .ToListAsync();

            return companies;

        }
    }
}
