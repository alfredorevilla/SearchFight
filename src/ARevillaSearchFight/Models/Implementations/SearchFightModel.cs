using ARevillaSearchFight.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ARevillaSearchFight.Models.Implementations
{
    public class SearchFightModel : ISearchFightModel
    {
        public SearchFightModel(IEnumerable<ISearchEngine> engines)
        {
            this.Engines = engines.ToArray();
        }

        public ISearchEngine[] Engines { get; }

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
            List<string> errors = new List<string>();
            if (terms == null || terms.Count() < 2)
            {
                errors.Add("You must send at least 2 terms");
            }
            else
            {
            }
            validationErrors = errors.ToArray();
            return validationErrors.Any();
        }
    }
}