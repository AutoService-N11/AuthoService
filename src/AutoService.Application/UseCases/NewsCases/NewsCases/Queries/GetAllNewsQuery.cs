using AutoService.Domain.Entities.ViewModels.NewsViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.NewsCases.NewsCases.Queries
{
    public class GetAllNewsQuery : IRequest<List<NewsViewModel>>
    {
    }
}
