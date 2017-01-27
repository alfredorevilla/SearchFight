using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ORevillaSearchFight.Views.Models;

namespace ORevillaSearchFight.Models
{
    public interface ISearchFightModel
    {
        bool TryValidateTerms(string[] terms, out string[] validationErrors);

        ModelTermSearchResult[] GetTermSearchResults(string[] terms);
    }
}