using ARevillaSearchFight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARevillaSearchFight
{
    /// <summary>
    /// Represents a search engine
    /// </summary>
    public interface ISearchEngine
    {
        /// <summary>
        /// Engine identifier
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Search method
        /// </summary>
        /// <param name="term">The term to search for</param>
        /// <returns>A <paramref name="SearchResults"/> object results collection</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        SearchResults Search(string term);
    }
}
