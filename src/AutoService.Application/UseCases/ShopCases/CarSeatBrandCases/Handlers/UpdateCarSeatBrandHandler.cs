using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.ShopCases.CarSeatBrandCases.Commands;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatBrandCases.Handlers
{
    public class UpdateCarSeatBrandHandler : IRequestHandler<UpdateCarSeatBrandCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public UpdateCarSeatBrandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(UpdateCarSeatBrandCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.CarSeatBrands.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res != null)
            {
                res.Name = request.Name;
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
