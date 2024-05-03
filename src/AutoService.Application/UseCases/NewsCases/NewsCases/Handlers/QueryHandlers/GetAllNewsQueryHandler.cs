using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.NewsCases.NewsCases.Queries;
using AutoService.Domain.Entities.ViewModels.NewsViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.NewsCases.NewsCases.Handlers.QueryHandlers
{
    public class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, List<NewsViewModel>>
    {
        private readonly IAppDbContext _context;

        public GetAllNewsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<NewsViewModel>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {
            var News = await _context.news.ToListAsync(cancellationToken);

            List<NewsViewModel> news = News.Select(x => new NewsViewModel
            {
                Name = x.Name,
                Description = x.Description,
                mainPhotoPath = x.MainPhotoPath
            }).ToList();

            return news.Skip(request.PageIndex - 1)
                    .Take(request.Size).ToList();
        }
    }
}
