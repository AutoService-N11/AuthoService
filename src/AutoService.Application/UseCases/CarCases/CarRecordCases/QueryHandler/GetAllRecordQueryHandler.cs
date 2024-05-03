using AutoService.Application.Abstractions;
using AutoService.Application.UseCases.CarCases.CarRecordCases.Queries;
using AutoService.Domain.Entities.ViewModels.CarRecordViewModels;
using AutoService.Domain.Entities.ViewModels.NewsCommentViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CarCases.CarRecordCases.QueryHandler
{
    public class GetAllRecordQueryHandler : IRequestHandler<GetAllCarRecordQuery,IEnumerable<CarRecordViewModel>>
    {
        private readonly IAppDbContext _context;

        public GetAllRecordQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarRecordViewModel>> Handle(GetAllCarRecordQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.CarRecords.ToListAsync(cancellationToken);

            var Comments = res.Select(c => new CarRecordViewModel
            {
                UserCarId = c.UserCarId,
                createdDate = c.createdDate,
                Probeg = c.Probeg,
                RecordTask = c.RecordTask,
                Comment = c.Comment,
                Price = c.Price,
            }).ToList();

            return Comments.Skip(request.PageIndex - 1)
                    .Take(request.Size)
                            .ToList(); ;
        }

    }
}
