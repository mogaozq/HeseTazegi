using HeseTazegi.Application.Categories.Dtos;
using HeseTazegi.Application.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace HeseTazegi.Api.Controllers
{

    public class CategoryController : BaseController
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            return await _mediator.Send(new GetAllCategoriesQuery());
        }
    }
}
