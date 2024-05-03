using AutoService.Application.UseCases.ServiceCases.ServiceCategoryCases.Commands;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoService.Application.UseCases.ShopCases.CarSeatBrandCases.Queries;
using AutoService.Domain.Entities.ViewModels.CarSeatViewModels;

namespace AutoService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarSeateBrand : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarSeateBrand(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponceModel> CreateServiceCategory(UpdateSeateBrandCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }
        [HttpGet]
        public async Task<IEnumerable<CarSeatBrandViewModels>> GetAllServiceCategory([FromQuery] GetAllCarSeatBrandQuery request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpPut]
        public async Task<ResponceModel> UpdateServiceCategory(UpdateSeateBrandCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpDelete]
        public async Task<ResponceModel> DeleteServiceCategory(DeleteSeateBrandCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }
    }
}
