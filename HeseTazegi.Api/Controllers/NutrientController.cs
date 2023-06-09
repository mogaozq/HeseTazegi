using HeseTazegi.Application.Nutrients.Dtos;
using HeseTazegi.Application.Nutrients.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeseTazegi.Api.Controllers
{

    public class NutrientController : BaseController
    {
        private readonly IMediator _mediator;

        public NutrientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<NutrientDto>> GetAllNutrientsAsync()
        {
            return await _mediator.Send(new GetAllNutrientsQuery());
        }
    }
}
