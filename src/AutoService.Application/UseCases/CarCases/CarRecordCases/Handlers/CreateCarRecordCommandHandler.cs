using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CarCases.CarRecordCases.Commands;
using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.CarModels;
using AutoService.Domain.Entities.ViewModels.CarRecordViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CarCases.CarRecordCases.Handlers
{
    public class CreateCarRecordCommandHandler : IRequestHandler<CreateCarRecordCommand, ResponceModel>
    {
        private readonly IAppDbContext _context;

        public CreateCarRecordCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(CreateCarRecordCommand request, CancellationToken cancellationToken)
        {
            var result = new CarRecord()
            {
                UserCarId = request.UserCarId,
                createdDate = request.createdDate,
                Probeg = request.Probeg,
                RecordTask = request.RecordTask,
                Comment = request.Comment,
                Price = request.Price,
            };
            return new ResponceModel
            {
                Message = "CarRecord created",
                StatusCode = 200,

            };
        }
    }
}
