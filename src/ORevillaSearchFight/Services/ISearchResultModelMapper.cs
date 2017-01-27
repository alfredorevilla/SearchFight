using ORevillaSearchFight.Models;
using ORevillaSearchFight.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORevillaSearchFight.Services
{
    public interface ISearchResultModelMapper
    {
        IEnumerable<ModelTermSearchResult> ToDataModel(IEnumerable<TermSearchResult> results);

        IEnumerable<TermSearchResult> ToViewDataModel(IEnumerable<ModelTermSearchResult> results);
    }
}