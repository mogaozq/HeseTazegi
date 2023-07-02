using FluentValidation;
using HeseTazegi.Application.Foods.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeseTazegi.Application.Foods.Validators
{
    public class GetNonAllergicSimilarFoodsQueryValidator: AbstractValidator<GetNonAllergicSimilarFoodsQuery>
    {
        public GetNonAllergicSimilarFoodsQueryValidator()
        {
            RuleFor(q => q.FoodId).GreaterThan(0).WithMessage("foodId must be positve");
        }
    }
}
