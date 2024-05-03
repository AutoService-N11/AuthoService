using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CompanyCases.CompanyCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.CompanyModels;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            // Check if file is not null
            if (request.PhotoPath == null || request.PhotoPath.Length == 0)
            {
                // Handle missing photo
                return new ResponceModel
                {
                    Message = "Photo is required",
                    StatusCode = 400
                };
            }

            // Check if the company already exists
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.CompanyName == request.CompanyName);
            if (company != null)
            {
                return new ResponceModel
                {
                    Message = "This company already exists",
                    StatusCode = 409
                };
            }

            // Generate file name and path
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.PhotoPath.FileName);
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "CompanyPhoto", fileName);

            try
            {
                // Ensure the directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                // Save the file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.PhotoPath.CopyToAsync(stream);
                }

                // Create a new company object
                company = new Company
                {
                    CompanyName = request.CompanyName,
                    PhotoPath = filePath,
                    CompanyHistory = request.CompanyHistory,
                    
                };

                // Add the company to the context and save changes
                await _context.Companies.AddAsync(company, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponceModel
                {
                    Message = "You successfully registered your company!",
                    StatusCode = 200,
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return new ResponceModel
                {
                    Message = $"An error occurred: {ex.Message}",
                    StatusCode = 500
                };
            }
        }
    }
}