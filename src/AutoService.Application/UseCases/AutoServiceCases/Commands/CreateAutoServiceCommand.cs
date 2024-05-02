using AutoService.Application.Abstractions;
using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.AutoServiceCases.Commands
{
    public class CreateAutoServiceCommand : IRequest<ResponceModel>
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string WebSitePath { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
