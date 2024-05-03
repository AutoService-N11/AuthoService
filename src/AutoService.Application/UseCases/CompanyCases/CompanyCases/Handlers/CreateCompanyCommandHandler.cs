using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CompanyCases.CompanyCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.CompanyModels;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            string fileName = "";
            string filePath = "";

            if (request.FormFile is not null)
            {
                var file = request.FormFile;


                try
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Company", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

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
            try
            {

                var diplom = new Company()
                {
               
                    CompanyHistory = request.CompanyHistory,
                    Photo = "/Company" + filePath,
                    CompanyName = request.CompanyName,
                    CompanyCategoriesId = request.CompanyCategoryId
                };
                var auto = await _context.AutoServices.FirstOrDefaultAsync(x => x.Name == diplom.CompanyName);
                auto.Photo = "/Company" + filePath;

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