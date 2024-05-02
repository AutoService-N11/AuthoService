using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.ShopCases.CarSeatCases.Commands;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatCases.Handlers
{
    public class UpdateCarSeatCommandHandler : IRequestHandler<UpdateCarSeatCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public UpdateCarSeatCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(UpdateCarSeatCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.CarSeats.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res != null)
            {
                res.Name = request.Name;
                res.Price = request.Price;
                res.CategoryId = request.CategoryId;
                res.BrandId = request.BrandId;
                res.Mass = request.Mass;
                res.Size = request.Size;
                res.ProdCountry = request.ProdCountry;
                res.Guarantee = request.Guarantee;

                return new ResponceModel
                {
                    Message = "Changes saved!",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }
            return new ResponceModel
            {
                Message = "Something Went Wrong",
                StatusCode = 404,
            };
        }


    }
}
