using HeseTazegi.Application.Ingredients.Dtos;
using HeseTazegi.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace HeseTazegi.Api.Controllers
{

    public class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Authentication & Authorization omitted for simplicity (FakeCurrentUserService is used)
        [HttpGet("allergicIngredients")]
        public async Task<IEnumerable<IngredientDto>> GetAllergicIngredientsAsync()
        {
            return await _mediator.Send(new GetAllergicIngredientsQuery());
        }
    }
}
