using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.AutoServiceCases.AutoServiceCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.AutoServiceModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.AutoServiceCases.AutoServiceCases.Handlers
{
    public class CreateAutoServiceCommandHandler : IRequestHandler<CreateAutoServiceCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public CreateAutoServiceCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(CreateAutoServiceCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new ResponceModel
                {
                    Message = "First fill properties!",
                    StatusCode = 401
                };
            }

            var services = _context.AutoServices.Where(x => x.CompanyId == request.CompanyId && x.Name == request.Name);

            if (services == null)
            {
                var autoservice = new AutoServiceModel
                {
                    CompanyId = request.CompanyId,
                    Name = request.Name,
                    Location = request.Location,
                    WebSitePath = request.WebSitePath,
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email
                };

                await _context.AutoServices.AddAsync(autoservice);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponceModel
                {
                    Message = "You succesfully registered your service!",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }

            return new ResponceModel
            {
                Message = "This Autoservice already exists!",
                StatusCode = 409
            };
        }
    }
}
