using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.NewsCases.NewsCommentCases.Queries;
using AutoService.Domain.Entities.ViewModels.NewsCommentViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.NewsCases.NewsCommentCases.Handlers.QueryHandlers
{
    public class GetAllNewsCommentQueryHandler : IRequestHandler<GetAllNewsCommentQuery, List<NewsCommentViewModel>>
    {
        private readonly IAppDbContext _context;

        public GetAllNewsCommentQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<NewsCommentViewModel>> Handle(GetAllNewsCommentQuery request, CancellationToken cancellationToken)
        {
            var comments = await _context.newsComments.ToListAsync(cancellationToken);

            var Comments = comments.Select(c => new NewsCommentViewModel
            {
                firstName = c.userFirstName,
                lastName = c.userLastName,
                Comment = c.Comment
            }).ToList();

            return Comments;
        }
    }
}
