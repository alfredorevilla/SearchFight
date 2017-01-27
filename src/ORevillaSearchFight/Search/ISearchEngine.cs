using ORevillaSearchFight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORevillaSearchFight.Search
{
    /// <summary>
    /// Represents a search engine.
    /// </summary>
    public interface ISearchEngine
    {
        /// <summary>
        /// Returns total number of search results found by the engine or service in a async manner
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        Task<long> GetSearchTotalCountAsync(string term);
    }
}