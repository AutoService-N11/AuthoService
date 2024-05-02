using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.AutoServiceCases.AutoServiceCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.ServiceModels;
using MediatR;


namespace AutoService.Application.UseCases.ServiceCases.ServiceCases.Handlers
{
    public class CreateServiceCommandHandler: IRequestHandler<CreateAutoServiceCommand,ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public CreateServiceCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ResponceModel> Handle(CreateAutoServiceCommand request, CancellationToken cancellationToken)
        {
            Service service = new Service
            {
                Name = request.Name,
                CompanyID = request.CompanyId
            };

            _appDbContext.Services.Add(service);
            await _appDbContext.SaveChangesAsync(cancellationToken); 

            return new ResponceModel
            {
                IsSuccess = true,
                Message = "Service created successfully",

            };
        }


    }
}
