using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.AutoServiceCases.Queries;
using AutoService.Application.UseCases.CompanyCases.Queries;
using AutoService.Domain.Entities.Models.AutoServiceModels;
using AutoService.Domain.Entities.ViewModels.AutoServiceViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoService.Application.UseCases.AutoServiceCases.Handlers.QueryHandlers
{
    public class GetAllAutoServicesQueryHandler : IRequestHandler<GetAllAutoServices, List<AutoServiceViewModel>>
    {
        private readonly IAppDbContext _context;

        public GetAllAutoServicesQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AutoServiceViewModel>> Handle(GetAllAutoServices request, CancellationToken cancellationToken)
        {
            var autoServices = await _context.AutoServices
                                             .ToListAsync(cancellationToken);

            List<AutoServiceViewModel> autoServiceViewModels = autoServices.Select(s => new AutoServiceViewModel
            {
                Name = s.Name,
                location = s.Location,
            }).ToList();

            return autoServiceViewModels;
        }
    }
}
