using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.AutoServiceCases.AutoServiceRatingCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.AutoServiceModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.AutoServiceCases.AutoServiceRatingCases.Handlers
{
    public class CreateAutoServiceRatingCommandHandler : IRequestHandler<CreateAutoServiceRatingCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public CreateAutoServiceRatingCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(CreateAutoServiceRatingCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.FirstName == request.UserFirstName && x.LastName == request.UserLastName);
            var autoservice = await _context.AutoServices.FirstOrDefaultAsync(x => x.Name == request.ServiceName);
            var car = await _context.Cars.FirstOrDefaultAsync(x => x.Brand == request.CarBrandName && x.Model == request.CarModelName);
            var service = await _context.Services.FirstOrDefaultAsync(x => x.Name == request.ServiceName);

            var comment = new AutoServiceRating
            {
                UserId = user.Id,
                AutoServiceId = autoservice.Id,
                CarId = car.Id,
                ServiceId = service.Id,
                Comment = request.Comment
            };

            await _context.AutoServiceRatings.AddAsync(comment);

            await _context.SaveChangesAsync(cancellationToken);

            return new ResponceModel 
            {
                Message = "Thanks for your review",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
