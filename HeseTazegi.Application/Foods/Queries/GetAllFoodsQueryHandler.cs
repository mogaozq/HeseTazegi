using AutoMapper;
using HeseTazegi.Application.Foods.Dtos;
using HeseTazegi.Application.Interfaces;
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
    public class GetAllFoodsQueryHandler : IRequestHandler<GetAllFoodsQuery, IEnumerable<FoodDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllFoodsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FoodDto>> Handle(GetAllFoodsQuery request, CancellationToken cancellationToken)
        {
            var foods = await _context.Foods.AsNoTracking()
                .Include(f => f.Category)
                .Include(f => f.FoodIngredients).ThenInclude(fi => fi.Ingredient)
                .Include(f => f.FoodEquipments).ThenInclude(fe=>fe.Equipment)
                .Include(f => f.NutritionFacts).ThenInclude(nf => nf.Nutrient)
                .ToArrayAsync(cancellationToken);

            return _mapper.Map<IEnumerable<FoodDto>>(foods);
        }
    }
}
