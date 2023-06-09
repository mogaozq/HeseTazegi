using AutoMapper;
using HeseTazegi.Application.Ingredients.Dtos;
using HeseTazegi.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HeseTazegi.Application.Users.Queries
{
    public class GetAllergicIngredientsQueryHandler : IRequestHandler<GetAllergicIngredientsQuery, IEnumerable<IngredientDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetAllergicIngredientsQueryHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<IEnumerable<IngredientDto>> Handle(GetAllergicIngredientsQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.AsNoTracking()
                .Where(u => u.Id == _currentUserService.UserId)
                .Include(u => u.UserAllergicIngredients).ThenInclude(uai=>uai.Ingredient)
                .SingleAsync(cancellationToken: cancellationToken);

            return _mapper.Map<IEnumerable<IngredientDto>>(user.UserAllergicIngredients.Select(uai=>uai.Ingredient));
        }
    }
}
