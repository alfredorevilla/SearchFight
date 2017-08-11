using SearchFight.Search;
using SearchFight.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SearchFight.Models.Implementations {

    public class SearchFightModel : ISearchFightModel {
        public ISearchEngine[] _engines;

        public SearchFightModel(IEnumerable<ISearchEngine> engines)
        {
            this._engines = engines.ToArray();
        }

        public ModelTermSearchResult[] GetTermSearchResults(string[] terms) {
            var array = new ModelTermSearchResult[terms.Length * this._engines.Length];
            var tuples = new List<Tuple<ISearchEngine, Task<long>, string>>(terms.Length * this._engines.Length);

            Console.WriteLine(DateTimeOffset.UtcNow.ToLocalTime());
            foreach (var term in terms) {
                foreach (var engine in _engines) {
                    var task = engine.GetSearchTotalCountAsync(term);
                    tuples.Add(Tuple.Create(engine, task, term));
                }
            }
            Console.WriteLine(DateTimeOffset.UtcNow.ToLocalTime());
            var tasks = tuples.Select(o => o.Item2);

            Task.WaitAll(tasks.ToArray());
            if (tasks.Any(o => o.Status == TaskStatus.Faulted)) {
                throw new InvalidOperationException("At least one search operation could not be completed due an error");
            }

            var i = 0;
            foreach (var item in tuples) {
                array[i++] = new ModelTermSearchResult {
                    Count = item.Item2.Result,
                    SearchEngineName = item.Item1.GetName(),
                    Term = item.Item3,
                };
            }
            Console.WriteLine(DateTimeOffset.UtcNow.ToLocalTime());
            return array;
        }

        public bool TryValidateTerms(string[] terms, out string[] validationErrors) {
            List<string> errors = new List<string>();
            if (terms == null || (terms = terms.Select(o => StringHelper.RemoveExtraWhitespaces(o)).ToArray()).Distinct(StringComparer.CurrentCultureIgnoreCase).Count() < 2) {
                errors.Add("At least 2 non equal terms are required");
            }
            validationErrors = errors.ToArray();
            return !validationErrors.Any();
        }
    }
}