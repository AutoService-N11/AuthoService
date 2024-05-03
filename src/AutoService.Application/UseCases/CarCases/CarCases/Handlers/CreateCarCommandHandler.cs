using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CarCases.CarCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.CarModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CarCases.CarCases.Handlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public CreateCarCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponceModel> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = new UserCar()
            {
                Brand = request.Brand,
                CarModel = request.CarModel,
                ProdYear = request.ProdYear,
                VINcode = request.VINcode,
                UsersId = request.UserId
            };
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync(cancellationToken);
            return new ResponceModel()
            {
                Message = "Car created",
                StatusCode = 200,
                IsSuccess = true
            };
        }


    }
}
