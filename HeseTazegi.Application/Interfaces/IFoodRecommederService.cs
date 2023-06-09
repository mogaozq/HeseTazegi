using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeseTazegi.Application.Interfaces
{
    public interface IFoodRecommederService
    {
        /// <summary>
        /// finds ids of similar foods
        /// </summary>
        /// <param name="foodId"></param>
        /// <returns></returns>
        Task<IEnumerable<int>> FindSimilarFoodsAsync(int foodId);
    }
}
