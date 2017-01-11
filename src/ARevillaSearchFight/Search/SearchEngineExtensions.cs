using ARevillaSearchFight.Search;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ARevillaSearchFight.Search
{
    public static class SearchEngineExtensions
    {
        //  global cache
        static Dictionary<Type, string> _names = new Dictionary<Type, string>();

        /// <summary>
        /// Get the name for the specified engine. 
        /// </summary>
        /// <typeparam name="T">Type of<seealso cref="ISearchEngine"/></typeparam>
        /// <param name="engine">The engine from where to get its name</param>
        /// <returns></returns>
        public static string GetName<T>(this T engine) where T : ISearchEngine
        {
            var t = typeof(T);
            if (!_names.ContainsKey(t))
            {
                lock (((ICollection)_names).SyncRoot)
                {
                    if (!_names.ContainsKey(t))
                    {
                        var name = typeof(T).GetTypeInfo().CustomAttributes.OfType<SearchEngineMetadataAttribute>().SingleOrDefault()?.Name;
                        _names.Add(t, name ?? typeof(T).Name);
                    }
                }
            }
            return _names[t];
        }
    }
}
