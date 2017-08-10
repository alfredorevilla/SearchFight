using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SearchFight.Views.Models;

namespace SearchFight.Models
{
    public interface ISearchFightModel
    {
        ModelTermSearchResult[] GetTermSearchResults(string[] terms);

        bool TryValidateTerms(string[] terms, out string[] validationErrors);
    }
}