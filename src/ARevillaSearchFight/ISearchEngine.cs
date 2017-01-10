using ARevillaSearchFight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARevillaSearchFight
{
    /// <summary>
    /// Represents a search engine. 
    /// </summary>
    public interface ISearchEngine
    {
        /// <summary>
        /// Search method
        /// </summary>
        /// <param name="term">The term to search for</param>
        /// <returns cref="SearchResults">A SearchResults object</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        SearchResults Search(string term, int offset, int maxResults);


        /// <summary>
        /// Returns total number of search results found by the engine or service
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        int GetSearchTotalCount(string term);
    }
}
