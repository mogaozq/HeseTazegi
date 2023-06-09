using HeseTazegi.Application.Equipments.Dtos;
using HeseTazegi.Application.Equipments.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace HeseTazegi.Api.Controllers
{

    public class EquipmentController : BaseController
    {
        private readonly IMediator _mediator;

        public EquipmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<EquipmentDto>> GetAllEquipmentsAsync()
        {
            return await _mediator.Send(new GetAllEquipmentsQuery());
        }
    }
}
