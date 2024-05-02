using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.AutoServiceCases.AutoServiceRatingCases.Commands
{
    public class CreateAutoServiceRatingCommand : IRequest<ResponceModel>
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string AutoServiceName { get; set; }
        public string CarBrandName { get; set; }
        public string CarModelName { get; set; }
        public string ServiceName { get; set; }
        public string Comment { get; set; }
    }
}
