using ARevillaSearchFight.Search;
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
            this._engines = engines.ToArray();
        }

        public ISearchEngine[] _engines;

        public ModelTermSearchResult[] GetTermSearchResults(string[] terms)
        {
            var array = new ModelTermSearchResult[terms.Length * this._engines.Length];
            var i = 0;
            foreach (var term in terms)
            {
                foreach (var engine in _engines)
                {
                    array[i++] = new ModelTermSearchResult
                    {
                        Count = engine.GetSearchTotalCount(term),
                        SearchEngineName = engine.GetName(),
                        Term = term
                    };
                }
            }
            return array;
        }

        public bool TryValidateTerms(string[] terms, out string[] validationErrors)
        {
            List<string> errors = new List<string>();
            if (terms == null || (terms = terms.Select(o => StringHelper.RemoveExtraWhitespaces(o)).ToArray()).Distinct(StringComparer.CurrentCultureIgnoreCase).Count() < 2)
            {
                errors.Add("At least 2 non equal terms are required");
            }
            validationErrors = errors.ToArray();
            return !validationErrors.Any();
        }
    }
}