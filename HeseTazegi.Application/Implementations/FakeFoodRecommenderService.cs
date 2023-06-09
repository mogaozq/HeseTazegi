using AutoMapper;
using HeseTazegi.Application.Interfaces;
using HeseTazegi.Application.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HeseTazegi.Application.Implementations
{
    //todo: add real implementation
    public class FakeFoodRecommenderService : IFoodRecommederService
    {
        private readonly IApplicationDbContext _context;

        public FakeFoodRecommenderService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<int>> FindSimilarFoodsAsync(int foodId)
        {
            //note: actully this is a fake impementation just in sake of app to work.
            //we have to use AI or DataMining or ElasticSearch to find similar foods.
            //we can implement this somehow using ef core or sql but its not efficient and is not recommended at all.

            return await _context.Foods.AsNoTracking()
                .Where(f => f.Id != foodId)
                .Select(f => f.Id)
                .ToArrayAsync();
        }
    }
}
