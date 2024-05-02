using AutoService.Domain.Entities.Models;
using AutoService.Domain.Entities.Models.CompanyModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.CompanyCases.Commands
{
    public class CreateCompanyCommand : IRequest<ResponceModel>
    {
        public string CompanyName { get; set; }

        public string PhotoPath { get; set; }

        [MaxLength(2000)]
        public string CompanyHistory { get; set; }

        public List<Guid> CompanyCategoryId { get; set; }
    }
}
