using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.NewsCases.NewsCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.NewsModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.NewsCases.NewsCases.Handlers
{
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public CreateNewsCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            var news = new News
            {
                Name = request.Name,
                Description = request.Description,
                MainPhotoPath = request.MainPhotoPath,
            };

            await _context.news.AddAsync(news);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponceModel
            {
                Message = "News created",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
