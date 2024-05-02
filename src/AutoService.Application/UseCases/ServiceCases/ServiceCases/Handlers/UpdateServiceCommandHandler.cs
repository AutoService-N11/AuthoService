using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.ServiceCases.ServiceCases.Commands;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace AutoService.Application.UseCases.ServiceCases.ServiceCases.Handlers
{
    public class UpdateServiceCommandHandler:IRequestHandler<UpdateServiceCommand,ResponceModel>
    {
        private readonly IAppDbContext _appDbContext;
        public UpdateServiceCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ResponceModel> Handle(UpdateServiceCommand request, CancellationToken cancellation)
        {
            var user = await _appDbContext.Services.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (user == null) 
            {
                return new ResponceModel
                {
                    Message = "Service Not Found",
                    StatusCode = 404,
                    IsSuccess = true
                };
            }
            user.Name = request.Name;
            await _appDbContext.Services.AddAsync(user);
            await _appDbContext.SaveChangesAsync(cancellation);
            return new ResponceModel
            {
                Message = "You succesfully added a new Service!",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
