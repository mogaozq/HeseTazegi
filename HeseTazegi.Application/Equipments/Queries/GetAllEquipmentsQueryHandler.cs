using AutoMapper;
using HeseTazegi.Application.Equipments.Dtos;
using HeseTazegi.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HeseTazegi.Application.Equipments.Queries
{
    public class GetAllEquipmentsQueryHandler : IRequestHandler<GetAllEquipmentsQuery, IEnumerable<EquipmentDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllEquipmentsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EquipmentDto>> Handle(GetAllEquipmentsQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Equipments.AsNoTracking()
                .ToArrayAsync(cancellationToken: cancellationToken);

            return _mapper.Map<IEnumerable<EquipmentDto>>(categories);
        }
    }
}
