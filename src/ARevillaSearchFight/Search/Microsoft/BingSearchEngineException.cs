using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ARevillaSearchFight.Engines.Microsoft
{
    public class BingSearchEngineException : Exception
    {
        public BingSearchEngineException(string message) : base(message)
        {
        }
    }
}
