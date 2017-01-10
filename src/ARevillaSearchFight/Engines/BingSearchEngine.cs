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

        public SearchResults Search(string term)
        {
            throw new NotImplementedException();
        }
    }
}
