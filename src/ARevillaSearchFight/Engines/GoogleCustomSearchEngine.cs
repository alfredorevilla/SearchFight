using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARevillaSearchFight.Models;

namespace ARevillaSearchFight.Engines
{
    [SearchEngineMetadata("Google")]
    public class GoogleCustomSearchEngine : ISearchEngine
    {
        public string Name
        {
            get { return nameof(GoogleCustomSearchEngine); }
        }

        public SearchResults Search(string term)
        {
            throw new NotImplementedException();
        }
    }
}
