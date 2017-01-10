using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARevillaSearchFight.Models;

namespace ARevillaSearchFight.Engines
{
    [SearchEngineMetadata("Bing")]
    public class BingSearchEngine : ISearchEngine
    {
        public string Name
        {
            get { return nameof(BingSearchEngine); }
        }

        public int GetSearchTotalCount(string term)
        {
            throw new NotImplementedException();
        }

        public SearchResults Search(string term, int offset, int maxResults)
        {
            throw new NotImplementedException();
        }
    }
}
