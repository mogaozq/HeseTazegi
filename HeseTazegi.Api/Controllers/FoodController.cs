using HeseTazegi.Application.Foods.Dtos;
using HeseTazegi.Application.Foods.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace HeseTazegi.Api.Controllers
{

    public class FoodController : BaseController
    {
        private readonly IMediator _mediator;

        public FoodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<FoodDto>> GetAllFoodsAsync()
        {
            return await _mediator.Send(new GetAllFoodsQuery());

        }

        [HttpGet("nonAllergicSimilarFoods/{foodId}")]
        public async Task<IEnumerable<FoodDto>> GetNonAllergicSimilarFoodsAsync(int foodId)
        {
            return await _mediator.Send(new GetNonAllergicSimilarFoodsQuery(foodId));
     
        }
    }
}
