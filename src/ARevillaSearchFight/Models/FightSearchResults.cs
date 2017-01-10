using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARevillaSearchFight.Models
{
    public class FightSearchResults : IEnumerable<SearchResults>
    {
        IEnumerable<ISearchEngine> SearchEngines { get; }

        IEnumerable<string> Terms { get; set; }

        public IEnumerator<SearchResults> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
