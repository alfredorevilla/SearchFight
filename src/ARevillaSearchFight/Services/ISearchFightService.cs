using ARevillaSearchFight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARevillaSearchFight.Services
{
    public interface ISearchFightService
    {
        string GetOverallWinnerTerm(IEnumerable<ModelTermSearchResult> results);

        ModelTermSearchResult[] GetWinnersTermsPerSearchEngine(IEnumerable<ModelTermSearchResult> results);
    }
}