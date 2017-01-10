using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARevillaSearchFight.Views.Models;

namespace ARevillaSearchFight.Models.Implementations
{
    public class SearchFightModel : ISearchFightModel
    {
        public SearchFightModel(IEnumerable<ISearchEngine> engines)
        {
            this.Engines = engines;
        }

        public IEnumerable<ISearchEngine> Engines { get; }

        public string GetOverallWinnerTerm(string[] terms)
        {
            throw new NotImplementedException();
        }

        public ResultCountPerTermPerEngine[] GetResultsCountPerTermPerEngine(string[] terms)
        {
            throw new NotImplementedException();
        }

        public WinnerTermPerEngine[] GetWinnersTermsPerSearchEngine(string[] terms)
        {
            throw new NotImplementedException();
        }

        public bool ValidateTerms(string[] terms, out string[] validationErrors)
        {
            throw new NotImplementedException();
        }
    }
}
