using HeseTazegi.Application.Equipments.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeseTazegi.Application.Equipments.Queries
{
    public class GetAllEquipmentsQuery : IRequest<IEnumerable<EquipmentDto>>
    {
    }
}
