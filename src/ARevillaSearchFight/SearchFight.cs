using ARevillaSearchFight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ARevillaSearchFight
{
    public class SearchFight
    {
        public SearchFight(IEnumerable<ISearchEngine> searchEngines, IOutput output)
        {
            if (searchEngines == null)
            {
                throw new ArgumentNullException(nameof(searchEngines));
            }
            if (searchEngines.Count() < 2)
            {
                throw new ArgumentException($"At least 2 {nameof(ISearchEngine)} instances are required", nameof(searchEngines));
            }
            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            this.Output = output;
            this.SearchEngines = searchEngines.ToArray();
        }

        public IOutput Output { get; }
        public ISearchEngine[] SearchEngines { get; }

        /// <summary>
        /// Searches for 2 or more non-equal terms using 2 or more search engines
        /// </summary>
        /// <param name="terms">Terms collection must have at least 2 non-equal (after removing extra whitespaces) terms</param>
        public void Fight(string[] terms)
        {
            if (terms == null)
            {
                throw new ArgumentNullException(nameof(terms));
            }
            terms = terms.Select(o => StringHelper.RemoveExtraWhitespaces(o)).Distinct(StringComparer.CurrentCultureIgnoreCase).ToArray();
            if (terms.Count() <= 1)
            {
                throw new ArgumentException($"At least 2 non equal terms are required", nameof(terms));
            }

            var results = new SearchResults[this.SearchEngines.Length * terms.Length];
            var i = 0;
            foreach (var item1 in terms)
            {
                foreach (var item2 in this.SearchEngines)
                {
                    results[i++] = item2.Search(item1);
                }
            }
            //  terms engines search results
            //  Excepted output:
            //  .net: Google: 4450000000 MSN Search: 12354420
            //  java: Google: 966000000 MSN Search: 94381485
            foreach (var item in terms)
            {
                var results2 = results.Where(o => o.Term.Equals(item, StringComparison.CurrentCultureIgnoreCase));
                var line1 = this.SearchEngines.Select(o => new { EngineName = o.Name, Total = results2.Single(o2 => o2.SearchEngine == o).Count() });
                var str = $"{item}: " + string.Join(" ", line1.Select(o => $"{o.EngineName}: {o.Total}"));
                this.Output.WriteLine(str);
            }
            //  Excepted output:
            //  Google winner: .net
            //  MSN Search winner: java
            foreach (var item in this.SearchEngines)
            {
                this.Output.WriteLine($"{item} winner: {   results.Where(o => o.SearchEngine == item).Select(o => new { Term = o.Term, Total = o.Count() })}");
            }

            //  Excepted output:
            //  Total winner: .net
            this.Output.WriteLine($"Total Winner:  {  results.GroupBy(o => o.Term).Select(grouping => new { Term = grouping.Key, Total = grouping.Sum(o => o.Count()) }).OrderByDescending(o => o.Total).First().Total  }");
        }
    }
}