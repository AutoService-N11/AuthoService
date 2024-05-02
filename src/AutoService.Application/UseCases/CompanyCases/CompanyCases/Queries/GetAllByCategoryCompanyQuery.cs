using AutoService.Domain.Entities.ViewModels.CompanyViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CompanyCases.CompanyCases.Queries
{
    public class GetAllByCategoryCompanyQuery : IRequest<List<CompanyViewModel>>
    {
        public string CategoryName { get; set; }
    }
}
