using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CompanyCases.CompanyCases.Commands;
using AutoService.Domain.Entities.Models;
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
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.CompanyName == request.CompanyName);
            string fileName = "";
            string filePath = "";

            if (request.PhotoPath is not null)
            {
                var file = request.PhotoPath;


                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    filePath = Path.Combine(_webHostEnvironment.WebRootPath, "CompanyPhoto", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                
            }

                if (company == null)
                {
                    company.CompanyName = request.CompanyName;
                    company.PhotoPath = filePath;
                    company.CompanyHistory = request.CompanyHistory;

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
