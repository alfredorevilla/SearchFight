using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARevillaSearchFight.Models
{
    public static class Extensions
    {
        /// <summary>
        /// Todo: Move to extension method?
        /// </summary>
        /// <param name="terms"></param>
        /// <returns></returns>
        public static string GetOverallWinnerTerm(this IEnumerable<ModelTermSearchResult> results)
        {
            return results.GroupBy(o => o.Term).Select(grouping => new { Term = grouping.Key, Total = grouping.Sum(o => o.Count) }).OrderByDescending(o => o.Total).First().Term;
        }

        /// <summary>
        /// Todo: Move to extension method?
        /// </summary>
        /// <param name="terms"></param>
        /// <returns></returns>
        public static ModelTermSearchResult[] GetWinnersTermsPerSearchEngine(this IEnumerable<ModelTermSearchResult> results)
        {
            return results.Select(result => result.SearchEngineName)
                .Select(engine => results.Where(result => result.SearchEngineName == engine).OrderByDescending(model => model.Count).Single()).ToArray();
        }
    }
}
