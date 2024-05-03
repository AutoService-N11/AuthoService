using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CompanyCases.CompanyCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.CompanyModels;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace AutoService.Application.UseCases.CompanyCases.CompanyCases.Handlers
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateCompanyCommandHandler(IAppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponceModel> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var diplom = new Company()
                {
               
                    CompanyHistory = request.CompanyHistory,
                    CompanyName = request.CompanyName,
                    OwnerId = request.OwnerId
                };

                await _context.Companies.AddAsync(diplom);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponceModel()
                {
                    Message = "Create",
                    StatusCode = 201,
                    IsSuccess = true,
                };

            }
            catch (Exception ex)
            {
                return new ResponceModel()
                {
                    Message = ex.Message,
                    StatusCode = 500,
                    IsSuccess = false
                };
            }
        }
    }
}