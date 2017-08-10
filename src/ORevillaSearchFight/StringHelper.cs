using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SearchFight
{
    /// <summary>
    /// Just a <seealso cref="System.String"/> helper. We may move this to an extension method.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Removes extra whitespaces trimming both left and right and replacing consecutive whitespaces with a single one
        /// </summary>
        /// <param name="value">The <see cref="string"/> from where to remove extra whitespaces</param>
        /// <returns>A new <see cref="string"/> without extra whitespaces</returns>
        public static string RemoveExtraWhitespaces(string value)
        {
            if (value == null)
                return value;
            return Regex.Replace(value.Trim(), @"\s+", " ");
        }
    }
}