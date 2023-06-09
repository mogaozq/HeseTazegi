using HeseTazegi.Application.Foods.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeseTazegi.Application.Foods.Queries
{
    public class GetNonAllergicSimilarFoodsQuery : IRequest<IEnumerable<FoodDto>>
    {
        public int FoodId { get; set; }

        public GetNonAllergicSimilarFoodsQuery(int foodId)
        {
            FoodId = foodId;
        }
    }
}
