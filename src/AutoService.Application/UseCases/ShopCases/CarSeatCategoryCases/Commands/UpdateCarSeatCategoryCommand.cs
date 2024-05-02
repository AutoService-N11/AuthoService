using AutoService.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.Application.UseCases.ShopCases.CarSeatCategoryCases.Commands
{
    public class UpdateCarSeatCategoryCommand: IRequest<ResponceModel>
    {
        public Guid Id { get; set; }
        public string startAge { get; set; }
        public string endAge { get; set; }
    }
}
