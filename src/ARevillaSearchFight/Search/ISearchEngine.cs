using ARevillaSearchFight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARevillaSearchFight.Search
{
    /// <summary>
    /// Represents a search engine. 
    /// </summary>
    public interface ISearchEngine
    {
        /// <summary>
        /// Returns total number of search results found by the engine or service
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        int GetSearchTotalCount(string term);
    }
}
