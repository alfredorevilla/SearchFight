using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARevillaSearchFight.Engines.Microsoft
{
    internal class BingWebSearchParameters
    {
        public int Count { get; set; } = 10;

        public string Market { get; set; } = "en-us";

        public int Offset { get; set; } = 0;

        public string Query { get; set; }

        public string ToString(bool prefixQuestionChar)
        {
            return (prefixQuestionChar ? "?" : "") + $"q={Query}&count={Count}&offset={Offset}&mkt={Market}";
        }

        public override string ToString()
        {
            return this.ToString(true);
        }

        public Uri ToUri(bool prefixQuestionChar = true)
        {
            return new Uri("/bing/v5.0/search" + this.ToString(), UriKind.Relative);
        }
    }
}
