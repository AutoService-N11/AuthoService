using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.ShopCases.CarSeatBrandCases.Queries;
using AutoService.Domain.Entities.Models.ShopModels.CarSeatModels;
using AutoService.Domain.Entities.ViewModels.CarSeatViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatBrandCases.QueryHandlers
{
    public class GetAllCarSeatBrandQueryHandler : IRequestHandler<GetAllCarSeatBrandQuery, IEnumerable<CarSeatBrandViewModels>>
    {
        private readonly IAppDbContext _context;

        public GetAllCarSeatBrandQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarSeatBrandViewModels>> Handle(GetAllCarSeatBrandQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.CarSeatBrands.ToListAsync(cancellationToken);
            IEnumerable<CarSeatBrandViewModels> carSeatbrandViewModels = res.Select(x => new CarSeatBrandViewModels
            {
                Name = x.Name,
            }).ToList();
            return carSeatbrandViewModels;
        }
    }
}

