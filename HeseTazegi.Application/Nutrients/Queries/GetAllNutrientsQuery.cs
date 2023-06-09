using HeseTazegi.Application.Nutrients.Dtos;
using HeseTazegi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeseTazegi.Application.Nutrients.Queries
{
    public class GetAllNutrientsQuery : IRequest<IEnumerable<NutrientDto>>
    {
    }
}
