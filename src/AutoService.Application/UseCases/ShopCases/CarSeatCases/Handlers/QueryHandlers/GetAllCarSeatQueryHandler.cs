using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.ShopCases.CarSeatCases.Queries;
using AutoService.Domain.Entities.ViewModels.CarSeatViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatCases.Handlers.QueryHandlers
{
    public class GetAllCarSeatQueryHandler : IRequestHandler<GetAllCarSeatsQuery, IEnumerable<CarSeatViewModel>>
    {
        private readonly IAppDbContext _context;

        public GetAllCarSeatQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarSeatViewModel>> Handle(GetAllCarSeatsQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.CarSeats.ToListAsync(cancellationToken);
            IEnumerable<CarSeatViewModel> carSeatViewModels = res.Select(x => new CarSeatViewModel
            {
                Name = x.Name,
                Price = x.Price,
                Guarantee = x.Guarantee,
                Mass = x.Mass,
                Size = x.Size,
                ProdCountry = x.ProdCountry,
                CategoryStart = x.CarSeatCategory.startAge,
                CategoryEnd = x.CarSeatCategory.endAge,
                BrandName = x.CarSeatBrand.Name,
            }).ToList();
            return carSeatViewModels;
        }
    }
}
