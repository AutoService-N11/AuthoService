using AutoService.Application.UseCases.ServiceCases.ServiceCategoryCases.Commands;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoService.Application.UseCases.ShopCases.CarSeatBrandCases.Queries;
using AutoService.Domain.Entities.ViewModels.CarSeatViewModels;
using AutoService.Application.UseCases.ShopCases.CarSeatBrandCases.Commands;

namespace AutoService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarSeatBrandController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarSeatBrandController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponceModel> CreateServiceCategory(CreateCarSeatBrandCommand request)
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
        public async Task<ResponceModel> UpdateServiceCategory(UpdateCarSeatBrandCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpDelete]
        public async Task<ResponceModel> DeleteServiceCategory(DeleteCarSeatBrandCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }
    }
}
