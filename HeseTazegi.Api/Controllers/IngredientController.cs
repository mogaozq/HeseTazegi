using HeseTazegi.Application.Categories.Dtos;
using HeseTazegi.Application.Ingredients.Dtos;
using HeseTazegi.Application.Ingredients.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace HeseTazegi.Api.Controllers
{

    public class IngredientController : BaseController
    {
        private readonly IMediator _mediator;

        public IngredientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<IngredientDto>> GetAllIngredientsAsync()
        {
            return await _mediator.Send(new GetAllIngredientsQuery());
        }
    }
}
