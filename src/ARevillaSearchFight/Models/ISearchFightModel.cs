using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARevillaSearchFight.Views.Models;

namespace ARevillaSearchFight.Models
{
    public interface ISearchFightModel
    {
        bool TryValidateTerms(string[] terms, out string[] validationErrors);

        /// <summary>
        /// Todo: Move to extension method?
        /// </summary>
        /// <param name="terms"></param>
        /// <returns></returns>
        string GetOverallWinnerTerm(string[] terms);

        /// <summary>
        /// Todo: Move to extension method?
        /// </summary>
        /// <param name="terms"></param>
        /// <returns></returns>
        TermSearchResult[] GetWinnersTermsPerSearchEngine(string[] terms);

        ModelTermSearchResult[] GetTermSearchResults(string[] terms);
    }
}
