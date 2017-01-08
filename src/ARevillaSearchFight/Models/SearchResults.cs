using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ARevillaSearchFight.Models
{
    public class SearchResults : IEnumerable<SearchResultItem>
    {
        private SearchResultItem[] _items;

        public SearchResults(ISearchEngine engine, string term, IEnumerable<SearchResultItem> items, TimeSpan timeTaken)
        {
            if (engine == null)
            {
                throw new ArgumentNullException(nameof(engine));
            }
            if (string.IsNullOrWhiteSpace(term))
            {
                throw new ArgumentNullException(nameof(term));
            }
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            this.SearchEngine = engine;
            this.Term = term;
            this._items = items.ToArray();
            this.TimeTaken = timeTaken;
        }

        public ISearchEngine SearchEngine { get; }

        public string Term { get; }

        public TimeSpan TimeTaken { get; set; }

        public IEnumerator<SearchResultItem> GetEnumerator()
        {
            return ((IEnumerable<SearchResultItem>)this._items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this._items).GetEnumerator();
        }
    }
}