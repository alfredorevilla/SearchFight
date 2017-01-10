using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ARevillaSearchFight
{
    public static class SearchEngineExtensions
    {
        /// <summary>
        /// Get the name for the specified engine. 
        /// </summary>
        /// <typeparam name="T">Type of<seealso cref="ISearchEngine"/></typeparam>
        /// <param name="engine">The engine from where to get its name</param>
        /// <returns></returns>
        public static string GetName<T>(this T engine) where T : ISearchEngine
        {
            var name = typeof(T).GetTypeInfo().CustomAttributes.OfType<SearchEngineMetadataAttribute>().SingleOrDefault()?.Name;
            return name ?? typeof(T).Name;

        }
    }
}
