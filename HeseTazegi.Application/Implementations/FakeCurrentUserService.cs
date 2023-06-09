using HeseTazegi.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeseTazegi.Application.Implementations
{
    public class FakeCurrentUserService : ICurrentUserService
    {
        private readonly IApplicationDbContext _context;

        public FakeCurrentUserService(IApplicationDbContext context)
        {
            _context = context;
        }

        public int UserId => _context.Users.AsNoTracking().First().Id;
    }
}
