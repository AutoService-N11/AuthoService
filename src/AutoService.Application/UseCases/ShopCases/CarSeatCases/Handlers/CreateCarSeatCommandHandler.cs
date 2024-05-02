using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.ShopCases.CarSeatCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.ShopModels.CarSeatModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatCases.Handlers
{
    public class CreateCarSeatCommandHandler : IRequestHandler<CreateCarSeatCommand, ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateCarSeatCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponceModel> Handle(CreateCarSeatCommand request, CancellationToken cancellationToken)
        {
            var res = new CarSeat();
            res.Name = request.Name;
            res.Price = request.Price;
            res.CategoryId = request.CategoryId;
            res.BrandId = request.BrandId;
            res.Guarantee = request.Guarantee;
            res.Price = request.Price;
            res.Size = request.Size;
            res.Mass = request.Mass;    
            res.ProdCountry = request.ProdCountry;

            await _appDbContext.CarSeats.AddAsync(res);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return new ResponceModel
            {
                Message = "You succesfully added CarSeat",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}

