using HeseTazegi.Application.Ingredients.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeseTazegi.Application.Ingredients.Queries
{
    public class GetAllIngredientsQuery : IRequest<IEnumerable<IngredientDto>>
    {
    }
}
