using System.Collections.Generic;
using System.Linq;

namespace ARevillaSearchFight.Models
{
    public static class Extensions
    {
        public static string GetOverallWinnerTerm(this IEnumerable<ModelTermSearchResult> results)
        {
            return results.GroupBy(o => o.Term).Distinct().Select(grouping => new { Term = grouping.Key, Total = grouping.Sum(o => o.Count) }).OrderByDescending(o => o.Total).First().Term;
        }

        public static ModelTermSearchResult[] GetWinnersTermsPerSearchEngine(this IEnumerable<ModelTermSearchResult> results)
        {
            return results.Select(result => result.SearchEngineName).Distinct()
                .Select(engine => results.Where(result => result.SearchEngineName == engine).OrderByDescending(model => model.Count).Single()).ToArray();
        }
    }
}