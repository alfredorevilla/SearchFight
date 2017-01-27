using ORevillaSearchFight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORevillaSearchFight.Services
{
    public interface ISearchFightService
    {
        string GetOverallWinnerTerm(IEnumerable<ModelTermSearchResult> results);

        ModelTermSearchResult[] GetWinnersTermsPerSearchEngine(IEnumerable<ModelTermSearchResult> results);
    }
}