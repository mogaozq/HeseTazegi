using AutoMapper;
using HeseTazegi.Application.Nutrients.Dtos;
using HeseTazegi.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HeseTazegi.Application.Nutrients.Queries
{
    public class GetAllNutrientsQueryHandler : IRequestHandler<GetAllNutrientsQuery, IEnumerable<NutrientDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllNutrientsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NutrientDto>> Handle(GetAllNutrientsQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Nutrients.AsNoTracking()
                .ToArrayAsync(cancellationToken: cancellationToken);

            return _mapper.Map<IEnumerable<NutrientDto>>(categories);
        }
    }
}
