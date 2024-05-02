using AutoService.Domain.Entities.ViewModels.NewsCommentViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.NewsCases.NewsCommentCases.Queries
{
    public class GetAllNewsCommentQuery : IRequest<List<NewsCommentViewModel>>
    {
    }
}
