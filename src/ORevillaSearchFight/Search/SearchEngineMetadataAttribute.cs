using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORevillaSearchFight.Search
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class SearchEngineMetadataAttribute : Attribute
    {
        public SearchEngineMetadataAttribute(string name, string version = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullOrEmptyException(nameof(name));
            }
            this.Name = name;
            this.Version = version;
        }

        /// <summary>
        /// Search engine name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Search engine version
        /// </summary>
        public string Version { get; }
    }
}