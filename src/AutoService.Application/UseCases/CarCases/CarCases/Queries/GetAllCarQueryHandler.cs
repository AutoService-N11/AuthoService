using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.ViewModels.CarViewModel;
using AutoService.Domain.Entities.ViewModels.NewsViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CarCases.CarCases.Queries
{
    public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, IEnumerable<CarViewModel>>
    {
        private readonly IAppDbContext _context;

        public GetAllCarQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarViewModel>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Cars.ToListAsync(cancellationToken);

            List<CarViewModel> news = res.Select(x => new CarViewModel
            {
                Model = x.CarModel,
                Brand = x.Brand,
                ProdYear = x.ProdYear,
                VINcode = x.VINcode,
                UserId = x.UserId,
            }).ToList();

            return news.Skip(request.PageIndex - 1)
                    .Take(request.Size)
                            .ToList(); ;
        }
    }
}
