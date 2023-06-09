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

namespace HeseTazegi.Application.Ingredients.Queries
{
    public class GetAllIngredientsQueryHandler : IRequestHandler<GetAllIngredientsQuery, IEnumerable<IngredientDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllIngredientsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IngredientDto>> Handle(GetAllIngredientsQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Ingredients.AsNoTracking()
                .ToArrayAsync(cancellationToken: cancellationToken);

            return _mapper.Map<IEnumerable<IngredientDto>>(categories);
        }
    }
}
