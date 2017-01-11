﻿using ARevillaSearchFight.Search;
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

        /// <summary>
        /// Todo: Move to extension method?
        /// </summary>
        /// <param name="terms"></param>
        /// <returns></returns>
        public string GetOverallWinnerTerm(string[] terms)
        {
            var results = this.GetTermSearchResults(terms);
            return results.GroupBy(o => o.Term).Select(grouping => new { Term = grouping.Key, Total = grouping.Sum(o => o.Count) }).OrderByDescending(o => o.Total).First().Term;
        }

        public TermSearchResult[] GetTermSearchResults(string[] terms)
        {
            var array = new TermSearchResult[terms.Length * this.SearchEngines.Length];
            for (var i = 0; i < terms.Length;)
            {
                foreach (var engine in this.SearchEngines)
                {
                    array[i] = new TermSearchResult
                    {
                        Count = engine.GetSearchTotalCount(terms[i]),
                        SearchEngineName = engine.GetName(),
                        Term = terms[i++]
                    };
                }
            }
            return array;
        }

        /// <summary>
        /// Todo: Move to extension method?
        /// </summary>
        /// <param name="terms"></param>
        /// <returns></returns>
        public TermSearchResult[] GetWinnersTermsPerSearchEngine(string[] terms)
        {
            var results = this.GetTermSearchResults(terms);
            return this.SearchEngines.Select(engine => results.Where(result => result.SearchEngineName == engine.GetName()).OrderByDescending(o => o.Count).Single()).Select(o => o).ToArray();
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