using ARevillaSearchFight.Search;
using ARevillaSearchFight.Views.Models;
using System.Collections.Generic;
using System.Linq;

namespace ARevillaSearchFight.Models.Implementations
{
    public class SearchFightModel : ISearchFightModel
    {
        public SearchFightModel(IEnumerable<ISearchEngine> engines)
        {
            this.SearchEngines = engines.ToArray();
        }

        public ISearchEngine[] SearchEngines { get; }

        public ModelTermSearchResult[] GetTermSearchResults(string[] terms)
        {
            var array = new ModelTermSearchResult[terms.Length * this.SearchEngines.Length];
            for (var i = 0; i < terms.Length;)
            {
                foreach (var engine in this.SearchEngines)
                {
                    array[i] = new ModelTermSearchResult
                    {
                        Count = engine.GetSearchTotalCount(terms[i]),
                        SearchEngineName = engine.GetName(),
                        Term = terms[i++]
                    };
                }
            }
            return array;
        }

            public bool TryValidateTerms(string[] terms, out string[] validationErrors)
        {
            List<string> errors = new List<string>();
            if (terms == null || (terms = terms.Select(o => StringHelper.RemoveExtraWhitespaces(o)).ToArray()).Count() < 2)
            {
                errors.Add("At least 2 non equal terms are required");
            }
            validationErrors = errors.ToArray();
            return validationErrors.Any();
        }
    }
}