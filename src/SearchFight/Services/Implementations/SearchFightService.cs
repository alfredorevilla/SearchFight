using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SearchFight.Models;

namespace SearchFight.Services.Implementations
{
    public class SearchFightService : ISearchFightService
    {
        public string GetOverallWinnerTerm(IEnumerable<ModelTermSearchResult> results)
        {
            return results.GroupBy(o => o.Term).Distinct().Select(grouping => new { Term = grouping.Key, Total = grouping.Sum(o => o.Count) }).OrderByDescending(o => o.Total).First().Term;
        }

        public ModelTermSearchResult[] GetWinnersTermsPerSearchEngine(IEnumerable<ModelTermSearchResult> results)
        {
            return results.Select(result => result.SearchEngineName).Distinct()
                .Select(engine => results.Where(result => result.SearchEngineName == engine).OrderByDescending(model => model.Count).First()).ToArray();
        }
    }
}