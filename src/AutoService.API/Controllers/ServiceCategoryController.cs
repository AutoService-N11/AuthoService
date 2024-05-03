using AutoService.Application.UseCases.ServiceCases.ServiceCases.Commands;
using AutoService.Application.UseCases.ServiceCases.ServiceCases.Queries;
using AutoService.Domain.Entities.Models.ServiceModels;
using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoService.Application.UseCases.ServiceCases.ServiceCategoryCases.Commands;
using AutoService.Application.UseCases.ServiceCases.ServiceCategoryCases.Queries;

namespace AutoService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServiceCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ServiceCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponceModel> CreateService(CreateServiceCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }
        [HttpGet]
        public async Task<List<ServiceCategory>> GetAllService([FromQuery] GetAllServiceCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpPut]
        public async Task<ResponceModel> UpdateService(UpdateServiceCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpDelete]
        public async Task<ResponceModel> DeleteService(DeleteServiceCategoryCommand request)
        {
            var result = await _mediator.Send(request);
            return result;
        }
    }
}
