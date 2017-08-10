using SearchFight.Models;
using SearchFight.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFight.Services.Implementations
{
    public class SearchResultModelMapper : ISearchResultModelMapper
    {
        public IEnumerable<ModelTermSearchResult> ToDataModel(IEnumerable<TermSearchResult> results)
        {
            foreach (var item in results)
            {
                yield return new ModelTermSearchResult
                {
                    Count = item.Count,
                    SearchEngineName = item.SearchEngineName,
                    Term = item.Term
                };
            }
        }

        public IEnumerable<TermSearchResult> ToViewDataModel(IEnumerable<ModelTermSearchResult> results)
        {
            foreach (var item in results)
            {
                yield return new TermSearchResult
                {
                    Count = item.Count,
                    SearchEngineName = item.SearchEngineName,
                    Term = item.Term
                };
            }
        }
    }
}