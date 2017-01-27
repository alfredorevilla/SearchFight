using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORevillaSearchFight.Engines.Microsoft
{
    internal class BingWebSearchParameters
    {
        public int Count { get; set; } = 10;

        public string Market { get; set; } = "en-us";

        public int Offset { get; set; } = 0;

        public string Query { get; set; }

        public override string ToString()
        {
            return $"/bing/v5.0/search?q={Query}&count={Count}&offset={Offset}&mkt={Market}";
        }

        public Uri ToUri()
        {
            return new Uri(this.ToString(), UriKind.Relative);
        }
    }
}