using SearchFight.Models;
using SearchFight.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFight.Services
{
    public interface ISearchResultModelMapper
    {
        IEnumerable<ModelTermSearchResult> ToDataModel(IEnumerable<TermSearchResult> results);

        IEnumerable<TermSearchResult> ToViewDataModel(IEnumerable<ModelTermSearchResult> results);
    }
}