using AutoService.Domain.Entities.ViewModels.CompanyViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CompanyCases.Queries
{
    public class GetAllByCategoryCompanyQuery : IRequest<IEnumerable<CompanyViewModel>>
    {
        
    }
}
