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
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);

            if (user != null)
            {
                var car = new UserCar
                {
                    UserId = user.Id,
                    Brand = request.Brand,
                    Model = request.Model,
                    ProdYear = request.ProdYear,
                    VINcode = request.VINcode
                };
            }

            return new ResponceModel
            {
                Message = "First you need to register or log in",
                StatusCode = 401
            };
        }
    }
}
