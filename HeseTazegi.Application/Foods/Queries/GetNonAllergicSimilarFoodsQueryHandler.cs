using AutoMapper;
using FluentValidation;
using HeseTazegi.Application.Foods.Dtos;
using HeseTazegi.Application.Interfaces;
using HeseTazegi.Application.Utilities;
using HeseTazegi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HeseTazegi.Application.Foods.Queries
{
    public class GetNonAllergicSimilarFoodsQueryHandler : IRequestHandler<GetNonAllergicSimilarFoodsQuery, IEnumerable<FoodDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IFoodRecommederService _foodRecommederService;
        private readonly IValidator<GetNonAllergicSimilarFoodsQuery> _validator;

        public GetNonAllergicSimilarFoodsQueryHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService, IFoodRecommederService foodRecommederService, IValidator<GetNonAllergicSimilarFoodsQuery> validator)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _foodRecommederService = foodRecommederService;
            _validator = validator;
        }

        public async Task<IEnumerable<FoodDto>> Handle(GetNonAllergicSimilarFoodsQuery request, CancellationToken cancellationToken)
        {
            var x = _validator.Validate(request);

            var allergicIngredientIds = await _context.UserAllergicIngredients.AsNoTracking()
                .Where(uai => uai.UserId == _currentUserService.UserId)
                .Select(uai => uai.IngredientId)
                .ToArrayAsync(cancellationToken: cancellationToken);

            var similarFoodIds = await _foodRecommederService.FindSimilarFoodsAsync(request.FoodId);

            var nonAllergicSimilarFoods = await _context.Foods.AsNoTracking()
               .Where(f => similarFoodIds.Contains(f.Id))
               .Where(f => f.FoodIngredients.Any(i => allergicIngredientIds.Contains(f.Id)) == false)
               .Include(f => f.Category)
               .Include(f => f.FoodIngredients).ThenInclude(fi => fi.Ingredient)
               .Include(f => f.FoodEquipments).ThenInclude(fe => fe.Equipment)
               .Include(f => f.NutritionFacts).ThenInclude(nf => nf.Nutrient)
               .ToArrayAsync(cancellationToken);

            return _mapper.Map<IEnumerable<FoodDto>>(nonAllergicSimilarFoods);
        }
    }
}
