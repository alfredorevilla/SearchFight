using ARevillaSearchFight.Models;
using ARevillaSearchFight.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARevillaSearchFight.Services
{
    public interface ISearchResultModelMapper
    {
        IEnumerable<ModelTermSearchResult> ToDataModel(IEnumerable<TermSearchResult> results);

        IEnumerable<TermSearchResult> ToViewDataModel(IEnumerable<ModelTermSearchResult> results);
    }
}