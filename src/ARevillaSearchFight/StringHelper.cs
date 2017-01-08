using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ARevillaSearchFight
{
    public static class StringHelper
    {
        /// <summary>
        /// Removes extra whitespaces trimming both left and right and replacing consecutive whitespaces with a single one
        /// </summary>
        /// <param name="value">The string from where to remove extra whitespaces</param>
        /// <returns>An string without extra whitespaces</returns>
        public static string RemoveExtraWhitespaces(string value)
        {
            if (value == null)
                return value;
            return Regex.Replace(value.Trim(), @"\s+", " ");
        }
    }
}
