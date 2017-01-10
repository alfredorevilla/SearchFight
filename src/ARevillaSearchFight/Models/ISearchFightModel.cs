using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARevillaSearchFight.Views.Models;

namespace ARevillaSearchFight.Models
{
    public interface ISearchFightModel
    {
        bool ValidateTerms(string[] terms, out string[] validationErrors);
        string GetOverallWinnerTerm(string[] terms);
        WinnerTermPerEngine[] GetWinnersTermsPerSearchEngine(string[] terms);
        ResultCountPerTermPerEngine[] GetResultsCountPerTermPerEngine(string[] terms);
    }
}
