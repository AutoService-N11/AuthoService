using AutoService.Domain.Entities.Models.AutoServiceModels;
using AutoService.Domain.Entities.ViewModels.AutoServiceViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.AutoServiceCases.Queries
{
    public class GetAllAutoServices : IRequest<List<AutoServiceViewModel>>
    {
    }
}
