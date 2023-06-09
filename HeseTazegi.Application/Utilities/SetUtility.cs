using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeseTazegi.Application.Utilities
{
    public static class SetUtility
    {
        public static List<List<T>> CreateSubsets<T>(IEnumerable<T> items, int minSize)
        {
            var subsets = new List<List<T>>();

            for (int i = 0; i < Math.Pow(2, items.Count()); i++)
            {
                var subset = new List<T>();
                for (int j = 0; j < items.Count(); j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        subset.Add(items.ElementAt(j));
                    }
                }

                if (subset.Count >= minSize) // check if the size of subset is greater than or equal to minSize
                {
                    subsets.Add(subset);
                }
            }

            return subsets;
        }

        public static List<List<T>> CreateSubsets<T>(IEnumerable<T> items)
        {
            var subsets = new List<List<T>>();

            for (int i = 0; i < Math.Pow(2, items.Count()); i++)
            {
                var subset = new List<T>();
                for (int j = 0; j < items.Count(); j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        subset.Add(items.ElementAt(j));
                    }
                }
                subsets.Add(subset);
            }

            foreach (var subset in subsets)
            {
                Console.WriteLine(string.Join(", ", subset));
            }
            return subsets;
        }
    }
}
