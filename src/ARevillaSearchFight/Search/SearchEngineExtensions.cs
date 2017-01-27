﻿using ARevillaSearchFight.Search;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ARevillaSearchFight.Search
{
    public static class SearchEngineExtensions
    {
        /// <summary>
        /// Returns total number of search results found by the engine or service in a synchronius manner
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public static long GetSearchTotalCount(this ISearchEngine engine, string term)
        {
            return engine.GetSearchTotalCountAsync(term).Result;
        }

        //  global cache
        private static Dictionary<Type, string> _names = new Dictionary<Type, string>();

        //static ConcurrentDictionary<Type,string>

        /// <summary>
        /// Get the name for the specified engine.
        /// </summary>
        /// <typeparam name="T">Type of<seealso cref="ISearchEngine"/></typeparam>
        /// <param name="engine">The engine from where to get its name</param>
        /// <returns></returns>
        public static string GetName<T>(this T engine) where T : ISearchEngine
        {
            var t = engine.GetType();// typeof(T);
            if (!_names.ContainsKey(t))
            {
                lock (((ICollection)_names).SyncRoot)
                {
                    if (!_names.ContainsKey(t))
                    {
                        var name = t.GetTypeInfo().GetCustomAttribute<SearchEngineMetadataAttribute>(t.Name.Equals("ObjectProxy") ? true : false)?.Name;
                        _names.Add(t, name ?? t.Name);
                    }
                }
            }
            return _names[t];
        }
    }
}