using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CompanyCases.Commands;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CompanyCases.Handlers
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public CreateCompanyCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.CompanyName == request.CompanyName);

            if (company == null)
            {
                company.CompanyName = request.CompanyName;
                company.PhotoPath = request.PhotoPath;
                company.CompanyHistory = request.CompanyHistory;
                company.CompanyCategoryId = request.CompanyCategoryId;

                await _context.Companies.AddAsync(company);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponceModel
                {
                    Message = "You succesfully registered your company!",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }

            return new ResponceModel
            {
                Message = "This company already exists",
                StatusCode = 409
            };
        }
    }
}
